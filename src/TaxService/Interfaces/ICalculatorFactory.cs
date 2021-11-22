namespace TaxService.Interfaces
{
    public interface ICalculatorFactory
    {
        ICalculator GetCalculator(string customerId = null);
    }
}