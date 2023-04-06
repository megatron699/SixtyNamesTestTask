using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SixtyNamesTestTask.Services
{
	internal class ReportService
	{
		internal void CreateReport(IQueryable individuals)
		{
			using (var fileStream = File.Create("..\\..\\report.json"))
			{
				JsonSerializer.Serialize(fileStream, individuals, new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
					WriteIndented = true,
					Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
				});
			}
		}
	}
}
