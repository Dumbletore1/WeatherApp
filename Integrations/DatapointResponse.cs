using System.Text.Json.Serialization;

namespace WeatherApp2023.Integrations
{
    public class DatapointResponse
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string? CityName { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }


    }

    public class Current
    {
        [JsonPropertyName("wind_kph")]
        public double WindKkph { get; set; }

        /// <summary>
        /// Temperature in Celcius
        /// </summary>
        [JsonPropertyName("temp_c")]
        public double Temperature { get; set; }

        [JsonPropertyName("last_updated")]
        public string? LastUpdated { get; set; }


        [JsonPropertyName("cloud")]
        public double Cloud { get; set; }
    }
}
