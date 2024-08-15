using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using one2Do.ViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace one2Do.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly one2doDbContext _context;

        public TaskItemController(one2doDbContext context)
        {
            _context = context;
        }

        // GET: TaskItem/Create
        public IActionResult Create(int toDoListId)
        {
            var viewModel = new AddTaskItemViewModel
            {
                ToDoListId = toDoListId
            };
            return View(viewModel);
        }

        // POST: TaskItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTaskItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var taskItem = new TaskItem
                {
                    Description = viewModel.TaskDescription,
                    DueDate = viewModel.DueDate,
                    IsCompleted = viewModel.IsCompleted,
                    ToDoListId = viewModel.ToDoListId
                };

                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ToDoList");
            }

            return View(viewModel);
        }
    }
}
