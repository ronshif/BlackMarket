using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BitfinexApi
{
    public abstract class GenericRequest
    {
        public string request;
        public string nonce;
        public ArrayList options = new ArrayList() ;
    }
}
