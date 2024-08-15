using System.ComponentModel.DataAnnotations;

namespace one2Do.WeatherModel;

public class SearchByCity
{
    [Required(ErrorMessage = "City name is required")]
    [Display(Name = "City name")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid Input. Length must between 2 to 20 characters.")]
    public string? CityName { get; set;}
   
}
