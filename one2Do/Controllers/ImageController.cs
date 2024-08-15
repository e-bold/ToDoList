using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2Do.Data;
using one2Do.Models;

namespace one2Do.Controllers;

[Authorize]
public class ImageController : Controller
{
    private readonly one2doDbContext _context;
    private readonly UserManager<User> _userManager;

    public ImageController(one2doDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var images = await _context.Images.Where(i => i.UserId == userId).ToListAsync();
        return View(images);
    }


    [HttpPost]
    public async Task<IActionResult> Index(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var userId = _userManager.GetUserId(User);
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/images",
                fileName
            );

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new Image { UserId = userId, ImageUrl = $"/images/{fileName}", Name = file.FileName };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var image = await _context.Images.FindAsync(id);

        if (image != null)
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                image.ImageUrl.TrimStart('/')
            );

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}
