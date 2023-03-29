using WeatherApp2023.BusinessModels;

namespace WeatherApp2023.Infrastructure.Persistence;

public interface IDatapointRepository
{
    void AddDataPoint(DataPoint dataPoint);

    Task AddDataPointAsync(DataPoint dataPoint);
    Task<IEnumerable<DataPoint>> GetDatapointsByCityAsync(string city);
}