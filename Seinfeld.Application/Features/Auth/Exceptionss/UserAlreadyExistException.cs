using SeinfeldApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Auth.Exceptions
{
	public class UserAlreadyExistException :BaseException
	{
		public UserAlreadyExistException(): base("böyle bi kullanıcı zaten var")
		{

		}
		
	}
}
