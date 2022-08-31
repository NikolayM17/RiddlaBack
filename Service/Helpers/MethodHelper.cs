using System.Runtime.CompilerServices;

namespace Service.Helpers
{
	public static class MethodHelper
	{
		public static string GetCurrentMethodName([CallerMemberName] string method = "")
		{
			return method;
		}
	}
}
