using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public interface ILoanPaymentCalculator
    {
        LoanPaymentCalculateResult CalculateLoanPayment(LoanPaymentInput input);
    }
}
