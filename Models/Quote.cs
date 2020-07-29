#region Assembly IEXSharp, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// IEXSharp.dll
#endregion

namespace hakTrade.Models
{
    public class Quote
    {
        public decimal? extendedChange { get; set; }
        public decimal? extendedChangePercent { get; set; }
        public long? extendedPriceTime { get; set; }
        public decimal? previousClose { get; set; }
        public int? previousVolume { get; set; }
        public decimal? change { get; set; }
        public decimal? changePercent { get; set; }
        public decimal? volume { get; set; }
        public decimal? iexMarketPercent { get; set; }
        public int? iexVolume { get; set; }
        public int? avgTotalVolume { get; set; }
        public decimal? iexBidPrice { get; set; }
        public int? iexBidSize { get; set; }
        public decimal? iexAskPrice { get; set; }
        public int? iexAskSize { get; set; }
        public decimal? iexOpen { get; set; }
        public decimal? iexOpenTime { get; set; }
        public decimal? iexClose { get; set; }
        public long? iexCloseTime { get; set; }
        public long? marketCap { get; set; }
        public decimal? peRatio { get; set; }
        public decimal? week52High { get; set; }
        public decimal? week52Low { get; set; }
        public decimal? ytdChange { get; set; }
        public long? lastTradeTime { get; set; }
        public decimal? extendedPrice { get; set; }
        public bool isUSMarketOpen { get; set; }
        public decimal? oddLotDelayedPriceTime { get; set; }
        public long? delayedPriceTime { get; set; }
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string primaryExchange { get; set; }
        public string calculationPrice { get; set; }
        public decimal? open { get; set; }
        public long? openTime { get; set; }
        public string openSource { get; set; }
        public decimal? close { get; set; }
        public long? closeTime { get; set; }
        public string closeSource { get; set; }
        public decimal? high { get; set; }
        public long? highTime { get; set; }
        public string highSource { get; set; }
        public decimal? low { get; set; }
        public long? lowTime { get; set; }
        public string lowSource { get; set; }
        public decimal? latestPrice { get; set; }
        public string latestSource { get; set; }
        public string latestTime { get; set; }
        public long? latestUpdate { get; set; }
        public long? latestVolume { get; set; }
        public decimal? iexRealtimePrice { get; set; }
        public int? iexRealtimeSize { get; set; }
        public long? iexLastUpdated { get; set; }
        public decimal? delayedPrice { get; set; }
        public decimal? oddLotDelayedPrice { get; set; }
        public string sector { get; set; }

        public static Quote fromEIXSharp(IEXSharp.Model.Shared.Response.Quote quote)
        {
            var model = new Quote()
            {
                extendedChange = quote.extendedChange,
                extendedChangePercent = quote.extendedChangePercent,
                extendedPriceTime = quote.extendedPriceTime,
                previousClose = quote.previousClose,
                previousVolume = quote.previousVolume,
                change = quote.change,
                changePercent = quote.changePercent,
                volume = quote.volume,
                iexMarketPercent = quote.iexMarketPercent,
                iexVolume = quote.iexVolume,
                avgTotalVolume = quote.avgTotalVolume,
                iexBidPrice = quote.iexBidPrice,
                iexBidSize = quote.iexBidSize,
                iexAskPrice = quote.iexAskPrice,
                iexAskSize = quote.iexAskSize,
                iexOpen = quote.iexOpen,
                iexOpenTime = quote.iexOpenTime,
                iexClose = quote.iexClose,
                iexCloseTime = quote.iexCloseTime,
                marketCap = quote.marketCap,
                peRatio = quote.peRatio,
                week52High = quote.week52High,
                week52Low = quote.week52Low,
                ytdChange = quote.ytdChange,
                lastTradeTime = quote.lastTradeTime,
                extendedPrice = quote.extendedPrice,
                isUSMarketOpen = quote.isUSMarketOpen,
                oddLotDelayedPriceTime = quote.oddLotDelayedPriceTime,
                delayedPriceTime = quote.delayedPriceTime,
                symbol = quote.symbol,
                companyName = quote.companyName,
                primaryExchange = quote.primaryExchange,
                calculationPrice = quote.calculationPrice,
                open = quote.open,
                openTime = quote.openTime,
                openSource = quote.openSource,
                close = quote.close,
                closeTime = quote.closeTime,
                closeSource = quote.closeSource,
                high = quote.high,
                highTime = quote.highTime,
                highSource = quote.highSource,
                low = quote.low,
                lowTime = quote.lowTime,
                lowSource = quote.lowSource,
                latestPrice = quote.latestPrice,
                latestSource = quote.latestSource,
                latestTime = quote.latestTime,
                latestUpdate = quote.latestUpdate,
                latestVolume = quote.latestVolume,
                iexRealtimePrice = quote.iexRealtimePrice,
                iexRealtimeSize = quote.iexRealtimeSize,
                iexLastUpdated = quote.iexLastUpdated,
                delayedPrice = quote.delayedPrice,
                oddLotDelayedPrice = quote.oddLotDelayedPrice,
                sector = quote.sector
            };
            return model;
        }
    }
}