using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp.Constants
{
    /// <summary>
    /// Represents application's notification descriptions.
    /// </summary>
    public class ApplicationKeys
    {
        /// <summary>
        /// Represents loan payment raw input validation error descriptions.
        /// </summary>
        public class LoanPaymentRawInputValidation
        {
            /// <summary>
            /// Represents amount raw input validation error notification description.
            /// </summary>
            public const string AMOUNT_ERROR = "Amount has an incorrect format";

            /// <summary>
            /// Represents interest raw input validation error notification description.
            /// </summary>
            public const string INTEREST_ERROR = "Interest has an incorrect format";

            /// <summary>
            /// Represents down payment raw input validation error notification description.
            /// </summary>
            public const string DOWNPAYMENT_ERROR = "Downpayment has an incorrect format";

            /// <summary>
            /// Represents term raw input validation error notification description.
            /// </summary>
            public const string TERM_ERROR = "Term has an incorrect format";
        }

        /// <summary>
        /// Represents loan payment data validation error descriptions.
        /// </summary>
        public class LoanPaymentInputValidation
        {
            /// <summary>
            /// Represents amount validation error notification description.
            /// </summary>
            public const string AMOUNT_ERROR = "Amount value must be greater than 0";

            /// <summary>
            /// Represents interest validation error notification description.
            /// </summary>
            public const string INTEREST_ERROR = "Interest value must be greater than 0";

            /// <summary>
            /// Represents down payment validation error notification description.
            /// </summary>
            public const string DOWNPAYMENT_ERROR = "Downpayment value must be greater than or equal to 0";

            /// <summary>
            /// Represents term validation error notification description.
            /// </summary>
            public const string TERM_ERROR = "Term value must be greater than 0 and less than 40";

            /// <summary>
            /// Represents amount and downpayment compare validation error notification description.
            /// </summary>
            public const string AMOUNT_DOWNPAYMENT_ERROR = "Amount can not be less than or equal to the Downpayment";
        }

        /// <summary>
        /// Represents loan payment result attributes descriptions.
        /// </summary>
        public class LoanPaymentCalculateModelAttr
        {
            /// <summary>
            /// Represents monhtly description.
            /// </summary>
            public const string MONTHLY_PAYMENTS = "monthly payment";

            /// <summary>
            /// Represents total interest description.
            /// </summary>
            public const string TOTAL_INTEREST = "total interest";

            /// <summary>
            /// Represents total payment description.
            /// </summary>
            public const string TOTAL_PAYMENT = "total payment";
        }
    }
}
