using Bogus;
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
	public class DetailConfiguration : IEntityTypeConfiguration<Detail>
	{
		public void Configure(EntityTypeBuilder<Detail> builder)
		{
			Faker faker = new("tr");//yeni gelen özellik tr destekliyor
			Detail detail1 = new()
			{
				Id = 1,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CategoryId = 1,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};
			Detail detail2 = new()
			{
				Id = 2,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CategoryId = 1,
				CreatedDate = DateTime.Now,
				IsDeleted = true,
			};
			Detail detail3 = new()
			{
				Id = 3,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CategoryId = 1,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};
		}
	}
}
