using Amazon.DynamoDBv2.DataModel;

namespace hakTrade.Models
{
    public class Share
    {
        public string symbol { get; set; }
        public int owned { get; set; }
        public decimal cost { get; set; }
        public decimal unitCost => owned > 0 ? cost / owned : 0;
    }
}