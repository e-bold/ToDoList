namespace one2Do.ViewModels
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int ToDoListId { get; set; }
    }
}
