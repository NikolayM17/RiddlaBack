using Microsoft.AspNetCore.Mvc;

namespace Riddla.Controllers
{
	public class CatalogueController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
