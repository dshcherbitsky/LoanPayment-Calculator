using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    /// <summary>
    /// Represents objects that contains loan payment result.
    /// </summary>
    public class LoanPaymentCalculateResult
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes a new instance of the LoanPaymentCalculateResult class.
        /// </summary>
        public LoanPaymentCalculateResult() : this(new LoanPaymentSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the LoanPaymentCalculateResult class.
        /// </summary>
        /// <param name="serializer">Serializer that used to converts the Object to its JSON string representation.</param>
        public LoanPaymentCalculateResult(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Represents monthly payment calculated result.
        /// </summary>
        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.MONTHLY_PAYMENTS)] 
        public double MonthlyPayment { get; set; }

        /// <summary>
        /// Represents total interest calculated result.
        /// </summary>
        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.TOTAL_INTEREST)]
        public double TotalInterest { get; set; }

        /// <summary>
        /// Represents total payment calculated result.
        /// </summary>
        [JsonProperty(PropertyName = ApplicationKeys.LoanPaymentCalculateModelAttr.TOTAL_PAYMENT)]
        public double TotalPayment { get; set; }

        /// <summary>
        /// Represents loan payment calculated erros.
        /// </summary>
        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Is loan payment data correct.
        /// </summary>
        [JsonIgnore]
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        /// <summary>
        /// Returns loan payment calculated result as JSON string.
        /// </summary>
        /// <returns>Loan payment calculated result as JSON string.</returns>
        public string GetResult()
        {
            return serializer.SerializeObjectToJson(this);
        }
    }
}
