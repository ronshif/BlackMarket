using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BlackMarket.DemoData
{
    class Program
    {
        public static string key = "";
        public static string keySecret = "";
        public static string tradingSymbol = "btcusd";

        public static DataCollector dc = new DataCollector(key, keySecret, tradingSymbol);

        static void Main(string[] args)
        {
            var timer = new System.Timers.Timer();
            timer.Interval = 1000; // one second time interval
            timer.Elapsed += FireEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            Console.WriteLine("Press the any key to exit the program... ");
            Console.ReadLine();
          

        }

        private static void FireEvent(object sender, ElapsedEventArgs e)
        {
            dc.CollectData();
        }
    }
}
