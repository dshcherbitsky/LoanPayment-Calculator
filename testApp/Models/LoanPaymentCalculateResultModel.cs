using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    public class LoanPaymentCalculateResult
    {
        private readonly ISerializer serializer;

        public LoanPaymentCalculateResult() : this(new LoanPaymentSerializer())
        {
        }

        public LoanPaymentCalculateResult(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.MONTHLY_PAYMENTS)] 
        public double MonthlyPayment { get; set; }

        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.TOTAL_INTEREST)]
        public double TotalInterest { get; set; }

        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.TOTAL_PAYMENT)]
        public double TotalPayment { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonIgnore]
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        public string GetResult()
        {
            return serializer.SerializeObjectToJson(this);
        }
    }
}
