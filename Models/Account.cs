using Amazon.DynamoDBv2.DataModel;

namespace hakTrade.Models
{
    [DynamoDBTable("Account")]
    public class Account
    {
        [DynamoDBHashKey]
        public string name { get; set; }
        public string password { get; set; }
        public double cash { get; set; }
    }
}