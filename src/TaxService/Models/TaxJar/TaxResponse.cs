using Newtonsoft.Json;

namespace TaxService.Models.TaxJar
{
    public class TaxResponse
    {
        [JsonProperty("tax")]
        public Tax Tax{ get; set; }
    }
}