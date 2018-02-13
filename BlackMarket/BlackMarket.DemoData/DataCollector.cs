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

            Task<ServerResponse>[] tasks = new Task<ServerResponse>[3];

            tasks[0] = Task<ServerResponse>.Factory.StartNew(() => GetPositions());
            tasks[1] = Task<ServerResponse>.Factory.StartNew(() => GetTicker());
            tasks[2] = Task<ServerResponse>.Factory.StartNew(() => GetOrdersBook());

            Task.WaitAll(tasks);
            string[] result = { tasks[0].Result.ConvertToString(), tasks[1].Result.ConvertToString(),
                tasks[2].Result.ConvertToString()};

            FileManager.SaveLine(String.Join(";", result));
        }

        private ServerResponse GetPositions()
        {
            return api.GetActivePositions();
        }

        private ServerResponse GetTicker()
        {
            return api.GetTicker(tradingSymbol);
        }

        private ServerResponse GetOrdersBook()
        {
            return api.GetActiveOrders();
        }

    }
}
