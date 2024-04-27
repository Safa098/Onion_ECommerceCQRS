using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Domain.Common
{
	public class EntityBase:IEntityBase
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;//default olarak gelsin diye
		public bool IsDeleted { get; set; }=false;//default olarak gelsin diye
    }
}
