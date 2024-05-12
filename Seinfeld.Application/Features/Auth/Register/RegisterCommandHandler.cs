using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SeinfeldApi.Application.Bases;
using SeinfeldApi.Application.Features.Auth.Rules;
using SeinfeldApi.Application.InterFaces.AutoMapper;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Auth.Register
{
	public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
	{
		private readonly AuthRules authRules;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;

		public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager,RoleManager<Role>roleManager , IMapper mapper ,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork,httpContextAccessor) //bunlar için field oluşturmaya gerek kalmadan base'e yollayabilirim
		{
			this.authRules = authRules;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}
        
            
        
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
		{
			await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

			User user = mapper.Map<User, RegisterCommandRequest>(request);
			user.UserName = request.Email;
			user.SecurityStamp = Guid.NewGuid().ToString();
			IdentityResult result = await userManager.CreateAsync(user,request.Password);
            if (result.Succeeded)
            {
				if (!await roleManager.RoleExistsAsync("User"))
					await roleManager.CreateAsync(new Role
					{
						Id=Guid.NewGuid(),
						Name = "User",
						NormalizedName = "USER",
						ConcurrencyStamp = Guid.NewGuid().ToString(),

					});
				await userManager.AddToRoleAsync(user, "user");

                
                    
                
            }
			return Unit.Value;
        }

	}
}
