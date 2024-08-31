using System;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string Description { get; set; } // Ensure non-null default

        // Foreign key to the ToDoList this task belongs to
        [Required]
        public int ToDoListId { get; set; }

        public bool IsCompleted { get; set; }

        public ToDoList ToDoList { get; set; }
    }
}
