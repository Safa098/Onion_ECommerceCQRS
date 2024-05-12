using SeinfeldApi.Application.Bases;

namespace SeinfeldApi.Application.Features.Auth.Exceptions
{
	public class EmailOrPasswordShouldNotBeException : BaseException
	{
		public EmailOrPasswordShouldNotBeException() : base("kullanıcı adı veya parola yanlış ")
		{

		}

	}
}
