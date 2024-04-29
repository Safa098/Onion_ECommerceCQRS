using SeinfeldApi.Application.InterFaces.Repositories;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Persistence.Context;
using SeinfeldApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext DbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public async ValueTask DisposeAsync()=> await DbContext.DisposeAsync(); //tek return varsa bu şekilde de kullanılabilir.
		

		public int save() => DbContext.SaveChanges();
		
		

		public async Task<int> SaveAsync() => await DbContext.SaveChangesAsync();

		IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(DbContext);

		IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(DbContext);
		
	}
}
