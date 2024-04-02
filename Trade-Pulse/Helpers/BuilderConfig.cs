using DAL.Helpers;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
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
			builder.Services.AddScoped<IRoleRepository, RoleRepository>();
		}

	}
}
