using Microsoft.Extensions.DependencyInjection;
using SeinfeldApi.Application.InterFaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Mapper
{
	public static class Registration
	{
		public static void AddCustomMapper(this IServiceCollection services)
		{
			services.AddSingleton<IMapper, AutoMapper.Mapper>();
		}
	}
}
