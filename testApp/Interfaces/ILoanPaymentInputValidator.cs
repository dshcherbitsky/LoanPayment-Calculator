using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that can be used for validating Loan Payment data before calculating.
    /// </summary>
    public interface ILoanPaymentInputValidator
    {
        /// <summary>
        ///  Validate loan payment input data.
        /// </summary>
        /// <param name="input">The value to validate</param>
        bool IsValid(LoanPaymentInput input);

        /// <summary>
        ///  Returns loan payment data errors.
        /// </summary>
        List<string> GetValidationErrors();
    }
}
