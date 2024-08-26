using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        public User User { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "List Title")]
        public string Title { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }


        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        public List<TaskItem> TaskItems { get; set; }

 


        public ToDoList()
        {
            TaskItems = new List<TaskItem>();
        }

        public ToDoList(string title, string userId, int categoryId, Category category, string v, DateTime dueDate, bool isCompleted)
        {
            Title = title;
            UserId = userId;
            CategoryId = categoryId;
            Category = category;
            DueDate = dueDate;
            IsCompleted = isCompleted;
            TaskItems = new List<TaskItem>();
        }
    }
}
