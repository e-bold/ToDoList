using System.Collections.Generic;
using one2Do.Models.ToDoModels;

namespace one2Do.Models
{
    public class ListTemplate
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<TaskItem>? TaskItems { get; set; } 

        // This property will manage the many-to-many relationship through the join entity
        public List<ListTemplateCategory> ListTemplateCategories { get; set; }

        public ListTemplate(string title, int id)
        {
            Title = title;
            Id = id;
            TaskItems = new List<TaskItem>();
            ListTemplateCategories = new List<ListTemplateCategory>(); // Initialize the join entity list
        }

        public ListTemplate()
        {
            TaskItems = new List<TaskItem>();
            ListTemplateCategories = new List<ListTemplateCategory>(); // Initialize the join entity list
        }
    }
}
