using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodersLab.Mvc.Workshops.Models
{
    public class PersonModel
    {
		[Key]
		[DisplayName("ID")]
		public int Id { get; set; }

		[DisplayName("Imię")]
		[MinLength(3)]
		[MaxLength(255)]
		[Required]
		public string FirstName { get; set; }

		[DisplayName("Nazwisko")]
		[MinLength(3)]
		[MaxLength(255)]
		public string LastName { get; set; }

		[DisplayName("Nr telefonu")]
		[MinLength(4)]
		[MaxLength(15)]
		[Required]
		public string Phone { get; set; }

		[DisplayName("Adres E-mail")]
		[EmailAddress]
		[MaxLength(255)]
		public string Email { get; set; }

		[DisplayName("Data utworzenia")]
		[Required]
		public DateTime Created { get; set; }

		[DisplayName("Data modyfikacji")]
		[Required]
		public DateTime Updated { get; set; }

		public PersonModel()
		{
			var now = DateTime.Now;

			Created = now;
			Updated = now;
		}
	}
}
