namespace WeatherApp2023.Models
{
    public class WeatherViewModel
    {
        public IEnumerable<WeatherDatapointViewModel> WeatherDatapointViewModels { get; set; }
        public string? TemperatureDatapointsForGraph { get; set; }

        public string? WindDatapointsForGraph { get; set; }
        public string? SelectedCityValue { get; set; }
    }
}
