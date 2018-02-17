using System;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using BitfinexApi;

[JsonObject]
public class TickerResponse 
{
    public TickerStatusResponse tickerStatus;
    public string jsonResponse;

    TickerResponse(TickerStatusResponse stats, string jsonResponse)
    {
        this.jsonResponse = jsonResponse;
        this.tickerStatus = stats;
    }

    public static TickerResponse FromJSON(string response)
    {
        TickerStatusResponse ticker = JsonConvert.DeserializeObject<TickerStatusResponse>(response);
        return new TickerResponse(ticker, response);
    }
}
