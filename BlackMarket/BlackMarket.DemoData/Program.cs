using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackMarket.DemoData
{
    class Program
    {
        public const string apiKey = "";
        public const string keySecret = "";
        public const string tradingSymbol = "tBTCUSD";
        
        static void Main(string[] args)
        {

            BitfinexApi api = new BitfinexApi(apiKey,keySecret);
            var tickersResp = api.GetTickers(tradingSymbol);
            var ordersResp = api.GetActiveOrders();
            var positionsResp = api.GetActivePositions();
        }
    }
}
