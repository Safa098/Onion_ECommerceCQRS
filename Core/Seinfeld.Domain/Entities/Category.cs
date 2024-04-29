using SeinfeldApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Domain.Entities
{
	public class Category : EntityBase, IEntityBase
	{
		public Category()
		{

		}
		public Category(int patentId, string name, int priorty)
		{
			ParentId = patentId;
			Name = name;
			Priorty = priorty;
		}
		public  int ParentId { get; set; }
		public  string Name { get; set; }
		public  int Priorty { get; set; }
		public ICollection<Detail> Details { get; set; }//bire çok ilişki (category ve detail)
		public ICollection<Product> Products { get; set; }//çoka çok ilişkilendirme (category ve product)
	}
}
