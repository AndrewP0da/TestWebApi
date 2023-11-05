using Microsoft.EntityFrameworkCore;
using TestWebApi.DB;
using TestWebApi.DB.Entities;
using TestWebApi.Menu;
using TestWebApi.Menu.Models;
using TestWebApi.Menu.Services;

namespace TestWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString,
                        assembly =>
                            assembly.MigrationsAssembly("TestWebApi.Migrations"))
            );

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Category, CategoryEntity>();
                cfg.CreateMap<CategoryEntity, Category>();
                cfg.CreateMap<MenuItem, MenuItemEntity>();
                cfg.CreateMap<MenuItemEntity, MenuItem>();
                cfg.CreateMap<MenuItemEntity, MenuItemResponse>();
            });

            services.AddScoped<IDbRepository, DbRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}
