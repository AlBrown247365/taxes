using System.Threading.Tasks;
using TaxService.Models;

namespace TaxService.Interfaces
{
    public interface ICalculator
    {
        Task<float> CalculateTaxRate(Location location);
        Task<float> CalculateTaxAmount(Order order);
    }
}