using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Rigel.MVC.Controllers
{
    public class UserController : BaseController<UserController>
    {
        [HttpPost("/user/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            UserDto usr = await _userService.FindUser(username, password);
            if (usr == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username), 
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