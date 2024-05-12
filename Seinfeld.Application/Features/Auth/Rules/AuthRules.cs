using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeinfeldApi.Application.Bases;
using SeinfeldApi.Application.Features.Auth.Exceptions;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Auth.Rules
{
	public class AuthRules :BaseRules
	{
		public Task UserShouldNotBeExist(User? user)
		{
			if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
                
            
        }
	}
}
