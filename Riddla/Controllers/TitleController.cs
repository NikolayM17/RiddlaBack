using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Riddla.Service.Implementations;

namespace Controllers
{
	public class TitleController : Controller
	{
		private readonly TitleService _service = new TitleService();

		public async Task<IActionResult> Index(int id)
		{
			var result = await _service.GetEntityByIdAsync(id);

			return View(result.Data);
		}

		public IActionResult Search(Title title)
		{
			var result = _service.GetEntity(new Title { Name = title.Name });

			if (result.StatusCode == Riddla.Domain.Enums.StatusCode.OK)
			{
				return Redirect($"~/Title/Index/{result.Data.Id}");
			}
			else throw new Exception();
		}
	}
}
