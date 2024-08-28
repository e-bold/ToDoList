using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "List Title")]
        public string Title { get; set; }

        public string UserId { get; set; }

        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

        public ToDoList()
        {
            TaskItems = new List<TaskItem>();
        }
    }
}
