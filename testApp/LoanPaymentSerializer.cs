using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public class LoanPaymentSerializer : ISerializer
    {
        public string SerializeObjectToJson(object obj)
        {
            string res = JsonConvert.SerializeObject(
                obj,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return res;
        }
    }
}
