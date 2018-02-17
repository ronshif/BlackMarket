using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexApi;

class TickerRequest : GenericRequest
{
    public TickerRequest(string nonce, string symbol)
    {
        this.nonce = nonce;
        this.request = string.Format("/v1/pubticker/{0}", symbol);
    }
}

