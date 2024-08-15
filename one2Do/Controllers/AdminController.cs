using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;

namespace one2Do.Controllers;


public class AdminController : Controller
{
    private readonly UserManager<User> userManager;

    public AdminController(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }


    public async Task<IActionResult> ListUsers()
    {
        var users = await userManager.Users.ToListAsync();
        return View(users);
    }



    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        var isAdmin = await userManager.IsInRoleAsync(user, "Admin");
        if (isAdmin)
        {
            // If the user is an admin, prevent deletion
            return BadRequest("Admin users cannot be deleted.");
        }

        if (user == null)
        {
            return NotFound();
        }
        await userManager.DeleteAsync(user);
        return RedirectToAction("ListUsers");
    }
}
