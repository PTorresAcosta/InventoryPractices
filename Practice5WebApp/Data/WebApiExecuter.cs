using System.Globalization;

namespace Practice5WebApp.Data
{
    public class WebApiExecuter : IWebApiExecuter
    {

        private const string apiName = "InventoryApi";

        private readonly IHttpClientFactory _httpClientFactory;
        public WebApiExecuter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> InvokeGet<T>(string relativeUrl)
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);
            return await httpClient.GetFromJsonAsync<T>(relativeUrl);
        }

    }
}
