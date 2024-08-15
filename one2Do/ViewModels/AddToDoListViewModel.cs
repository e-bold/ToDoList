using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class AddToDoListViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; } = new SelectList(new List<Category>());

        public AddToDoListViewModel(IEnumerable<Category> categories)
        {
            Categories = new SelectList(categories, "Id", "Name");
        }

        public AddToDoListViewModel() { }
    }
}
