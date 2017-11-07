using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp.Constants;

namespace testApp
{
    public class LoanPaymentInputValidator : ILoanPaymentInputValidator
    {
        private List<string> errors;

        public LoanPaymentInputValidator(List<string> errors)
        {
            this.errors = errors;
        }

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

        public List<string> GetValidationErrors()
        {
            return errors;
        }
    }
}
