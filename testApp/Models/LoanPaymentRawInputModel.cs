using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that contains loan payment user raw input data.
    /// </summary>
    public class LoanPaymentRawInput
    {
        private readonly ILoanPaymentRawInputValidator validator;

        /// <summary>
        /// Initializes a new instance of the LoanPaymentRawInput class.
        /// </summary>
        public LoanPaymentRawInput() : this(new LoanPaymentRawInputValidator(new List<string>()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the LoanPaymentInputValidator class.
        /// </summary>
        /// <param name="validator">Validator to validate loan payment raw input data.</param>
        public LoanPaymentRawInput(ILoanPaymentRawInputValidator validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Represents loan payment input amount value.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Represents loan payment input interest value.
        /// </summary>
        public string Interest { get; set; }

        /// <summary>
        /// Represents loan payment input down payment value.
        /// </summary>
        public string Downpayment { get; set; }

        /// <summary>
        /// Represents loan payment input term value.
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Represents loan payment raw input data validation result.
        /// </summary>
        public bool IsValid()
        {
            return validator.IsValid(this);
        }

        /// <summary>
        /// Returns loan payment raw input data erros.
        /// </summary>
        /// <returns>A List of loan payment raw input data errors.</returns>
        public List<string> GetErrors()
        {
            return validator.GetValidationErrors();
        }
    }
}