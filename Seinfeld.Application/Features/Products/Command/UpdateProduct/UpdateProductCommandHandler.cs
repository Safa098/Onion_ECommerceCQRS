﻿using MediatR;
using SeinfeldApi.Application.InterFaces.AutoMapper;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Products.Command.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);
			var map = mapper.Map<Product,UpdateProductCommandRequest>(request);
			var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().
				GetAllAsync(x => x.ProductId == product.Id);
			await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
			{
				await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
				{
					CategoryId = categoryId,
					ProductId = product.Id
				});
			}
              

                await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
				await unitOfWork.SaveAsync();
            

        }
	}
}