using Domain.Http.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Http
{
    public class HttpTaxas : IHttpTaxas
    {
        protected readonly HttpClient _httpClient;
        private const string TAXAENDPOINT = "taxadejuros";

        public HttpTaxas(IConfiguration appsettings)
        {
            _httpClient = new HttpClient();
            var url = appsettings.GetSection("TaxasJuros:BaseAddress")?.Value;
            if (!string.IsNullOrEmpty(url))
                _httpClient.BaseAddress = new Uri(uriString: url);
        }

        public async Task<double> GetTaxasAsync()
        {
            var url = $"{_httpClient.BaseAddress}{TAXAENDPOINT}";
            var httpResponse = await _httpClient.GetStringAsync(url);
            return Convert.ToDouble(httpResponse);
        }
    }
}