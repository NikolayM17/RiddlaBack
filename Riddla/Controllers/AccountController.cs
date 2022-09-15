using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Entities.ViewModels;
using Riddla.Service.Implementations;

namespace Riddla.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _service = new UserService();

		[HttpGet]
		public async Task<IActionResult> IndexAsync(int id)
		{
			var result = await _service.GetEntityByIdAsync(id);

			if (result.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return View(result.Data);
			}

			throw new Exception();
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserViewModel model)
		{
			if (model.Password == model.PasswordConfirm)
			{
				var newUser = new User()
				{
					Name = model.Name,
					Email = model.Email,
					Password = model.Password
				};

				var result = await _service.AddEntityAsync(newUser);

				if (result.StatusCode == Riddla.Domain.Enums.StatusCode.OK)
				{
					return Redirect("~/User/Index/");
				}
				else throw new Exception();
			}

			throw new Exception();
		}

		public async Task<IActionResult> Login (UserViewModel model)
		{
			var user = new User()
			{
				Name = model.Name,
				Email = model.Email,
				Password = model.Password
			};

			var result = _service.GetEntity(user);

			if (result.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return Redirect($"~/User/Index");

				/*/{result.Data.Id}*/
			}

			/*throw new Exception();*/

			return null;
		}
	}
}
