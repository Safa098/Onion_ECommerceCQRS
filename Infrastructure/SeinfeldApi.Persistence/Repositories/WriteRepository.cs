using Microsoft.EntityFrameworkCore;
using SeinfeldApi.Application.InterFaces.Repositories;
using SeinfeldApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
	{
		private readonly DbContext dbcontext;

		public WriteRepository(DbContext dbContext)
		{
			this.dbcontext = dbContext;
		}
		private DbSet<T> Table { get => dbcontext.Set<T>(); }

		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task AddRangeAsync(IList<T> entities)
		{
			await Table.AddRangeAsync(entities);
		}
		
		public async Task<T> UpdateAsync(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;                               //update işlemleri async olmaz kendi async methodumuzu kullanıcaz Run mwthodu
		}

		async Task IWriteRepository<T>.HardDeleteAsync(T entity)
		{
			await Task.Run(()=> Table.Remove(entity));
		}
	}
}
