using SeinfeldApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Domain.Entities
{
	public class Brand :EntityBase//Entity base zaten Ientitybase den miras aldığı için yazmamıza gerek yok.
	{
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
