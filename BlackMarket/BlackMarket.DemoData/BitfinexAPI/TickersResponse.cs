using System;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using BitfinexApi;

public class TickersResponse
{
    public string message;
    public TickersResponse(string message)
    {
        this.message = message;
    }

    public override string ToString()
    {
        return message;
    }
}
