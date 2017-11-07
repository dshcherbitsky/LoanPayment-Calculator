using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public interface ILoanPaymentRawInputValidator
    {
        bool IsValid(LoanPaymentRawInput input);
        List<string> GetValidationErrors();
    }
}
