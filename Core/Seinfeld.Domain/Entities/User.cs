using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Domain.Entities
{
	public class User : IdentityUser<Guid> //user ları hangi tipde tutacağımızı seçiyoruz default int dir
	{
		public string FullName { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiryTime { get; set; }
	}
}
