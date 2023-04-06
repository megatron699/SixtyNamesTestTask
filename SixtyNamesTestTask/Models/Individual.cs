using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixtyNamesTestTask.Models
{
	[Table("individuals")]
	internal class Individual
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("individual_id")]
		public long IndividualId { get; set; }
		[Column("first_name")]
		public string FirstName { get; set; }
		[Column("last_name")]
		public string LastName { get; set; }
		[Column("patronymic")]
		public string Patronymic { get; set; }
		[Column("gender")]
		public string Gender { get; set; }
		[Column("age")]
		public int Age { get; private set; }
		[Column("place_of_work")]
		public string PlaceOfWork { get; set; }
		[Column("country")]
		public string Country { get; set; }
		[Column("city")]
		public string City { get; set; }
		[Column("address")]
		public string Address { get; set; }
		[Column("email")]
		[EmailAddress]
		public string Email { get; set; }
		[Column("phone_number")]
		public string PhoneNumber { get; set; }
		[Column("date_of_birth")]
		public DateTime DateOfBirth { get; set; }

		public ICollection<Contract> Contracts;


		public Individual(DateTime dateOfBirth)
		{
			Contracts = new HashSet<Contract>();
			DateOfBirth = dateOfBirth;
			Age = CalculateAge();

		}

		private int CalculateAge()
		{
			var age = DateTime.Now.Year - DateOfBirth.Year;
			if (DateOfBirth > DateTime.Now.AddYears(-age))
			{
				age--;
			}
			return age;
		}
	}
}
