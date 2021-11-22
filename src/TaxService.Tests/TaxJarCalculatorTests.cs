using System.Threading.Tasks;
using Moq;
using TaxService.Calculators;
using TaxService.Interfaces;
using TaxService.Models;
using TaxService.Models.TaxJar;
using Xunit;

namespace TaxService.Tests
{
    public class TaxJarCalculatorTests
    {
        private static readonly Rate TestRate = new()
        {
            CombinedRate = .1234F
        };

        private static readonly Tax TestTax = new()
        {
            AmountToCollect = 4321
        };
        private readonly Mock<ITaxJarGateway> _gateway = new();

        private readonly TaxJarCalculator _calculator;

        public TaxJarCalculatorTests()
        {
            _gateway
                .Setup(x => x.GetRate(It.IsAny<Location>()))
                .Returns(Task.FromResult(TestRate));
            _gateway
                .Setup(x => x.GetTaxes(It.IsAny<Order>()))
                .Returns(Task.FromResult(TestTax));

            _calculator = new TaxJarCalculator(_gateway.Object);
        }

        [Fact]
        public async Task CalculateTaxRateReturnsCombinedRate()
        {
            var result = await _calculator.CalculateTaxRate(new());

            Assert.Equal(TestRate.CombinedRate, result);
        }

        [Fact]
        public async Task CalculateTaxAmountReturnsAmountToCollect()
        {
            var result = await _calculator.CalculateTaxAmount(new());

            Assert.Equal(TestTax.AmountToCollect, result);
        }

        [Fact]
        public async Task CalculateTaxRateCallsGetRateOnce()
        {
            var result = await _calculator.CalculateTaxRate(new());

            _gateway.Verify(x => x.GetRate(It.IsAny<Location>()), Times.Once);
            _gateway.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CalculateTaxAmountCallsGetRateOnce()
        {
            var result = await _calculator.CalculateTaxAmount(new());

            _gateway.Verify(x => x.GetTaxes(It.IsAny<Order>()), Times.Once);
            _gateway.VerifyNoOtherCalls();
        }

    }
}