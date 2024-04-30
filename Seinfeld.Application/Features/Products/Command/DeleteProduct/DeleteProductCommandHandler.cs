﻿using MediatR;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Products.Command.DeleteProduct
{
	public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}

		public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
			product.IsDeleted = false;

			await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
			await unitOfWork.SaveAsync();
		}
	}
}