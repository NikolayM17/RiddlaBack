using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;

namespace Controllers
{
	public class CatalogueController : Controller
	{
		private readonly IBaseService<Title> _service = new TitleService();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Search(string query)
		{
			/*	*/

			var result = _service.GetAllEntities();

			var titles = result.Data.Where(t => t.Name.Contains(query));

			return View(titles);
		}
	}
}
