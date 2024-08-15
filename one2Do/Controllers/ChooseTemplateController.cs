using Microsoft.AspNetCore.Mvc;
using one2Do.Data;


namespace one2Do;

public class ChooseTemplateController: Controller
{
    public one2doDbContext context;
    public ChooseTemplateController(one2doDbContext dbContext)
    {
        context=dbContext;
    }
    public IActionResult Index()
    {

        return View();
    }



}

// 
// [Authorize]
// public class WeatherController : Controller
// {
//     private readonly IWForecastRepository _WForecastRepository;


//     public WeatherController(IWForecastRepository WForecastRepository)
//     {
//         _WForecastRepository = WForecastRepository;
//     }


//     [HttpGet]
//     public IActionResult SearchByCity()
//     {
//         var viewModel = new SearchByCity();
//         return View(viewModel);
//     }

//     [HttpPost]
//     public IActionResult SearchByCity(SearchByCity model)
//     {
//         if (ModelState.IsValid)
//         {
//             return RedirectToAction("City", "Weather", new { city = model.CityName});
//         }

//         return View(model);
//     }



//     [HttpGet]
//     public IActionResult City(string city)
//     {
//         WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
//         City viewModel = new City();
//         if(weatherResponse != null)
//         {
//             viewModel.Name = weatherResponse.Name;
//             viewModel.Temperature = weatherResponse.Main.Temp;
//             viewModel.Humidity = weatherResponse.Main.Pressure;
//             viewModel.Weather = weatherResponse.Weather[0].Main;
//             viewModel.Wind = weatherResponse.Wind.Speed;
//         }
//         return View(viewModel);
//     }

// }





//     public IActionResult SearchByCity()
//     {
//         var viewModel = new SearchByCity();
//         return View(viewModel);
//     }

//     [HttpPost]
//     public IActionResult SearchByCity(SearchByCity model)
//     {
//         if (ModelState.IsValid)
//         {
//             return RedirectToAction("City", "Weather", new { city = model.CityName});
//         }

//         return View(model);
//     }



//     [HttpGet]
//     public IActionResult City(string city)
//     {
//         WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
//         City viewModel = new City();
//         if(weatherResponse != null)
//         {
//             viewModel.Name = weatherResponse.Name;
//             viewModel.Temperature = weatherResponse.Main.Temp;
//             viewModel.Humidity = weatherResponse.Main.Pressure;
//             viewModel.Weather = weatherResponse.Weather[0].Main;
//             viewModel.Wind = weatherResponse.Wind.Speed;
//         }
//         return View(viewModel);
//     }

// }
