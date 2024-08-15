using one2Do.Models.ToDoModels;

namespace one2Do.Models
{
    public class ListTemplateCategory
    {
        public int ListTemplateId { get; set; }
        public ListTemplate? ListTemplate { get; set; }
        
        public int CategoryId { get; set; }  // This correctly matches the foreign key
        public Category? Category { get; set; } // Corrected to singular 'Category'
    }
}
