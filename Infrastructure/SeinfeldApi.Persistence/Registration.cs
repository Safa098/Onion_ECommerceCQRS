﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeinfeldApi.Application.InterFaces.Repositories;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using SeinfeldApi.Persistence.Context;
using SeinfeldApi.Persistence.Repositories;
using SeinfeldApi.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Persistence
{
	public static class Registration   //her katmanın kendisi için registration katmanı olmalı configure işlemleri için
	{
		public static void AddPersistance(this IServiceCollection services,IConfiguration configuration)//IService collection a ek olarak çalışır,kendi içinde çalışan bir method olur dependency ınjection vs bunları build etmeden derlerken burası kendi başına çalışır olur.
		{
			services.AddDbContext<AppDbContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			//core katmanına erişmemiz gerektiğinde işe yarar.
			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
			services.AddScoped<IUnitOfWork,UnitOfWork>();
			services.
				AddIdentityCore<User>(opt =>
				{
					opt.Password.RequireNonAlphanumeric = false;//alfabetik numara girilmezse hata verir.
					opt.Password.RequiredLength = 2;
					opt.Password.RequireUppercase = false;
					opt.Password.RequireDigit = false;
					opt.SignIn.RequireConfirmedEmail = false;
				}).AddRoles<Role>().
				AddEntityFrameworkStores<AppDbContext>();
		}
	}
}
