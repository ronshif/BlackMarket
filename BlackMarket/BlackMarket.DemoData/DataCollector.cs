using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlackMarket.DemoData
{
    class DataCollector
    {
        private string key;
        private string keySecret;
        private string tradingSymbol;
        BitfinexApi api;

        public DataCollector(string key, string keySecret, string tradingSymbol)
        {
            this.key = key;
            this.keySecret = keySecret;
            this.tradingSymbol = tradingSymbol;

            api = new BitfinexApi(key, keySecret);
        }

        public void CollectData()
        {
            Console.WriteLine("Collecting data...");
            var task = Task<TickerResponse>.Factory.StartNew(() => GetTicker());
            task.Wait();
            Console.WriteLine(String.Format("Ticker request task is completed"));
            FileManager.AppendResponse(task.Result as TickerResponse);
        }

        private TickerResponse GetTicker()
        {
            return api.GetTicker(tradingSymbol);
        }
        

    }
}
