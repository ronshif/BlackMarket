using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackMarket.DemoData
{
    class Program
    {
        public const string apiKey = "B75fiHoSIEWr3BGRwATpNKaB7k5XyRHHjlNB3PAtt6D";
        public const string keySecret = "4yOhkJJEJUH5n1nZrXLhKnEYyk7pr0QwdkCtzkjtYau";

        static void Main(string[] args)
        {

            BitfinexApi api = new BitfinexApi(apiKey,keySecret);
            var tickersResp = api.GetTickers("tBTCUSD");
            
        }
    }
}
