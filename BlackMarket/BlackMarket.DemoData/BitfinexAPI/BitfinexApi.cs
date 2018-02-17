using System;
using System.Collections.Generic;

using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using BitfinexApi;

namespace BlackMarket.DemoData
{
    public class BitfinexApi
    {
        private DateTime epoch = new DateTime(1970, 1, 1);
        private HMACSHA384 hashMaker; 
        private string Key;
        private int nonce = 0;
        private string Nonce
        {
            get
            {
                if (nonce == 0)
                {
                    nonce = (int)(DateTime.UtcNow - epoch).TotalSeconds;
                }

                return (nonce++).ToString();
            }
        }
        public BitfinexApi(string key, string secretKey)
        {
            hashMaker = new HMACSHA384(Encoding.UTF8.GetBytes(secretKey));
            this.Key = key;
        }

        private String GetHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(String.Format("{0:x2}", b));
            }
            return sb.ToString();
        }
      
        public TickerResponse GetTicker(string symbol)
        {
            TickerRequest req = new TickerRequest(Nonce, symbol);
            string response = SendRequest(req, "GET",false);
            return TickerResponse.FromJSON(response);
        }

        private string SendRequest(GenericRequest request,string httpMethod,bool isAuth=true)
        {

            string json = JsonConvert.SerializeObject(request);
            string json64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] data = Encoding.UTF8.GetBytes(json64);
            byte[] hash = hashMaker.ComputeHash(data);
            string signature = GetHexString(hash);

            HttpWebRequest wr = WebRequest.Create("https://api.bitfinex.com" + request.request) as HttpWebRequest;

            wr.Headers.Add("X-BFX-APIKEY", Key);
            wr.Headers.Add("X-BFX-PAYLOAD", json64);
            wr.Headers.Add("X-BFX-SIGNATURE", signature);
            wr.Method = httpMethod;

            string response = null;
            try
            {
                HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
                throw new BitfinexException(ex, response);
            }
            return response;
        }

    }
}
