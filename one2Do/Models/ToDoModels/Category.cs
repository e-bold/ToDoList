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
        public virtual ICollection<ToDoListCategory> ToDoListCategories { get; set; }
        // Connection to ListTemplateCategory for linking with list templates
        public virtual ICollection<ListTemplateCategory> ListTemplateCategories { get; set; }

        public Category()
        {
            ToDoLists = new HashSet<ToDoList>();
            ToDoListCategories = new HashSet<ToDoListCategory>();
            ListTemplateCategories = new HashSet<ListTemplateCategory>();
        }
    }
}
