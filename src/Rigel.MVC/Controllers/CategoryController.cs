using Microsoft.AspNetCore.Mvc;

namespace Rigel.MVC.Controllers
{
    public class CategoryController : BaseController<CategoryController> 
    {
        [HttpGet("/category/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] string id, [FromQuery] int page = 1)
        {
            ViewBag.Posts = await _postService.FindPostsByCategory(id, page);
            ViewBag.Category = await _categoryService.FindById(id);
            return View();
        }
    }
}