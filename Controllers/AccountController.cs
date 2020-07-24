using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Amazon.DynamoDBv2.DataModel;
using hakTrade.Models;

namespace hakTrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        IDynamoDBContext _dynamo;

        public AccountController(ILogger<AccountController> logger, IDynamoDBContext dynamo)
        {
            _logger = logger;
            _dynamo = dynamo;
        }

        [HttpGet]
        public async Task<Account> Get(string name)
        {
            var result = await _dynamo.LoadAsync<Account>(name);
            return result;
        }

        [HttpPost]
        public async Task<Account> Post(Account account)
        {
            await _dynamo.SaveAsync(account);
            var result = await _dynamo.LoadAsync<Account>(account.name);
            return result;
        }
    }
}
