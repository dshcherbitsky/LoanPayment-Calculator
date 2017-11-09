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
        /// Represents amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Represents interest.
        /// </summary>
        public double Interest { get; set; }

        /// <summary>
        /// Represents downpayment.
        /// </summary>
        public double Downpayment { get; set; }

        /// <summary>
        /// Represents term.
        /// </summary>
        public int Term { get; set; }
    }
}
