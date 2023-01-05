using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Models
{
	public class MyDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=OST25101825D;Initial Catalog=MyDB;Integrated Security=SSPI");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PatientInfoData>().HasKey(p => p.ID);
		}

		public DbSet<PatientInfoData> PatientInfo { get; set; }
	}
}