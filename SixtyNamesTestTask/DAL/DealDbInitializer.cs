using SixtyNamesTestTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SixtyNamesTestTask.DAL
{
	internal class DealDbInitializer : DropCreateDatabaseAlways<DealDbContext>
	{
		protected override void Seed(DealDbContext context)
		{
			var individual1 = new Individual(DateTime.ParseExact("18-09-1998", "dd-MM-yyyy", null))
			{
				FirstName = "",
				LastName = "",
				Patronymic = "",
				Gender = "",
				PlaceOfWork = "",
				Country = "Россия",
				City = "Москва",
				Address = "",
				Email = "a.b@mail.ru",
				PhoneNumber = "+79758566555",
			};
			var individual2 = new Individual(DateTime.ParseExact("20-05-1953", "dd-MM-yyyy", null))
			{
				FirstName = "",
				LastName = "",
				Patronymic = "",
				Gender = "",
				PlaceOfWork = "",
				Country = "Россия",
				City = "Орлов",
				Address = "",
				Email = "c.d@mail.ru",
				PhoneNumber = "+79535788894"
			};
			var individual3 = new Individual(DateTime.ParseExact("14-06-1983", "dd-MM-yyyy", null))
			{
				FirstName = "",
				LastName = "",
				Patronymic = "",
				Gender = "",
				PlaceOfWork = "",
				Country = "Россия",
				City = "Москва",
				Address = "",
				Email = "e.f@mail.ru",
				PhoneNumber = "+79689677524"
			};
			var individual4 = new Individual(DateTime.ParseExact("17-07-1963", "dd-MM-yyyy", null))
			{
				FirstName = "",
				LastName = "",
				Patronymic = "",
				Gender = "",
				PlaceOfWork = "",
				Country = "Россия",
				City = "Санкт-Петербург",
				Address = "",
				Email = "g.h@mail.ru",
				PhoneNumber = "+79864445672"
			};
			var individual5 = new Individual(DateTime.ParseExact("25-08-1973", "dd-MM-yyyy", null))
			{
				FirstName = "",
				LastName = "",
				Patronymic = "",
				Gender = "",
				PlaceOfWork = "",
				Country = "Россия",
				City = "Орлов",
				Address = "",
				Email = "i.j@mail.ru",
				PhoneNumber = "+79420665599"
			};
			context.Individuals.AddRange(new List<Individual> { individual1, individual2, individual3, individual4, individual5 });

			var legalEntity1 = new LegalEntity()
			{
				CompanyName = "",
				Itn = "",
				Psrn = "",
				Country = "Россия",
				City = "Москва",
				Address = "",
				Email = "b.a@mail.ru",
				PhoneNumber = ""
			};
			var legalEntity2 = new LegalEntity()
			{
				CompanyName = "",
				Itn = "",
				Psrn = "",
				Country = "Россия",
				City = "Санкт-Петербург",
				Address = "",
				Email = "d.c@mail.ru",
				PhoneNumber = ""
			};
			var legalEntity3 = new LegalEntity()
			{
				CompanyName = "",
				Itn = "",
				Psrn = "",
				Country = "Италия",
				City = "Милан",
				Address = "",
				Email = "f.e@mail.ru",
				PhoneNumber = ""
			};
			var legalEntity4 = new LegalEntity()
			{
				CompanyName = "",
				Itn = "",
				Psrn = "",
				Country = "Россия",
				City = "Москва",
				Address = "",
				Email = "h.g@mail.ru",
				PhoneNumber = ""
			};
			var legalEntity5 = new LegalEntity()
			{
				CompanyName = "",
				Itn = "",
				Psrn = "",
				Country = "Испания",
				City = "Мадрид",
				Address = "",
				Email = "j.i@mail.ru",
				PhoneNumber = ""
			};
			context.LegalEntities.AddRange(new List<LegalEntity>() { legalEntity1, legalEntity2, legalEntity3, legalEntity4, legalEntity5 });

			var contract1 = new Contract()
			{
				Сounterparty = legalEntity1,
				AuthorizedPerson = individual4,
				ContractAmount = 60000,
				ContractStatus = ContractStatus.Valid,
				DateOfSigning = DateTime.ParseExact("14-03-2023", "dd-MM-yyyy", null)
			};
			var contract2 = new Contract()
			{
				Сounterparty = legalEntity2,
				AuthorizedPerson = individual3,
				ContractAmount = 40000,
				ContractStatus = ContractStatus.Valid,
				DateOfSigning = DateTime.ParseExact("14-03-2021", "dd-MM-yyyy", null)
			};
			var contract3 = new Contract()
			{
				Сounterparty = legalEntity1,
				AuthorizedPerson = individual2,
				ContractAmount = 20000,
				ContractStatus = ContractStatus.Valid,
				DateOfSigning = DateTime.ParseExact("02-02-2023", "dd-MM-yyyy", null)
			};
			var contract4 = new Contract()
			{
				Сounterparty = legalEntity5,
				AuthorizedPerson = individual4,
				ContractAmount = 60000,
				ContractStatus = ContractStatus.Valid,
				DateOfSigning = DateTime.ParseExact("14-03-2018", "dd-MM-yyyy", null)
			};
			var contract5 = new Contract()
			{
				Сounterparty = legalEntity1,
				AuthorizedPerson = individual1,
				ContractAmount = 45000,
				ContractStatus = ContractStatus.Valid,
				DateOfSigning = DateTime.ParseExact("14-03-2023", "dd-MM-yyyy", null),
			};
			context.Contracts.AddRange(new List<Contract>() { contract1, contract2, contract3, contract4, contract5 });

			context.SaveChanges();
			base.Seed(context);
		}
	}
}
