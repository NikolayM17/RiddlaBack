using Domain.Enums;
using Service.Helpers;

namespace Riddla.Domain.Helpers
{
	public class EnumHelper
	{
		public string GetTabTypeRu(TabType tab)
		{
			switch (tab)
			{
				case TabType.Reading:
					return "Читаю";
				case TabType.InPlans:
					return "В планах";
				case TabType.Finished:
					return "Прочитано";
				case TabType.Favorite:
					return "Любимые";
				case TabType.Postponed:
					return "Отложено";
				default:
					throw new ArgumentException(MethodHelper.GetCurrentMethodName());
			}
		}

		public string GetStatusOrigRu(StatusOriginal status)
		{
			switch (status)
			{
				case StatusOriginal.Ongoing:
					return "Онгоинг";
				case StatusOriginal.Discontinued:
					return "Выпуск прекращён";
				case StatusOriginal.Preview:
					return "Анонс";
				case StatusOriginal.Paused:
					return "Выпуск приостановлен";
				case StatusOriginal.Completed:
					return "Завершён";
				default:
					throw new ArgumentException(MethodHelper.GetCurrentMethodName());
			}
		}

		public string GetStatusTranslateRu(StatusTranslation status)
		{
			switch (status)
			{
				case StatusTranslation.Continues:
					return "Переводится";
				case StatusTranslation.Frozen:
					return "Заморожен";
				case StatusTranslation.Completed:
					return "Переведён";
				case StatusTranslation.Dropped:
					return "Нет переводчика";
				default:
					throw new ArgumentException(MethodHelper.GetCurrentMethodName());
			}
		}
	}
}
