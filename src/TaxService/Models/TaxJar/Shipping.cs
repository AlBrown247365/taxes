using Newtonsoft.Json;

namespace TaxService.Models.TaxJar
{
    public class Shipping
    {
        [JsonProperty("city_amount")]
        public double CityAmount { get; set; }

        [JsonProperty("city_tax_rate")]
        public double CityTaxRate { get; set; }

        [JsonProperty("city_taxable_amount")]
        public double CityTaxableAmount { get; set; }

        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate { get; set; }

        [JsonProperty("county_amount")]
        public double CountyAmount { get; set; }

        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate { get; set; }

        [JsonProperty("county_taxable_amount")]
        public double CountyTaxableAmount { get; set; }

        [JsonProperty("special_district_amount")]
        public double SpecialDistrictAmount { get; set; }

        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate { get; set; }

        [JsonProperty("special_taxable_amount")]
        public double SpecialTaxableAmount { get; set; }

        [JsonProperty("state_amount")]
        public double StateAmount { get; set; }

        [JsonProperty("state_sales_tax_rate")]
        public double StateSalesTaxRate { get; set; }

        [JsonProperty("state_taxable_amount")]
        public double StateTaxableAmount { get; set; }

        [JsonProperty("tax_collectable")]
        public double TaxCollectable { get; set; }

        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }
    }

    
}