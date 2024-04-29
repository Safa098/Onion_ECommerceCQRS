using SeinfeldApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SeinfeldApi.Application.InterFaces.Repositories
{
	public interface IReadRepository<T> where T : class, IEntityBase , new()
	{
		Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			bool enableTracking = false);

		//null geçilebilmesinin sebebi ısdeleted olanları istediğimiz entityde alabiliriz. datetime'ı belli aralıklar vs sorgular daha rahat ve kolay olur.


		Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			bool enableTracking = false, int currentPage = 1,int pageSize =3);//mevcut sayfada gördüğüm ilk 3 veriyi alcam

		Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false);


			

		IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false); //üstte ki methodlar to list şeklinde olacağı için, list olarak görmek istemediklerimizi bunla yapıcaz

		Task<int> CountAsync(Expression<Func<T, bool>>? predicate= null);
	}
}
