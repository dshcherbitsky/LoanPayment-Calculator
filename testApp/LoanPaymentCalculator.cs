using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public class LoanPaymentCalculator : ILoanPaymentCalculator
    {
        private readonly ILoanPaymentInputValidator validator;

        public LoanPaymentCalculator() : this(new LoanPaymentInputValidator(new List<string>()))
        {
        }

        public LoanPaymentCalculator(ILoanPaymentInputValidator validator)
        {
            this.validator = validator;
        }

        public LoanPaymentCalculateResult CalculateLoanPayment(LoanPaymentInput input)
        {
            if (validator.IsValid(input))
            {
                double pv = input.Amount - input.Downpayment;
                double i = input.Interest / 100;
                double t = input.Term;

                double mp = (pv * i) / (1 - Math.Pow(1 + i, -1 * t));
                double ti = pv * (1 + i * t);
                double tp = mp * t;

                return new LoanPaymentCalculateResult()
                {
                    MonthlyPayment = Math.Round(mp, 2, MidpointRounding.AwayFromZero),
                    TotalInterest = Math.Round(ti, 2, MidpointRounding.AwayFromZero),
                    TotalPayment = Math.Round(tp, 2, MidpointRounding.AwayFromZero)
                };
            }
            else
            {
                return new LoanPaymentCalculateResult()
                {
                    Errors = validator.GetValidationErrors()
                };
            }
        }
    }
}
