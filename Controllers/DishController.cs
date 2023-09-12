using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context; 

    public DishController(ILogger<DishController> logger, MyContext context) 
    {
        _logger = logger;
        _context = context; 
    }



//route for viewing all dishes
    [HttpGet("dishes")]
    public IActionResult AllDishes()
    {
        List<Dish> Dishes = _context.Dishes.Include(d => d.Creator).ToList();
        return View(Dishes); //do not have to indicate all dishes since its the same, but passing in our dishes model
    }



//route for creating a new dish
    [HttpGet("dishes/new")]
    public ViewResult NewDish() 
    {
        List<Chef> EveryChef = _context.Chefs.ToList(); //adding viewbad because need to display chefs in new dish form
        ViewBag.EachChef = EveryChef;  
        return View(); //View Results because this will only render the empty form
    }



//route that will post/create new dish into our DB
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid) //confirming this passes our validations
        {
        List<Chef> EveryChef = _context.Chefs.ToList(); //adding viewbad because need to display chefs in new dish form
        ViewBag.EachChef = EveryChef; 
        return View("NewDish");
        }
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("AllDishes");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
