using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixtyNamesTestTask.Models
{
	[Table("legal_entities")]
	internal class LegalEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("legal_entity_id")]
		public long LegalEntityId { get; set; }
		[Column("company_name")]
		public string CompanyName { get; set; }
		[Column("itn")]
		public string Itn { get; set; }
		[Column("psrn")]
		public string Psrn { get; set; }
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
		public ICollection<Contract> Contracts = new HashSet<Contract>();
	}
}
