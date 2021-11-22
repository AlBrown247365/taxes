using Newtonsoft.Json;

namespace TaxService.Models.TaxJar
{
    public class RateResponse
    {
        [JsonProperty("rate")]
        public Rate Rate { get; set; }
    }
}