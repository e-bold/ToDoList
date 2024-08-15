using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using one2Do.Models;

namespace one2Do.WeatherModel;

public class City
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [Display(Name = "City name:")]
    public string Name { get; set; }

    [NotMapped]
    [Display(Name = "Temp.")]
    public float Temperature { get; set; }
    [NotMapped]
    [Display(Name = "Temp Minimum.")]
    public float Temp_min { get; set; }
    [NotMapped]
    [Display(Name = "Temp Maximum")]
    public float Temp_max { get; set; }

    [NotMapped]
    [Display(Name = "Humidity")]
    public int Humidity { get; set; }

    [NotMapped]
    [Display(Name = "Pressure:")]
    public int Pressure { get; set; }

    [NotMapped]
    [Display(Name = "Wind Speed:")]
    public float Wind { get; set; }

    [NotMapped]
    [Display(Name = "Weather Condition.")]
    public string Weather { get; set; }

    [NotMapped]
    [Display(Name = "Timezone.")]
    public int Timezone { get; set; }

    [NotMapped]
    [Display(Name = "Clouds.")]
    public int Clouds { get; set; }

    [NotMapped]
    [Display(Name = "Message.")]
    public float Message { get; set; }

    [NotMapped]
    [Display(Name = "Icon.")]
    public string Icon { get; set; }


    [NotMapped]
    [Display(Name = "Country.")]
    public string Country { get; set; }
    
    [NotMapped]
    [Display(Name = "Description.")]
    public string Description { get; set; }

    public User User { get; set; }

}
