using Microsoft.EntityFrameworkCore;
using Trade_Pulse.Data;

namespace Trade_Pulse.Helpers
{
	public static class BuilderConfig
	{
		public static void InitDb(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}
