using SixtyNamesTestTask.Models;
using System.Data.Entity;

namespace SixtyNamesTestTask.DAL
{
	internal class DealDbContext : DbContext
	{
		static DealDbContext()
		{
			Database.SetInitializer(new DealDbInitializer());
		}
		public DealDbContext() : base("DealDb")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("public");
			modelBuilder.Entity<Contract>();
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Individual> Individuals { get; set; }
		public DbSet<LegalEntity> LegalEntities { get; set; }
		public DbSet<Contract> Contracts { get; set; }
	}
}
