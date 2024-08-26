using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using one2Do.Models.ToDoModels;

namespace one2Do.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Category Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Category name must be between 1 and 100 characters.")]
        public string Name { get; set; }

        // Navigation properties
        // Lists associated with this category
        public virtual ICollection<ToDoList> ToDoLists { get; set; }
        // Connection to ToDoListCategory for many-to-many relation with ToDoLists
        

        public Category()
        {
            ToDoLists = new HashSet<ToDoList>();
        }
    }
}
