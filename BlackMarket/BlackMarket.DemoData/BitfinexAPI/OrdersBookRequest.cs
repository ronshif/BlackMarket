using System;
using System.Collections.Generic;

using System.Text;

namespace BitfinexApi
{
    public class OrdersBookRequest : GenericRequest
    {
        public OrdersBookRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/orders";
        }
    }
}
