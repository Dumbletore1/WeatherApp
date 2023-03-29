using System.Collections;
using WeatherApp2023.BusinessModels;
using WeatherApp2023.Models;

namespace WeatherApp2023.Integrations
{
    public static class Mapper
    {
        public static BusinessModels.DataPoint MapResponseToDomainModel(DatapointResponse response)
        {
            DateTime dateValue;
            DateTime.TryParse(response.Current.LastUpdated, out dateValue);

            return new BusinessModels.DataPoint
            {
                Temperature = response.Current.Temperature,
                WindSpeed = response.Current.WindKkph,
                City = response.Location.CityName,
                Country = response.Location.Country,
                Cloud = response.Current.Cloud,
                LastUpdate = dateValue
            };
        }

        public static IEnumerable<WeatherDatapointViewModel> MapDomainToVm(IEnumerable<DataPoint> datapoints)
        {
            var weatherDatapointViewModels = new List<WeatherDatapointViewModel>();
            foreach (var datapoint in datapoints)
            {
                weatherDatapointViewModels.Add(new WeatherDatapointViewModel
                {
                    Temperature = datapoint.Temperature,
                    Country = datapoint.Country,
                    City = datapoint.City,
                    Id = datapoint.Id,
                    WindSpeed = datapoint.WindSpeed,
                    DatapointTime = datapoint.LastUpdate.GetValueOrDefault()
                });
            }

            return weatherDatapointViewModels;
        }
    }
}
