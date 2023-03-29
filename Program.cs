using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using WeatherApp2023.Infrastructure.Persistence;
using WeatherApp2023.Integrations;
using WeatherApp2023.Models;
using WeatherApp2023.Services;
using WeatherApp2023.Worker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<FetchWeatherPointsService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IWeatherApiFacade, WeatherApiFacade>();
builder.Services.AddTransient<IDatapointRepository, DatapointRepository>();
builder.Services.AddTransient<IDatapointService, DatapointService>();


builder.Services.AddHttpClient<IWeatherApiFacade, WeatherApiFacade>("WeatherApi", httpClient =>
{
    {
        httpClient.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
    };
});


builder.Services.AddControllersWithViews().Services.AddDbContext<DatapointContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatapointContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
