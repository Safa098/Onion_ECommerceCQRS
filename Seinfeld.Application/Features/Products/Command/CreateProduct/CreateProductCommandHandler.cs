using MediatR;
using Microsoft.AspNetCore.Http;
using SeinfeldApi.Application.Bases;
using SeinfeldApi.Application.Features.Products.Rules;
using SeinfeldApi.Application.InterFaces.AutoMapper;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Products.Command.CreateProduct
{
	public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
	{
		
		private readonly ProductRules productRules;

		public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor) //bunlar için field oluşturmaya gerek kalmadan base'e yollayabilirim
		{
			
			this.productRules = productRules;
		}
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount);


			IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
			await productRules.ProductTitleMustNotBeSame(products, request.Title);
            foreach (var item in products)
            {
                if (item.Title==request.Title)
                {
                    
                }
            }



            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
			if(await unitOfWork.SaveAsync() > 0)
			{
                foreach (var categoryId in request.CategoryIds)
                {
					await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
					{
						ProductId = product.Id,
						CategoryId = categoryId,
					});
					await unitOfWork.SaveAsync();
                }
				
            }
			return Unit.Value;
		}
	}
}
