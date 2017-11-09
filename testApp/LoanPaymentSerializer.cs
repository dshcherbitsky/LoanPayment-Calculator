using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents a strongly typed objects that can be used for serializer loan payment result.
    /// </summary>
    public class LoanPaymentSerializer : ISerializer
    {
        /// <summary>
        /// Converts the Object to its JSON string representation.
        /// </summary>
        /// <param name="obj">The Object to convert.</param>
        /// <returns>A JSON string representation of the Object.</returns>
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
