using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherApp2023.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherApp2023.Integrations;
using WeatherApp2023.Services;


namespace WeatherApp2023.Controllers;

public class WeatherController : Controller
{
    private readonly ILogger<WeatherController> _logger;
    private readonly IDatapointService _datapointService;
    private WeatherViewModel _weatherViewModel;

    private static List<SelectListItem> cities =
        new()
        {
            new SelectListItem { Value = "1", Text = "London" },
            new SelectListItem { Value = "2", Text = "Copenhagen" },
            new SelectListItem { Value = "3", Text = "Taastrup" },
            new SelectListItem { Value = "4", Text = "Riga" },
            new SelectListItem { Value = "5", Text = "Stockholm" },
            new SelectListItem { Value = "6", Text = "Goteborg" },
            new SelectListItem { Value = "7", Text = "Oslo" },
            new SelectListItem { Value = "8", Text = "Slagelse" },
            new SelectListItem { Value = "9", Text = "Bergen" }
        };

    public WeatherController(ILogger<WeatherController> logger, IDatapointService datapointService)
    {
        _logger = logger;
        _datapointService = datapointService;
    }

    public async Task<IActionResult> Index()
    {
        //TODO get from enum somewhere?
        ViewBag.cities = cities;
        _weatherViewModel = new WeatherViewModel();

        return View(_weatherViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string selectedCityValue)
    {
        var selectedCityName = cities.Single(e => e.Value == selectedCityValue).Text;

        ViewBag.cities = cities;

        _weatherViewModel = new WeatherViewModel();
        _weatherViewModel.SelectedCityValue = selectedCityValue;
        var datapoints = await _datapointService.GetDataPointsAsync(selectedCityName);

        var datapointViewModels = Mapper.MapDomainToVm(datapoints);


        List<DataPointGraph> temperatureDatapointsForGraph = new List<DataPointGraph>();
        List<DataPointGraph> windDatapointsForGraph = new List<DataPointGraph>();


        foreach (var datapoint in datapointViewModels)
        {
            temperatureDatapointsForGraph.Add(new DataPointGraph
            {
                Label = datapoint.DatapointTime.ToString("M/d hh:mm:ss"),
                Y = datapoint.Temperature
            });

            windDatapointsForGraph.Add(new DataPointGraph
            {
                Label = datapoint.DatapointTime.ToString("M/d hh:mm:ss"),
                Y = datapoint.WindSpeed
            });

        }

        _weatherViewModel.WeatherDatapointViewModels = datapointViewModels;
        _weatherViewModel.TemperatureDatapointsForGraph = JsonSerializer.Serialize(temperatureDatapointsForGraph);
        _weatherViewModel.WindDatapointsForGraph = JsonSerializer.Serialize(windDatapointsForGraph);

        return View(_weatherViewModel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
