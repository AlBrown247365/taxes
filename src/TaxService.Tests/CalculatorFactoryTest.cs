using System;
using Moq;
using TaxService.Calculators;
using Xunit;

namespace TaxService.Tests;

public class CalculatorFactoryTests
{
    private readonly Mock<IServiceProvider> _provider = new();

    public CalculatorFactoryTests()
    {
        _provider.Setup(x => x.GetService(It.IsAny<Type>())).Returns(new TaxJarCalculator(null));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("fdsafda")]
    [InlineData(null)]
    public void GetCalculatorWithAnyStringParameterReturnsICalculator(string customerId)
    {
        var factory = new CalculatorFactory(_provider.Object);
        var calculator = factory.GetCalculator(customerId);

        Assert.NotNull(calculator);
    }

    [Fact]
    public void GetCalculatorWithoutParameterReturnsICalculator()
    {
        var factory = new CalculatorFactory(_provider.Object);
        var calculator = factory.GetCalculator();

        Assert.NotNull(calculator);
    }
}