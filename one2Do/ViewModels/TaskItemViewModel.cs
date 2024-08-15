using System;
using System.ComponentModel.DataAnnotations;

namespace one2Do.ViewModels
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; } = string.Empty; // Ensure non-null default

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; } = DateTime.Now; // Nullable DateTime

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        public int ToDoListId { get; set; }
    }
}
