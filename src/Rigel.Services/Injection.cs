using Microsoft.Extensions.DependencyInjection;
using Rigel.Helpers.Impl;
using Rigel.Helpers.Interfaces;
using Rigel.Services.Impl;
using Rigel.Services.Interfaces;

namespace Rigel.Helpers
{
    public static class Injection
    {
        public static IServiceCollection AddBasicServices(this IServiceCollection services)
        {
            //helpers
            services.AddTransient<IPasswordHelper, Md5Helper>();
            services.AddTransient<IIdGenerator, IdGenerator>();
            //services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            return services;
        } 
    }
}