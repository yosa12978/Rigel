using Microsoft.Extensions.DependencyInjection;
using Rigel.Helpers.Impl;
using Rigel.Helpers.Interfaces;

namespace Rigel.Helpers
{
    public static class Injection
    {
        public static IServiceCollection AddMd5PasswordHasher(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHelper, Md5Helper>();
            return services;
        } 
    }
}