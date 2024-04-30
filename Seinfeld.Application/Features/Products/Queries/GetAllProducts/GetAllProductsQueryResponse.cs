﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Features.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryResponse   //DTO VEYA VİEW MODELLARLA AYNI ŞEY
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
	}
}