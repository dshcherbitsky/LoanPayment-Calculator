using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    public class LoanPaymentRawInputValidator : ILoanPaymentRawInputValidator
    {
        private List<string> errors;

        public LoanPaymentRawInputValidator(List<string> errors)
        {
            this.errors = errors;
        }

        public bool IsValid(LoanPaymentRawInput input)
        {

            double amount;
            if (!double.TryParse(input.Amount, out amount))
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.AMOUNT_ERROR);
            }

            if (Regex.IsMatch(input.Interest, @"^\d{1,2}(\.\d{0,2})?\s?%$"))
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

            double term;
            if (!double.TryParse(input.Term, out term))
            {
                errors.Add(ApplicationKeys.LoanPaymentRawInputValidation.TERM_ERROR);
            }

            return errors.Count == 0;
        }

        public List<string> GetValidationErrors()
        {
            return errors;
        }
    }
}
