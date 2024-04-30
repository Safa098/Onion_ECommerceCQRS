using Microsoft.EntityFrameworkCore;
using SeinfeldApi.Domain.Entities;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Persistence.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() { }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
        public DbSet<Brand> Brands { get; set; }
		public DbSet<Detail> Details { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		//ara tablo oluşturmadık çünkü entity frame work tanıyıp otomatik olarak kuracaktır.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//tüm configuration dosyalarını otomtik olark bulmasını sağlıyor 

		}

		
	}
}
