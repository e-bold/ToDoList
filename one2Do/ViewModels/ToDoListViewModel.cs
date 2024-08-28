using System.Collections.Generic;

namespace one2Do.ViewModels
{
    public class ToDoListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TaskItemViewModel> TaskItems { get; set; } = new List<TaskItemViewModel>();
    }
}
