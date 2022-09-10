using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ViewModels
{
	public class UserViewModel : User
	{
		/*[DataType(DataType.Password)]
		[Required(ErrorMessage = "Подтвердите пароль")]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]*/
		public string? PasswordConfirm { get; set; }
	}
}
