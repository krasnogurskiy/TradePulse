using Microsoft.Extensions.DependencyInjection;
using DAL.Tools;
using DAL.Data;

namespace DAL.Helpers
{
	public static class InitIdentity
	{
		public static void AddAppIdentity(this IServiceCollection services)
		{
			services.AddIdentityCore<User>(options =>
			//services.AddIdentityCore<User>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 8;
			}).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<CustomIdentityErrorDescriber>();

		}
	}
}
