using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SeinfeldApi.Application.Exceptions;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeinfeldApi.Application.Beheviors;
using SeinfeldApi.Application.Features.Products.Rules;
using SeinfeldApi.Application.Bases;

namespace SeinfeldApi.Application
{
	public static class Registration
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();

			services.AddTransient<ExcepctionMiddleware>();
			services.AddrulesFromAsemblyContaining(assembly, typeof(BaseRules));
			services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(assembly));

			services.AddValidatorsFromAssembly(assembly);

			ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FludentValidationBehevior <,>));
		}
		private static IServiceCollection AddrulesFromAsemblyContaining(this IServiceCollection services,
			Assembly assembly,
			Type type)
		{
			var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type)&&type!=t).ToList();
			foreach (var item in types)
				services.AddTransient(item);

			return services;
                
            
        }
	}
}
