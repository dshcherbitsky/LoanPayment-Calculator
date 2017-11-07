using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("amount: ");
                var amount = Console.ReadLine().Trim();
                Console.Write("interest: ");
                var interest = Console.ReadLine().Trim();
                Console.Write("downpayment: ");
                var downpayment = Console.ReadLine().Trim();
                Console.Write("term: ");
                var term = Console.ReadLine().Trim();
                Console.WriteLine(string.Empty);
                
                LoanPaymentRawInput rawInput = new LoanPaymentRawInput()
                {
                    Amount = amount,
                    Interest = interest,
                    Downpayment = downpayment,
                    Term = term
                };

                if (rawInput.IsValid())
                {
                    var mapperConfig = ConfigurateMapper();
                    IMapper mapper = mapperConfig.CreateMapper();
                    var input = mapper.Map<LoanPaymentRawInput, LoanPaymentInput>(rawInput);
                    ILoanPaymentCalculator calc = new LoanPaymentCalculator();
                    var loanPayment = calc.CalculateLoanPayment(input);
                    if (loanPayment.Success)
                    {
                        Console.WriteLine(loanPayment.GetResult());
                        Console.WriteLine(string.Empty);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Calculate error(s): {0}", string.Join(",", loanPayment.Errors)));
                        Console.WriteLine(string.Empty);
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Input data validation error(s): {0}", string.Join(",", rawInput.GetErrors())));
                    Console.WriteLine(string.Empty);
                }
            }
        }

        private static MapperConfiguration ConfigurateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoanPaymentRawInput, LoanPaymentInput>()
                    .ForMember(dest => dest.Interest, opts => opts.ResolveUsing(src =>
                    {
                        return double.Parse(src.Interest.Replace("%", string.Empty).Trim());
                    }));
            });

            return config;
        }
    }
}
