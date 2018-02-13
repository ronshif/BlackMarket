using System;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using BitfinexApi;

public class TickerResponse : ServerResponse
{
    public string message;
    public TickerResponse(string message)
    {
        this.message = message;
    }

    public override string ConvertToString()
    {
        throw new NotImplementedException();
    }
}
