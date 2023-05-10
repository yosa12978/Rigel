using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Rigel.MVC.Controllers
{
    public class UserController : BaseController<UserController>
    {
        [HttpGet("/users/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id) 
        {
            try {
                ViewBag.User = await _userService.FindById(id);
            }catch(Exception e) {
                TempData["err"] = e.Message;
                return Redirect("/error");
            }
            return View();
        }
        [HttpPost("/signup")]
        public async Task<IActionResult> Signup([FromBody] CreateUserDto dto) 
        {
            try {
                UserDto res = await _userService.CreateUser(dto);
            } catch (Exception e) {
                ViewBag.Error = e.Message;
                return View();
            }
            return Redirect("/login");
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            UserDto usr = await _userService.FindUser(dto.username, dto.password);
            if (usr == null) {
                ViewBag.Error = "Invalid credentials";
                return View();
            }
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, usr.username), 
                new Claim(ClaimTypes.NameIdentifier, usr.id),
               // new Claim(ClaimTypes.Role, usr.Role), //todo fix this sh
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            return Redirect("/");
        }
    }
}