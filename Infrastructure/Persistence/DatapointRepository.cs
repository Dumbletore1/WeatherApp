using Microsoft.EntityFrameworkCore;
using WeatherApp2023.BusinessModels;
using Exception = System.Exception;

namespace WeatherApp2023.Infrastructure.Persistence
{
    public class DatapointRepository : IDatapointRepository
    {
        private readonly DatapointContext _context;
        public DatapointRepository(DatapointContext context)
        {
            _context = context;
        }

        public async Task AddDataPointAsync(DataPoint dataPoint)
        {
            try
            {
                _context.DataPoints.Add(dataPoint);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public async Task<IEnumerable<DataPoint>> GetDatapointsByCityAsync(string city)
        {
            var dps = await _context.DataPoints
                .Where(e => e.City == city)
                .ToListAsync();
            return dps;
        }

        public void AddDataPoint(DataPoint dataPoint)
        {
            try
            {
                _context.DataPoints.Add(dataPoint);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
