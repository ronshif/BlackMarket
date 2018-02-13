using System;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using BitfinexApi;

public class OrdersBookResponse : ServerResponse 
{
    public List<OrderStatusResponse> orders;

    public static OrdersBookResponse FromJSON(string response)
    {
        List<OrderStatusResponse> orders = JsonConvert.DeserializeObject<List<OrderStatusResponse>>(response);
        return new OrdersBookResponse(orders);
    }

    public override string ConvertToString()
    {
        throw new NotImplementedException();
    }

    private OrdersBookResponse(List<OrderStatusResponse> orders)
    {
        this.orders = orders;
    }
}
    
