using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rigel.MVC.Models;

namespace Rigel.MVC.Controllers;

public class HomeController : BaseController<HomeController>
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await _categoryService.FindAll();
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
