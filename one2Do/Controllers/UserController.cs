using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using one2Do.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


using one2Do.Models;

namespace one2Do.Controllers
{

    [Authorize] // To ensure only authenticated users can access actions within this controller
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly one2doDbContext _context;


        // Constructor to initialize the database context
        public UserController(one2doDbContext context, UserManager<User> userManager)
        {
            _context = context;
            this.userManager= userManager;
        }

        // Action to handle requests to the User's main page
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        // Action to handle requests to the user's To-Do list page
        public IActionResult Todo()
        {
            return View();
        }

       
    }
}