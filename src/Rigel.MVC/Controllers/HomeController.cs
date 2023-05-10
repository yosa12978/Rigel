using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rigel.MVC.Models;

namespace Rigel.MVC.Controllers;

public class HomeController : BaseController<HomeController>
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.FindAll();
        _logger.LogInformation(categories[0].name);
        ViewBag.Categories = categories;
        return View();
    }
    
    [Route("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        if (TempData["err"] != null)
            ViewBag.Error = TempData["err"]!.ToString();
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
