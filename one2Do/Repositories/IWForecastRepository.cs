using one2Do.WeatherModel;

namespace one2Do;

public interface IWForecastRepository
{
    WeatherResponse GetForecast(string city);

}
