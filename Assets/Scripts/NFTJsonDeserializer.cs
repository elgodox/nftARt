using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

    public class NFTJsonDeserializer
    { 
        public RequestData Deserialize(string json)
        {
            var result = JsonConvert.DeserializeObject<RequestData>(json);
            return result;
        }
    }
