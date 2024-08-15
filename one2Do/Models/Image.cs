using System.ComponentModel.DataAnnotations.Schema;

namespace one2Do.Models;

public class Image
{
    public int Id { get; set; }
    
    [NotMapped]
    public IFormFile Images { get; set; }
    public string UserId { get; set; }
    public string ImageUrl { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
}
