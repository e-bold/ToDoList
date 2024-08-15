using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.QuoteModels
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
