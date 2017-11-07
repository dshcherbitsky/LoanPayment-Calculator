using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Constants
{
    public class ApplicationKeys
    {
        public class LoanPaymentRawInputValidation
        {
            public const string AMOUNT_ERROR = "Amount has an incorrect format";
            public const string INTEREST_ERROR = "Interest has an incorrect format";
            public const string DOWNPAYMENT_ERROR = "Downpayment has an incorrect format";
            public const string TERM_ERROR = "Term has an incorrect format";
            public const string AMOUNT_DOWNPAYMENT_ERROR = "Amount can not be less than or equal to the Downpayment";
        }

        public class LoanPaymentInputValidation
        {
            public const string AMOUNT_ERROR = "Amount value must be greater than 0";
            public const string INTEREST_ERROR = "Interest value must be greater than 0";
            public const string DOWNPAYMENT_ERROR = "Downpayment value must be greater than or equal to 0";
            public const string TERM_ERROR = "Term value must be greater than 0 and less than 40";
            public const string AMOUNT_DOWNPAYMENT_ERROR = "Amount can not be less than or equal to the Downpayment";
        }

        public class LoanPaymentCalculateModelAttr
        {
            public const string MONTHLY_PAYMENTS = "monthly payment";
            public const string TOTAL_INTEREST = "total interest";
            public const string TOTAL_PAYMENT = "total payment";
        }
    }
}
