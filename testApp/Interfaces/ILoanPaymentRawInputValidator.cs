using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that can be used for validating user raw input data 
    /// before converting to LoanPaymentInput and calculating loan payment.
    /// </summary>
    public interface ILoanPaymentRawInputValidator
    {
        /// <summary>
        ///  Validate loan payment raw input data.
        /// </summary>
        /// <param name="input">The value to validate.</param>
        bool IsValid(LoanPaymentRawInput input);

        /// <summary>
        ///  Returns loan payment raw input data errors.
        /// </summary>
        List<string> GetValidationErrors();
    }
}
