using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BitfinexApi
{
    public class ActivePositionItem
    {
        public string id;
        public string symbol;
        public string status;
        public string _base;//base reserved word
        public string amount;
        public string timestamp;
        public string swap;
        public string pl;
    }
    public class ActivePositionsResponse : ServerResponse
    {
        public List<ActivePositionItem> positions;
        public static ActivePositionsResponse FromJSON(string response)
        {
            response = response.Replace("base", "_base");
            List<ActivePositionItem> items = JsonConvert.DeserializeObject<List<ActivePositionItem>>(response);
            return new ActivePositionsResponse(items);
        }

        public override string ConvertToString()
        {
            throw new NotImplementedException();
        }

        private ActivePositionsResponse(List<ActivePositionItem> positions)
        {
            this.positions = positions;
        }
    }
}
