using MediatR;
using Microsoft.AspNetCore.Http;
using SeinfeldApi.Application.Bases;
using SeinfeldApi.Application.InterFaces.AutoMapper;
using SeinfeldApi.Application.InterFaces.UnitOfWorks;
using SeinfeldApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Products.Command.DeleteProduct
{
	public class DeleteProductCommandHandler:BaseHandler, IRequestHandler<DeleteProductCommandRequest,Unit>
	{
		

		public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor) //bunlar için field oluşturmaya gerek kalmadan base'e yollayabilirim
		{
			
		}

		public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
			product.IsDeleted = false;

			await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
			await unitOfWork.SaveAsync();
			return Unit.Value;
		}
	}
}
