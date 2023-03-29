using System.Diagnostics;
using WeatherApp2023.Infrastructure.Persistence;
using WeatherApp2023.Integrations;

namespace WeatherApp2023.Worker
{
    public class FetchWeatherPointsService : BackgroundService
    {
        private readonly ILogger<FetchWeatherPointsService> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly IWeatherApiFacade _weatherApiFacade;
        private static int _millisecondsBetweenIteration = 10000;
        private static List<string> cities = new List<string>{"London", "Copenhagen", "Taastrup", "Riga", "Stockholm", "Goteborg", "Oslo", "Slagelse", "Bergen"};

        public FetchWeatherPointsService(ILogger<FetchWeatherPointsService> logger, IServiceProvider serviceProvider, IWeatherApiFacade weatherApiFacade
            )
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _weatherApiFacade = weatherApiFacade;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting job to fetch weather data");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //TODO i guess this is a good spot to make multiple threads with each their city to get data for
                    //Parallel.ForEach(cities, async item => await DoWork(stoppingToken, item));

                    await Task.Run(() => Parallel.ForEach(cities, async item => await DoWork(stoppingToken, item)));

                }
                catch (Exception err)
                {
                    _logger.LogError(err, $"Error caught in {nameof(FetchWeatherPointsService)}.");
                }

                await Task.Delay(TimeSpan.FromMilliseconds(_millisecondsBetweenIteration), stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken stoppingToken, string cityName)
        {
            _logger.LogInformation($"Within {nameof(DoWork)}");

            try
            {

                using (var scope = _serviceProvider.CreateScope())
                {
                    var datapointRepository = scope.ServiceProvider.GetRequiredService<IDatapointRepository>();

                    var datapointResponse = await _weatherApiFacade.GetWeathterDataPoint(cityName);
                    var dataPoint = Mapper.MapResponseToDomainModel(datapointResponse);
                    await datapointRepository.AddDataPointAsync(dataPoint);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error caught in {nameof(DoWork)} {cityName}");
            }
        }
    }
}
