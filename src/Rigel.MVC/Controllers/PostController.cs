using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Rigel.MVC.Controllers
{
    public class PostController : BaseController<PostController>
    {
        [HttpGet("/posts/{id}")]
        public async Task<IActionResult> GetPost([FromRoute] string id, [FromQuery] int page = 1) 
        {
            try {
            ViewBag.Post = await _postService.FindById(id);
            ViewBag.Messages = await _messageService.FindPostMessages(id, page);
            }catch (NotFoundException e) {
                TempData["err"] = e.Message;
                return Redirect("/error");
            }
            return View();
        }

        [Authorize]
        [HttpPost("/posts")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto) {
            await _postService.CreatePost(dto, HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
    }
}