using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using one2Do.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using one2Do.Data;  


namespace one2Do;


public class CategoriesController : Controller
{   
    public one2doDbContext context; 

    public CategoriesController(one2doDbContext dbContext)
    {
        context = dbContext;
    }

    [HttpGet]

    public IActionResult Index()
    {
       
        return View();
    }

 }
