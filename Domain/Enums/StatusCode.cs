using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rofel.Domain.Enums
{
	public enum StatusCode
	{
		EntityNotFound,
		UserNotFound,
		OK = 200,
		InternalServerError = 500
	}
}
