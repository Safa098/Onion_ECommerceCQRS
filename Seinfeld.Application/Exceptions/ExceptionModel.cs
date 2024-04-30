using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeinfeldApi.Application.Exceptions
{
	public class ExceptionModel : ErrorStatusCode
	{
		public IEnumerable<string> Errors { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this); //Errors yazmak yerine this yazarsak da aynı olur tek şey olduğundan.
		}
	}
	public class ErrorStatusCode
	{
		public int StatusCode { get; set; }//Single Responsibility

	}
}
