using SixtyNamesTestTask.DAL;
using SixtyNamesTestTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace SixtyNamesTestTask.Services
{
	internal class DbService
	{
		private readonly DealDbContext _context = new DealDbContext();
		internal int GetSumByCurrentYear()
		{
			return _context.Database
				.SqlQuery<int>("SELECT SUM(contract_amount) " +
				"FROM contracts " +
				"WHERE date_part('year', date_of_signing) = date_part('year', CURRENT_DATE) ")
				.Single();
		}

		internal List<int> GetSumsByCounterpartysCountry()
		{
			return _context.Database
				.SqlQuery<int>("SELECT SUM(con.contract_amount) " +
				"FROM contracts AS con JOIN legal_entities AS le ON con.\"Сounterparty_LegalEntityId\"=le.legal_entity_id " +
				"WHERE le.country = 'Россия' " +
				"GROUP BY le.legal_entity_id").ToList();
		}

		internal List<string> GetEmailsBySumAndLastDays()
		{
			return _context.Database
				.SqlQuery<string>("SELECT i.email " +
				"FROM individuals AS i JOIN contracts AS con ON i.individual_id = con.\"AuthorizedPerson_IndividualId\" " +
				"WHERE con.contract_amount > 40000 AND con.date_of_signing > CURRENT_DATE - INTERVAL '30 day'").ToList();
		}

		internal IQueryable<Contract> GetContractsToChange()
		{
			return _context.Contracts
				.Where(c => c.AuthorizedPerson.Age > 60 && c.ContractStatus == ContractStatus.Valid);
		}

		internal void ChangeContractsStatus(IQueryable<Contract> contractsToChange)
		{
			foreach (var contract in contractsToChange)
			{
				contract.ContractStatus = ContractStatus.Terminated;
			}

			_context.SaveChanges();
		}

		internal IQueryable GetIndividualsForReport()
		{
			return _context.Contracts
				.Where(c => c.Сounterparty.City == "Москва" && c.ContractStatus == ContractStatus.Valid)
				.Join(
				_context.Individuals,
				c => c.AuthorizedPerson.IndividualId,
				i => i.IndividualId,
				(c, i) => new
				{
					lastName = i.LastName,
					firstName = i.FirstName,
					patronymic = i.Patronymic,
					email = i.Email,
					phoneNumber = i.PhoneNumber,
					dateOfBirth = i.DateOfBirth
				}
				)
				.Distinct();
		}
	}
}
