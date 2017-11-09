using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents a strongly typed objects that can be used for calculating loan payment.
    /// </summary>
    public class LoanPaymentCalculator : ILoanPaymentCalculator
    {
        private readonly ILoanPaymentInputValidator validator;

        /// <summary>
        /// Initializes a new instance of the LoanPaymentCalculator class.
        /// </summary>
        public LoanPaymentCalculator() : this(new LoanPaymentInputValidator(new List<string>()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the LoanPaymentCalculator class.
        /// </summary>
        /// <param name="validator">Validator to validate LoanPaymentInput before calculating.</param>
        public LoanPaymentCalculator(ILoanPaymentInputValidator validator)
        {
            this.validator = validator;
        }

        /// <summary>
        ///  Calculate loan payment.
        /// </summary>
        /// <param name="input">LoanPaymentInput represents object that contains data for calculating loan payment.</param>
        /// <returns>LoanPaymentCalculateResult represents object that contains calculated result or errors.</returns>
        public LoanPaymentCalculateResult CalculateLoanPayment(LoanPaymentInput input)
        {
            if (validator.IsValid(input))
            {
                double pv = input.Amount - input.Downpayment;
                double rate = input.Interest / 100;
                double term = input.Term * 12;

                double mp = (pv * rate / 12) / (1 - Math.Pow(1 + rate / 12, -1 * term));
                double tp = mp * term;
                double ti = tp - pv;

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
