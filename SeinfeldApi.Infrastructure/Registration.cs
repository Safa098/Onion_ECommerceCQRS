using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeinfeldApi.Infrastructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Infrastructure
{
	public static class Registration
	{
		public static void AddInFrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<TokenSettings>(configuration.GetSection("JWT"));
		}
	}
}
