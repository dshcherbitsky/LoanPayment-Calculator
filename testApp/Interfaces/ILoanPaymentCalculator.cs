using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that can be used for calculating loan payment.
    /// </summary>
    public interface ILoanPaymentCalculator
    {
        /// <summary>
        ///  Calculate loan payment.
        /// </summary>
        /// <param name="input">LoanPaymentInput represents object that contains data for calculating loan payment.</param>
        /// <returns>LoanPaymentCalculateResult represents object that contains calculated result or errors.</returns>
        LoanPaymentCalculateResult CalculateLoanPayment(LoanPaymentInput input);
    }
}
