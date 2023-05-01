using Microsoft.Extensions.DependencyInjection;
using Rigel.EFCore.Data;
using Rigel.EFCore.Repositories;

namespace Rigel.EFCore 
{
    public static class Injection
    {
        public static IServiceCollection AddEFCoreRepositories(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<DatabaseContext>(options => 
                options.UseSqlite(connectionString, x => x.MigrationsAssembly("Rigel.Migrations")));
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }    
}