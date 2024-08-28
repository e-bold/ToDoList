using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using one2Do.ViewModels;

namespace one2Do.Controllers
{
    [Authorize]
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
            var viewModel = new TaskItemViewModel
            {
                ToDoListId = toDoListId
            };
            return View(viewModel);
        }

        // POST: TaskItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var taskItem = new TaskItem
                {
                    Description = viewModel.Description,
                    ToDoListId = viewModel.ToDoListId,
                    IsCompleted = viewModel.IsCompleted
                };

                _context.TaskItems.Add(taskItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "ToDoList", new { id = viewModel.ToDoListId });
            }
            return View(viewModel);
        }

        // GET: TaskItem/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            var viewModel = new TaskItemViewModel
            {
                Id = taskItem.Id,
                Description = taskItem.Description,
                ToDoListId = taskItem.ToDoListId,
                IsCompleted = taskItem.IsCompleted
            };

            return View(viewModel);
        }

        // POST: TaskItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItemViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var taskItem = await _context.TaskItems.FindAsync(id);
                if (taskItem == null)
                {
                    return NotFound();
                }

                taskItem.Description = viewModel.Description;
                taskItem.IsCompleted = viewModel.IsCompleted;

                _context.Update(taskItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "ToDoList", new { id = taskItem.ToDoListId });
            }
            return View(viewModel);
        }

        // GET: TaskItem/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _context.TaskItems
                .Include(t => t.ToDoList)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "ToDoList", new { id = taskItem?.ToDoListId });
        }


        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            taskItem.IsCompleted = !taskItem.IsCompleted;
            _context.Update(taskItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ToDoList", new { id = taskItem.ToDoListId });
        }
    }
}
