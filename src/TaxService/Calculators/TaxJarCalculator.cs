using System.Threading.Tasks;
using TaxService.Interfaces;
using TaxService.Models;

namespace TaxService.Calculators
{
    public class TaxJarCalculator:ICalculator
    {
        private readonly ITaxJarGateway _gateway;

        public TaxJarCalculator(ITaxJarGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<float> CalculateTaxRate(Location location)
        {
            var rate = await _gateway.GetRate(location);
            return rate.CombinedRate;
        }

        public async Task<float> CalculateTaxAmount(Order order)
        {
            var tax = await _gateway.GetTaxes(order);
            return tax.AmountToCollect;
        }
    }
}