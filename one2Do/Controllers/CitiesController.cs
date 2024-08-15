using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using one2Do.Data;
using one2Do.Models;
using one2Do.WeatherModel;

namespace one2Do.Controllers;

[Authorize]
public class CitiesController : Controller
{
    private readonly one2doDbContext _context;
    private readonly IWForecastRepository _WForecastRepository;
    private readonly UserManager<User> _userManager;

    public CitiesController(
        one2doDbContext context,
        UserManager<User> userManager,
        IWForecastRepository WForecastRepository
    )
    {
        _context = context;
        _userManager = userManager;
        _WForecastRepository = WForecastRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var userId = _userManager.GetUserId(User);
        var cities = _context.Cities.Where(c => c.UserId == userId).ToList();

        var cityWeatherList = new List<City>();
        foreach (var city in cities)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city.Name);
            if (
                weatherResponse != null
                && weatherResponse.Weather != null
                && weatherResponse.Weather.Count > 0
            )
            {
                var viewModel = new City
                {
                    Name = weatherResponse.Name,
                    Temperature = weatherResponse.Main.Temp,
                    Temp_min = weatherResponse.Main.Temp_min,
                    Temp_max = weatherResponse.Main.Temp_max,
                    Humidity = weatherResponse.Main.Humidity,
                    Pressure = weatherResponse.Main.Pressure,
                    Weather = weatherResponse.Weather[0].Main,
                    Wind = weatherResponse.Wind.Speed,
                    Timezone = weatherResponse.Timezone,
                    Clouds = weatherResponse.Clouds.All,
                    Message = weatherResponse.Sys.Message,
                    Icon = "http://openweathermap.org/img/w/" + weatherResponse.Weather[0].Icon + ".png",
                    Country = weatherResponse.Sys.Country,
                    Description = weatherResponse.Weather[0].Description
                };
                cityWeatherList.Add(viewModel);
            }
        }

        return View(cityWeatherList);
    }

    [HttpPost]
    public IActionResult AddCity(string cityName)
    {
        var userId = _userManager.GetUserId(User);
        if (
            !string.IsNullOrEmpty(cityName)
            && !_context.Cities.Any(c => c.Name == cityName && c.UserId == userId)
        )
        {
            _context.Cities.Add(new City { Name = cityName, UserId = userId });
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveCity(string cityName)
    {
        var userId = _userManager.GetUserId(User);
        var city = _context.Cities.FirstOrDefault(c => c.Name == cityName && c.UserId == userId);
        if (city != null)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
        else { }
        return RedirectToAction("Index");
    }
}
