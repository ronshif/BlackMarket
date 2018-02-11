using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexApi;

class TickersRequest : GenericRequest
{
    public TickersRequest(string nonce, string symbol)
    {
        this.nonce = nonce;
        this.request = string.Format("/v2/tickers?symbols={0}",symbol);
    }
}

