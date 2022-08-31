using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace rofel.Service.Helpers
{
	public static class MethodHelper
	{
		public static string GetCurrentMethodName([CallerMemberName] string method = "")
		{
			return method;
		}
	}
}
