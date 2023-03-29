using System.Text.Json;
using System.Web;
using WeatherApp2023.BusinessModels;

namespace WeatherApp2023.Integrations
{
    public class WeatherApiFacade : IWeatherApiFacade
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherApiFacade> _logger;

        public WeatherApiFacade(HttpClient httpClient, ILogger<WeatherApiFacade> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Call example looks like http://api.weatherapi.com/v1/current.json?key=9d027698d13f4e55882202045232803&q=London&aqi=no
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public async Task<DatapointResponse> GetWeathterDataPoint(string cityName)
        {
            HttpResponseMessage response;

            var builder = new UriBuilder(_httpClient.BaseAddress);
            var query = HttpUtility.ParseQueryString(builder.Query);
            //TODO should be moved to config or somewhere better
            query["key"] = "9d027698d13f4e55882202045232803";
            query["q"] = cityName;
            query["aqi"] = "no";
            builder.Query = query.ToString();
            string url = builder.ToString();


            response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"Unable to get weather datapoint. WeatherApi returned statuscode {response.StatusCode}");

                var err = await response.Content.ReadAsStreamAsync();

            }

            response.EnsureSuccessStatusCode();


            var asJson = await response.Content.ReadAsStringAsync();

            var asStreamAsync = await response.Content.ReadAsStreamAsync();

            

            var datapointResponse = await JsonSerializer.DeserializeAsync<DatapointResponse>(asStreamAsync, options: new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return datapointResponse;
        }
    }
}
