using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    public class LoanPaymentInput
    {
        public double Amount { get; set; }

        public double Interest { get; set; }

        public double Downpayment { get; set; }

        public int Term { get; set; }
    }
}
