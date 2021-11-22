namespace TaxService.Models
{
    public class AppSettings
    {
        public string ApiKey { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(ApiKey);
    }
}