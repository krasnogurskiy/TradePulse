using DAL.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Trade_Pulse.Helpers
{
	public static class BuilderConfig
	{
		public static void InitDb(this WebApplicationBuilder builder)
		{
			builder.Services.InitDbContext(builder.Configuration.GetConnectionString("DefaultConnection")!);
		}
	}
}
