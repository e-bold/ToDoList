using System.Configuration;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using one2Do.WeatherModel;

namespace one2Do;

public class WForecastRepository : IWForecastRepository
{
    public WeatherResponse GetForecast(string city)
    {
        string APP_ID = Configuration.Values.OPEN_WEATHER_APP_ID;
        var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={APP_ID}");
        var request = new RestRequest("", RestSharp.Method.Get);
        RestResponse response = client.Execute(request);
        if(response.IsSuccessful)
        {
            var content = JsonConvert.DeserializeObject<JToken>(response.Content);
            return content?.ToObject<WeatherResponse>();
        }
        else
            return null;
    }
}
