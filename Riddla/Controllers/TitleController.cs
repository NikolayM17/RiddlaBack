using Domain.Entities;
using Domain.Entities.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riddla.Service.Implementations;
using Service.Implementations;

namespace Controllers
{
	public class TitleController : Controller
	{
		private readonly IBaseService<Title> _titleService = new TitleService();
		/*private readonly IBaseService<TitleComment> _commentService = new BaseService<TitleComment>();
		private readonly IBaseService<User> _userService = new UserService();
		private readonly IBaseService<Statistics> _statisticsService = new BaseService<Statistics>();*/

		public IActionResult /*async Task<IActionResult>*/ Index(int id)
		{
			/*var result = await _service.GetEntityByIdAsync(id);*/

			var result = _titleService.GetAllEntities().Data
				.Include(t => t.Ratings)
				.Include(t => t.Bookmarks)
				.Include(t => t.Chapters)
				.ThenInclude(c => c.ChapterComments)
				.ThenInclude(cc => cc.Statistics)
				.Include(t => t.TitleComments)
				.ThenInclude(tc => tc.User)
				.First(t => t.Id == id);

			/*return View(result.Data);*/

			return View(result);
		}

		public IActionResult Search(Title title)
		{
			var result = _titleService.GetEntity(new Title { Name = title.Name });

			if (result.StatusCode == Riddla.Domain.Enums.StatusCode.OK)
			{
				return Redirect($"~/Title/Index/{result.Data.Id}");
			}
			else throw new Exception();
		}

		[HttpPost]
		public async /*Task<*/IActionResult/*>*/ SendComment(string Text, string Id)
		{
			var result = _titleService.GetAllEntities();

			var title = result.Data
				.Include(t => t.TitleComments)
				.First(t => t.Id == int.Parse(Id));

			/*var titleComments = title.TitleComments;

			TitleComment titleComment = new()
			{
				Id = 20,
				Title = title,
				Date = DateTime.Now,
				Text = Text*//*,
				User = (await _userService.GetEntityByIdAsync(1)).Data,
				Statistics = (await _statisticsService.GetEntityByIdAsync(1)).Data*//*
			};*/

			/*var result2 = await _commentService.AddEntityAsync(titleComment);

			title.TitleComments.Add(titleComment);

			var result3 = await _titleService.UpdateEntityAsync(title);*/

			return Redirect($"~/Title/Index/{Id}");
		}
	}
}
