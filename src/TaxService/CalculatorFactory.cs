using System;
using TaxService.Calculators;
using TaxService.Interfaces;

namespace TaxService
{
    public class CalculatorFactory : ICalculatorFactory
    {
        private readonly IServiceProvider _provider;

        public CalculatorFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICalculator GetCalculator(string customerId = null)
        {
            return customerId switch
            {
                _ => (ICalculator) _provider.GetService(typeof(TaxJarCalculator))
            };
        }
    }
}