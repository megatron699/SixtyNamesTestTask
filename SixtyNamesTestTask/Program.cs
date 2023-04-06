using SixtyNamesTestTask.DAL;
using SixtyNamesTestTask.Services;
using System;
using System.Linq;

namespace SixtyNamesTestTask
{
	internal class Program
	{
		static void Main(string[] args)
		{

			using (var context = new DealDbContext())
			{
				context.Contracts.ToList();
			}
			while (true)
			{
				Console.WriteLine("Введите цифру и нажмите Enter:\r\n" +
				"1. Вывести сумму всех заключенных договоров за текущий год.\r\n" +
				"2. Вывести сумму заключенных договоров по каждому контрагенту из России.\r\n" +
				"3. Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000\r\n" +
				"4. Изменить статус договора на \"Расторгнут\" для физических лиц, у которых есть действующий договор, и возраст которых старше 60 лет включительно.\r\n" +
				"5. Создать отчет в формате JSON, содержащий ФИО, e-mail, моб. телефон, дату рождения физ. лиц, у которых есть действующие договора по компаниям, " +
				"расположенных в городе Москва.\r\n" +
				"0. Выход");
				var dbService = new DbService();
				switch (Console.ReadLine())
				{
					case "1":
						var sumByCurrentYear = dbService.GetSumByCurrentYear();

						Console.WriteLine($"Сумма всех заключенных контрактов за {DateTime.Now.Year} равна: {sumByCurrentYear} руб.");
						Console.WriteLine();
						break;
					case "2":
						var sumsByCounterpartysCountry = dbService.GetSumsByCounterpartysCountry();

						foreach (var sumByCounterparty in sumsByCounterpartysCountry)
						{
							Console.WriteLine(sumByCounterparty);
						}
						Console.WriteLine();
						break;
					case "3":
						var emailsBySumList = dbService.GetEmailsBySumAndLastDays();

						foreach (var email in emailsBySumList)
						{
							Console.WriteLine(email);
						}
						Console.WriteLine();
						break;
					case "4":
						var contractsToChange = dbService.GetContractsToChange();

						dbService.ChangeContractsStatus(contractsToChange);

						Console.WriteLine("Статусы договоров успешно обновлены!");
						Console.WriteLine();
						break;
					case "5":
						var individuals = dbService.GetIndividualsForReport();
						var reportService = new ReportService();

						reportService.CreateReport(individuals);

						Console.WriteLine("Отчёт успешно создан");
						Console.WriteLine();
						break;
					case "0":
						Exit();
						break;
					default:
						Console.WriteLine("Введена неправильная команда!");
						Console.WriteLine();
						break;
				}
			}
		}

		private static void Exit()
		{
			Environment.Exit(-1);
		}
	}
}

