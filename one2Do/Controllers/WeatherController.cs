using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using one2Do.Models;
using one2Do.WeatherModel;

namespace one2Do.Controllers;

[Authorize]
public class WeatherController : Controller
{
    private readonly IWForecastRepository _WForecastRepository;

    public WeatherController(IWForecastRepository WForecastRepository)
    {
        _WForecastRepository = WForecastRepository;
    }

    [HttpGet]
    public IActionResult SearchByCity()
    {
        var viewModel = new SearchByCity();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SearchByCity(SearchByCity model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("City", "Weather", new { city = model.CityName });
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult City(string city)
    {
        WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
        City viewModel = new City();
        if (weatherResponse != null)
        {
            viewModel.Name = weatherResponse.Name;
            viewModel.Temperature = weatherResponse.Main.Temp;
            viewModel.Temp_min = weatherResponse.Main.Temp_min;
            viewModel.Temp_max = weatherResponse.Main.Temp_max;
            viewModel.Humidity = weatherResponse.Main.Humidity;
            viewModel.Pressure = weatherResponse.Main.Pressure;
            viewModel.Weather = weatherResponse.Weather[0].Main;
            viewModel.Wind = weatherResponse.Wind.Speed;
            viewModel.Timezone = weatherResponse.Timezone;
            viewModel.Clouds = weatherResponse.Clouds.All;
            viewModel.Message = weatherResponse.Sys.Message;
            viewModel.Icon = "http://openweathermap.org/img/w/" + weatherResponse.Weather[0].Icon + ".png";
            viewModel.Country = weatherResponse.Sys.Country;
            viewModel.Description = weatherResponse.Weather[0].Description;
        }
        return View(viewModel);
    }
}
