using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public class LoanPaymentRawInput
    {
        private readonly ILoanPaymentRawInputValidator validator;

        public LoanPaymentRawInput() : this(new LoanPaymentRawInputValidator(new List<string>()))
        {
        }

        public LoanPaymentRawInput(ILoanPaymentRawInputValidator validator)
        {
            this.validator = validator;
        }

        public string Amount { get; set; }

        public string Interest { get; set; }

        public string Downpayment { get; set; }

        public string Term { get; set; }

        public bool IsValid()
        {
            return validator.IsValid(this);
        }

        public List<string> GetErrors()
        {
            return validator.GetValidationErrors();
        }
    }
}