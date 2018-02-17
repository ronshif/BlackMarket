using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexApi;
using Newtonsoft.Json;

[JsonObject]
public class TickerStatusResponse
{
    [JsonProperty("mid")]
    public string AvgPrice { get; set; }
    [JsonProperty("bid")]
    public string BuyingPrice { get; set; }
    [JsonProperty("ask")]
    public string SellingPrice { get; set; }
    [JsonProperty("last_price")]
    public string MarketPrice { get; set; }
    [JsonProperty("low")]
    public string Low { get; set; }
    [JsonProperty("high")]
    public string High { get; set; }
    [JsonProperty("timestamp")]
    private string _time;
    [JsonProperty("volume")]
    private string volume;

    private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public string Volume {
        get
        {
            return volume.Substring(0, volume.IndexOf("."));
        }
    }

    public DateTime Time
    {
        get
        {
            return epoch.AddSeconds(long.Parse(_time.Substring(0, _time.IndexOf("."))));
        }
    }

    public static TickerStatusResponse FromJSON(string response)
    {
        return JsonConvert.DeserializeObject<TickerStatusResponse>(response);
    }
}

