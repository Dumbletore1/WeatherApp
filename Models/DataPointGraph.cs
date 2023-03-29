

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApp2023.Models
{
    /// <summary>
    /// This class corresponds to the values required by canvasJs
    /// </summary>
    public class DataPointGraph
    {

        [JsonPropertyName("label")]
        public string? Label { get; set; }


        [JsonPropertyName("y")]
        public double Y { get; set; }
    }
}
