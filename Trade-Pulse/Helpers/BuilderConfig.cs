using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Helpers;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Trade_Pulse.Helpers
{
    public static class BuilderConfig
    {
        public static void InitDb(this WebApplicationBuilder builder)
        {
            builder.Services.InitDbContext(builder.Configuration.GetConnectionString("DefaultConnection")!);
        }
        public static void InitRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void InitIdentity(this WebApplicationBuilder builder)
        {
            //builder.Services.AddAppIdentity();
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>().AddRoles<Role>();
        }

        public static void InitServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
        }

        public static void InitCookies(this WebApplicationBuilder builder)
        {
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(10);

                options.LoginPath = "/Auth";
            });
        }
        public static void InitAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
