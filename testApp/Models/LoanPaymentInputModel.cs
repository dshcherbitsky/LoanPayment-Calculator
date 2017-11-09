using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that contains loan payment raw input converted data.
    /// </summary>
    public class LoanPaymentInput
    {
        /// <summary>
        /// Represents loan payment amount value.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Represents loan payment interest value.
        /// </summary>
        public double Interest { get; set; }

        /// <summary>
        /// Represents loan payment downpayment value.
        /// </summary>
        public double Downpayment { get; set; }

        /// <summary>
        /// Represents loan payment term value.
        /// </summary>
        public int Term { get; set; }
    }
}
