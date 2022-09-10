using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	public class UserController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
