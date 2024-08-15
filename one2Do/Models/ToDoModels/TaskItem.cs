using System;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string Description { get; set; } = string.Empty; // Ensure non-null default

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; } = DateTime.Now;

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        // Foreign key to the ToDoList this task belongs to
        [Required]
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }


    }
}
