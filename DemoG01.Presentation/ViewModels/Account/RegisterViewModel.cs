using System.ComponentModel.DataAnnotations;

namespace DemoG01.Presentation.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "First Name is Required")]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is Required")]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "User Name is Required")]
		[MaxLength(50)]
		public string UserName { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }

		public bool IsAgree { get; set; }
	}
}
