﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeinfeldApi.Application.Features.Auth.Command.Login;
using SeinfeldApi.Application.Features.Auth.Command.Register;

namespace SeinfeldApi.Apı.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator mediator;

		public AuthController(IMediator mediator)
        {
			this.mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterCommandRequest request)
		{
			await mediator.Send(request);
			return StatusCode(StatusCodes.Status201Created);
		}
		[HttpPost]
		
		public async Task<IActionResult> Login(LoginCommandRequest request)
		{
			var response =  await mediator.Send(request);
			return StatusCode(StatusCodes.Status200OK,response);
		}
	}
}
