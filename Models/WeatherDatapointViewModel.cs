using System.ComponentModel.DataAnnotations;

namespace WeatherApp2023.Models
{
    public class WeatherDatapointViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatapointTime { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public double WindSpeed { get; set; }

        public double Temperature { get; set; }

    }
}
