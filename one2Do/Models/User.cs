using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using one2Do.Models.ToDoModels;
using one2Do.WeatherModel;

namespace one2Do.Models;

public class User : IdentityUser
{
    [StringLength(100)]
    [MaxLength(100)]
    [Required]
    public string? FirstName { get; set; }

    [StringLength(100)]
    [MaxLength(100)]
    [Required]
    public string? LastName { get; set; }
    public int StreakPoints { get; set; }

    //Added following ICollecction items for
    public ICollection<ToDoList> ToDoLists { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<City> Cities { get; set; }
}
