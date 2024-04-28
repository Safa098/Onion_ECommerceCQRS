using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Persistence.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category category1 = new()
			{
				Id=1,
				Name="Elektrik",
				Priorty=1,
				ParentId=0,
				IsDeleted=false,
				CreatedDate=DateTime.Now,
			};
			Category category2 = new()
			{
				Id = 2,
				Name = "Moda",
				Priorty = 2,
				ParentId = 0,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			Category parent1 = new()//bu kısım kategorilerin içerisinde ki kategorileri temsil ediyor!
			{
				Id = 3,
				Name = "bilgisayar",
				Priorty=1,
				ParentId=1,
				IsDeleted=false,
				CreatedDate=DateTime.Now,
			};
			Category parent2 = new()//bu kısım kategorilerin içerisinde ki kategorileri temsil ediyor!
			{
				Id = 4,
				Name = "Kadın",
				Priorty = 1,
				ParentId = 2,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			builder.HasData(category1, category2,parent1,parent2);
		}
	}
}
