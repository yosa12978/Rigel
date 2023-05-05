using Microsoft.AspNetCore.Mvc;
using Rigel.Services.Interfaces;

namespace Rigel.MVC.Controllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        private IPostService postService = default!;
        private IMessageService messageService = default!;
        private ICategoryService categoryService = default!;
        private IUserService userService = default!;
        private ILogger<T> logger = default!;

        protected IPostService _postService => 
            postService ??= HttpContext.RequestServices.GetRequiredService<IPostService>();

        protected IMessageService _messageService =>
            messageService ??= HttpContext.RequestServices.GetRequiredService<IMessageService>();

        protected ICategoryService _categoryService =>
            categoryService ??= HttpContext.RequestServices.GetRequiredService<ICategoryService>();

        protected IUserService _userService =>
            userService ??= HttpContext.RequestServices.GetRequiredService<IUserService>();

        protected ILogger<T> _logger =>
            logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
    }
}