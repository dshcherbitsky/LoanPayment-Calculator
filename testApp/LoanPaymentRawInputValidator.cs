using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    /// <summary>
    /// Represents a strongly typed objects that can be used for validating user raw input data 
    /// before converting to LoanPaymentInput and calculating loan payment.
    /// </summary>
    public class LoanPaymentRawInputValidator : ILoanPaymentRawInputValidator
    {
        private List<string> errors;

        /// <summary>
        /// Initializes a new instance of the LoanPaymentRawInputValidator class.
        /// </summary>
        /// <param name="errors">The list of validation errors.</param>
        public LoanPaymentRawInputValidator(List<string> errors)
        {
            this.errors = errors;
        }

        /// <summary>
        ///  Validate loan payment raw input data.
        /// </summary>
        /// <param name="input">The value to validate.</param>
        public bool IsValid(LoanPaymentRawInput input)
        {

            double amount;
            if (!double.TryParse(input.Amount, out amount))
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.AMOUNT_ERROR);
            }

            if (Regex.IsMatch(input.Interest, @"^\d+(\.\d+)?\s?%?$"))
            {
                double interest;
                if (!double.TryParse(input.Interest.Replace("%", string.Empty), out interest))
                {
                    errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.INTEREST_ERROR);
                }
            }
            else
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.INTEREST_ERROR);
            }
            
            double downpayment;
            if (!double.TryParse(input.Downpayment, out downpayment))
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.DOWNPAYMENT_ERROR);
            }

            int term;
            if (!int.TryParse(input.Term, out term))
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.TERM_ERROR);
            }

            return errors.Count == 0;
        }

        /// <summary>
        ///  Returns loan payment raw input data errors.
        /// </summary>
        public List<string> GetValidationErrors()
        {
            return errors;
        }
    }
}
