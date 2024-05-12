using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Auth.Command.Login
{
	public class LoginCommandResponse
	{
		public string Token { get; set; }
		public object RefreshToken { get; set; }//süre belirtmicez çünkü veritabanında kayıtlı olcak zaten
		public DateTime Expiration { get; set; }//token sona erme süresi
	}
}
