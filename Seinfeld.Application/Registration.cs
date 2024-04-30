using Microsoft.Extensions.DependencyInjection;
using SeinfeldApi.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application
{
	public static class Registration
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();

			services.AddTransient<ExcepctionMiddleware>();
			services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(assembly));
		}
	}
}
