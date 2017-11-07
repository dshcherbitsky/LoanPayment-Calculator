using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public interface ILoanPaymentInputValidator
    {
        bool IsValid(LoanPaymentInput input);
        List<string> GetValidationErrors();
    }
}
