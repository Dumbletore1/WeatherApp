using WeatherApp2023.BusinessModels;
using WeatherApp2023.Infrastructure.Persistence;
using WeatherApp2023.Models;


namespace WeatherApp2023.Services
{
    public interface IDatapointService
    {
        Task<IEnumerable<DataPoint>> GetDataPointsAsync(string cityName);
    }

    public class DatapointService : IDatapointService
    {
        private readonly IDatapointRepository _datapointRepository;

        public DatapointService(IDatapointRepository datapointRepository)
        {
            _datapointRepository = datapointRepository;
        }

        public async Task<IEnumerable<DataPoint>> GetDataPointsAsync(string cityName)
        {
            var dps = await _datapointRepository.GetDatapointsByCityAsync(cityName);

            return dps.GroupBy(e => e.LastUpdate)
                .Select(g => g.First());
        }
    }
}
