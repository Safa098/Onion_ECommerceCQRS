using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.InterFaces.Repositories
{
	public interface IWriteRepository<T> where T : class
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IList<T> entities);
		Task<T> UpdateAsync(T entity);
	
		Task HardDeleteAsync(T entity);// çok çok nadir kullanırız
		

	}
}
