using System.Threading.Tasks;
using TaxService.Models;
using TaxService.Models.TaxJar;

namespace TaxService.Interfaces
{
    public interface ITaxJarGateway
    {
        Task<Rate> GetRate(Location location);
        Task<Tax> GetTaxes(Order order);
    }
}
