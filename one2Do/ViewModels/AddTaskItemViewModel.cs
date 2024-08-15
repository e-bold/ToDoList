using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class AddTaskItemViewModel
    {
        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; } = DateTime.Now;

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Required]
        public int ToDoListId { get; set; }
        public SelectList ToDoLists { get; set; }

        public AddTaskItemViewModel(IEnumerable<ToDoList> toDoLists)
        {
            ToDoLists = new SelectList(toDoLists, "Id", "Title");
        }

        public AddTaskItemViewModel()
        {
            ToDoLists = new SelectList(new List<ToDoList>());
        }
    }
}
