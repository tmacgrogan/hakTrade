using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IEXSharp;
using hakTrade.Models;

namespace hakTrade.Controllers
{
    [ApiController]
    [Route("stocks/{symbol}")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<ShareController> _logger;
        IEXCloudClient _iexClient;

        public StockController(ILogger<ShareController> logger, IEXCloudClient client)
        {
            _logger = logger;
            _iexClient = client;
        }

        [HttpGet]
        public async Task<Quote> Get(string symbol)
        {
            _logger.LogInformation($"Getting quote for {symbol}");
            var result = await _iexClient.StockPrices.QuoteAsync(symbol);
            Quote response = null;
            if (result.ErrorMessage == null)
            {
                response = Quote.fromEIXSharp(result.Data);
            }
            return response;
        }
    }
}
