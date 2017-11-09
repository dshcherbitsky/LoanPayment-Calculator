using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    /// <summary>
    /// Represents a strongly typed objects for Loan Payment data validation before calculating.
    /// </summary>
    public class LoanPaymentInputValidator : ILoanPaymentInputValidator
    {
        private List<string> errors;

        /// <summary>
        /// Initializes a new instance of the LoanPaymentInputValidator class.
        /// </summary>
        /// <param name="errors">The list of validation errors.</param>
        public LoanPaymentInputValidator(List<string> errors)
        {
            this.errors = errors;
        }

        /// <summary>
        ///  Validate loan payment input data.
        /// </summary>
        /// <param name="input">The value to validate</param>
        public bool IsValid(LoanPaymentInput input)
        {
            if (input.Amount <= 0)
            {
                errors.Add(ApplicationKeys.LoanPaymentInputValidation.AMOUNT_ERROR);
            }

            if (input.Interest <= 0)
            {
                errors.Add(ApplicationKeys.LoanPaymentInputValidation.INTEREST_ERROR);
            }

            if (input.Downpayment < 0)
            {
                errors.Add(ApplicationKeys.LoanPaymentInputValidation.DOWNPAYMENT_ERROR);
            }

            if (input.Term <= 0 || input.Term > 40)
            {
                errors.Add(ApplicationKeys.LoanPaymentInputValidation.TERM_ERROR);
            }

            if (input.Amount <= input.Downpayment)
            {
                errors.Add(ApplicationKeys.LoanPaymentInputValidation.AMOUNT_DOWNPAYMENT_ERROR);
            }

            return errors.Count == 0;
        }

        /// <summary>
        ///  Returns loan payment data errors.
        /// </summary>
        public List<string> GetValidationErrors()
        {
            return errors;
        }
    }
}
