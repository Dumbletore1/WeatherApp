namespace WeatherApp2023.BusinessModels
{
    public class DataPoint
    {
        public int Id { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public double WindSpeed { get; set; }

        public double Temperature { get; set; }
        public double Cloud { get; set; }

        /// <summary>
        /// This is the field from the weatherOpenApi
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}
