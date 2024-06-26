﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Runtime.CompilerServices;
using SeinfeldApi.Application.Features.Products.Queries.GetAllProducts;
using SeinfeldApi.Application.Features.Products.Command.CreateProduct;
using SeinfeldApi.Application.Features.Products.Command.DeleteProduct;
using SeinfeldApi.Application.Features.Products.Command.UpdateProduct;

namespace SeinfeldApi.Apı.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator mediator;

		public ProductController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var response = await mediator.Send(new GetAllProductsQueryRequest());
			return Ok(response);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
	}
}
