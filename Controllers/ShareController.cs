using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using hakTrade.Models;
using IEXSharp;

namespace hakTrade.Controllers
{
    [ApiController]
    [Route("{accountName}/shares")]
    public class ShareController : ControllerBase
    {
        private readonly ILogger<ShareController> _logger;
        IDynamoDBContext _dynamo;
        IEXCloudClient _iexClient;

        public ShareController(ILogger<ShareController> logger, IDynamoDBContext dynamo, IEXCloudClient client)
        {
            _logger = logger;
            _dynamo = dynamo;
            _iexClient = client;
        }

        [HttpGet]
        public async Task<IEnumerable<Share>> Get(string accountName)
        {
            var result = await _dynamo.LoadAsync<Account>(accountName);
            return result.portfolio;
        }

        [HttpGet("{symbol}")]
        public async Task<Share> Get(string accountName, string symbol)
        {
            var result = await _dynamo.LoadAsync<Account>(accountName);
            var share = result?.portfolio?.FirstOrDefault(s => s.symbol == symbol);
            return share;
        }

        [HttpGet("{symbol}/buy/{quantity}")]
        public async Task<Share> Buy(string accountName, string symbol, int quantity)
        {
            _logger.LogInformation($"Getting account info for {accountName}");
            var account = await _dynamo.LoadAsync<Account>(accountName);
            var share = account?.portfolio?.FirstOrDefault(s => s.symbol == symbol);

            _logger.LogInformation($"Getting stock info for {symbol}");
            var stock = await _iexClient.StockPrices.QuoteAsync(symbol);
            Quote quote = null;
            if (stock.ErrorMessage == null)
            {
                quote = Quote.fromEIXSharp(stock.Data);
            }

            var cost = quote.latestPrice.Value * quantity;
            if (cost > account.cash) return null;

            account.cash -= cost;

            if (account.portfolio == null)
            {
                account.portfolio = new List<Share>();
            }

            if (share == null)
            {
                share = new Share()
                {
                    symbol = symbol,
                    owned = quantity,
                    cost = cost
                };
                account.portfolio.Append(share);
            }
            else
            {
                share.owned += quantity;
                share.cost += cost;
            }

            await _dynamo.SaveAsync(account);
            return share;
        }
    }
}
