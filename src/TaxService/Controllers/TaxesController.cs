using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxService.Interfaces;
using TaxService.Models;

namespace TaxService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ICalculatorFactory _factory;

        public TaxesController(ICalculatorFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationTaxRates([FromQuery(Name = "city")] string city)
        {
            var calculator = _factory.GetCalculator();
            var taxRate = await calculator.CalculateTaxRate(new Location { City = city });

            return new OkObjectResult(new { taxRate });
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderTaxes([FromBody] Order order)
        {
            var calculator = _factory.GetCalculator();
            var taxAmount = await calculator.CalculateTaxAmount(order);

            return new OkObjectResult(new { taxAmount });
        }
    }
}
