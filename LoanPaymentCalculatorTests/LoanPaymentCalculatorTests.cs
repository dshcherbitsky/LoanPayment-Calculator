using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testApp;
using System.Collections.Generic;

namespace LoanPaymentCalculatorTests
{
    [TestClass]
    public class LoanPaymentCalculatorTests
    {
        [TestMethod]
        public void LoanPaymentRawInputValidatorTest()
        {
            List<string> errors = new List<string>();
            ILoanPaymentRawInputValidator validator = new LoanPaymentRawInputValidator(errors);

            var input = new LoanPaymentRawInput() { Amount = "5 5", Downpayment = "0q", Interest = "5.5.", Term = "5.5" };
            var result = validator.IsValid(input);
            Assert.IsFalse(result);
            Assert.AreEqual(4, validator.GetValidationErrors().Count);

            errors = new List<string>();
            validator = new LoanPaymentRawInputValidator(errors);
            input = new LoanPaymentRawInput() { Amount = "55", Downpayment = "10", Interest = "5.5 %", Term = "10" };
            result = validator.IsValid(input);
            Assert.IsTrue(result);
            Assert.AreEqual(0, validator.GetValidationErrors().Count);
        }

        [TestMethod]
        public void LoanPaymentInputValidatorTest()
        {
            List<string> errors = new List<string>();
            ILoanPaymentInputValidator validator = new LoanPaymentInputValidator(errors);

            var input = new LoanPaymentInput() { Amount = -2, Downpayment = -1, Interest = 0, Term = 0 };
            var result = validator.IsValid(input);

            Assert.IsFalse(result);
            Assert.AreEqual(5, validator.GetValidationErrors().Count);
        }

        [TestMethod]
        public void LoanPaymentSerializerTest()
        {
            ISerializer serializer = new LoanPaymentSerializer();
            var loanPaymentCalculateResult = new LoanPaymentCalculateResult() { MonthlyPayment = 18871.23, TotalInterest = 132274.02, TotalPayment = 1132274.02 };
            string result = serializer.SerializeObjectToJson(loanPaymentCalculateResult);
            string expect = "{\r\n  \"monthly payment\": 18871.23,\r\n  \"total interest\": 132274.02,\r\n  \"total payment\": 1132274.02\r\n}";
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void CalculateLoanPaymentWithoutErrorsTest()
        {
            ILoanPaymentCalculator calc = new LoanPaymentCalculator();
            var input = new LoanPaymentInput() { Amount = 1000000, Downpayment = 0, Interest = 5, Term = 5 };
            var expect = new LoanPaymentCalculateResult() { MonthlyPayment = 18871.23, TotalInterest = 132274.02, TotalPayment = 1132274.02 };
            var result = calc.CalculateLoanPayment(input);

            Assert.AreEqual(expect.MonthlyPayment, result.MonthlyPayment);
            Assert.AreEqual(expect.TotalPayment, result.TotalPayment);
            Assert.AreEqual(expect.TotalInterest, result.TotalInterest);
            Assert.AreEqual(expect.Success, result.Success);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CalculateLoanPaymentWithErrorsTest()
        {
            ILoanPaymentCalculator calc = new LoanPaymentCalculator();
            var input = new LoanPaymentInput() { Amount = -1000000, Downpayment = -10, Interest = -5, Term = -5 };
            var result = calc.CalculateLoanPayment(input);
            Assert.AreEqual(5, result.Errors.Count);
        }
    }
}
