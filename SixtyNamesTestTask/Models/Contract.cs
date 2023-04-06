using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixtyNamesTestTask.Models
{
	[Table("contracts")]
	internal class Contract
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("contract_id")]
		public long ContractId { get; set; }
		[Column("contract_amount")]
		public int ContractAmount { get; set; }
		[Column("contract_status")]
		public string ContractStatus { get; set; }
		[Column("date_of_signing")]
		public DateTime DateOfSigning { get; set; }
		[Column("counterparty_id")]
		public virtual LegalEntity Сounterparty { get; set; }
		[Column("authorized_person_id")]
		public virtual Individual AuthorizedPerson { get; set; }
	}
}
