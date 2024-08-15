using System.Collections.Generic;

namespace one2Do.ViewModels
{
    public class ToDoListItemViewModel
    {
        public int ToDoListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TaskItemViewModel> TaskItems { get; set; } = new List<TaskItemViewModel>();
        public string CategoryName { get; set; } = string.Empty;
        public int TotalTasks { get; set;}
        public int CompletedTasks {get; set;}
    }

}
