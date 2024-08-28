using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2Do.Data;
using one2Do.Models;
using one2Do.Models.ToDoModels;
using one2Do.ViewModels;

namespace one2Do.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly one2doDbContext _context;
        private readonly UserManager<User> _userManager;

        public ToDoListController(one2doDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ToDoLists
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var lists = await _context.ToDoLists
                .Where(l => l.UserId == userId)
                .Include(l => l.TaskItems)
                .ToListAsync();

            var viewModel = lists.Select(l => new ToDoListViewModel
            {
                Id = l.Id,
                Title = l.Title,
                TaskItems = l.TaskItems.Select(t => new TaskItemViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    ToDoListId = t.ToDoListId
                }).ToList()
            }).ToList();

            return View(viewModel);
        }

        // GET: ToDoLists/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);
            var list = await _context.ToDoLists
                .Where(l => l.UserId == userId && l.Id == id)
                .Include(l => l.TaskItems)
                .FirstOrDefaultAsync();

            if (list == null)
                return NotFound();

            var viewModel = new ToDoListViewModel
            {
                Id = list.Id,
                Title = list.Title,
                TaskItems = list.TaskItems.Select(t => new TaskItemViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    ToDoListId = t.ToDoListId
                }).ToList()
            };

            return View(viewModel);
        }

        // GET: ToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoLists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                var list = new ToDoList
                {
                    Title = viewModel.Title,
                    UserId = userId
                };

                _context.ToDoLists.Add(list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ToDoLists/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);
            var list = await _context.ToDoLists
                .Where(l => l.UserId == userId && l.Id == id)
                .FirstOrDefaultAsync();

            if (list == null)
                return NotFound();

            var viewModel = new ToDoListViewModel
            {
                Id = list.Id,
                Title = list.Title
            };

            return View(viewModel);
        }

        // POST: ToDoLists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoListViewModel viewModel)
        {
            if (id != viewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var list = await _context.ToDoLists
                    .Where(l => l.Id == id)
                    .FirstOrDefaultAsync();

                if (list == null)
                    return NotFound();

                list.Title = viewModel.Title;

                _context.Update(list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ToDoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var userId = _userManager.GetUserId(User);
            var list = await _context.ToDoLists
                .Where(l => l.UserId == userId && l.Id == id)
                .Include(l => l.TaskItems)
                .FirstOrDefaultAsync();

            if (list == null)
                return NotFound();

            var viewModel = new ToDoListViewModel
            {
                Id = list.Id,
                Title = list.Title,
                TaskItems = list.TaskItems.Select(task => new TaskItemViewModel
                {
                    Id = task.Id,
                    Description = task.Description,
                    IsCompleted = task.IsCompleted
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: ToDoLists/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            var list = await _context.ToDoLists
                .Where(l => l.UserId == userId && l.Id == id)
                .Include(l => l.TaskItems) // Ensure that related TaskItems are loaded
                .FirstOrDefaultAsync();

            if (list == null)
                return NotFound();

            _context.ToDoLists.Remove(list);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
