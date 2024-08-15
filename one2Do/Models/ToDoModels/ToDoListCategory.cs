using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one2Do.Models.ToDoModels
{
    public class ToDoListCategory
    {
        [Key]
        public int ToDoListCategoryId { get; set; }

        [Required]
        public int ToDoListId { get; set; }
        public ToDoList? ToDoList { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
