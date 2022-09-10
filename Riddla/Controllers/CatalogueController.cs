using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	public class CatalogueController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
