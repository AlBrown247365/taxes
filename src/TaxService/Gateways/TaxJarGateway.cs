namespace TaxService.Gateways
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using TaxService.Interfaces;
    using TaxService.Models;
    using TaxService.Models.TaxJar;

    public class TaxJarGateway : ITaxJarGateway
    {
        private const string api = "https://api.taxjar.com/v2";
        private readonly ILogger<TaxJarGateway> _logger;
        private readonly HttpClient _client;

        public TaxJarGateway(AppSettings settings, HttpClient client, ILogger<TaxJarGateway> logger)
        {
            _logger = logger;
            _client = client;
            var token = settings.ApiKey;
            _client.DefaultRequestHeaders.Add("Authorization", $"Token token=\"{token}\"");
        }

        public async Task<Rate> GetRate(Location location)
        {
            var uri = new Uri($"{api}/rates/90404?country=US&city={location?.City}");
            HttpResponseMessage response = null;

            try
            {
                response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var rateResponse = JsonConvert.DeserializeObject<RateResponse>(json);
            
                return rateResponse.Rate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Rates failed", uri, location, response?.StatusCode);
                throw;
            }
        }

        public async Task<Tax> GetTaxes(Order order)
        {
            var uri = new Uri($"{api}/taxes");
            HttpResponseMessage response = null;

            try
            {
                var orderJson = JsonConvert.SerializeObject(order);
                var content = new StringContent(orderJson, Encoding.UTF8, "application/json");
                response = await _client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var taxResponse = JsonConvert.DeserializeObject<TaxResponse>(responseJson);

                return taxResponse.Tax;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Taxes failed", uri, order, response?.StatusCode);
                throw;
            }
        }
    }
}