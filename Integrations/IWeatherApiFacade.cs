using WeatherApp2023.BusinessModels;

namespace WeatherApp2023.Integrations;

public interface IWeatherApiFacade
{
    Task<DatapointResponse> GetWeathterDataPoint(string cityName);
}