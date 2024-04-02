using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Helpers
{
	public static class InitContext
	{
		public static void InitDbContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});
		}
	}
}
