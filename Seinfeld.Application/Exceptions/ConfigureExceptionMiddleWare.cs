using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Exceptions
{
	public static class ConfigureExceptionMiddleWare
	{
		public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExcepctionMiddleware>();
		}
	}
}
