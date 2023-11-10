using Microsoft.EntityFrameworkCore;
using OrderManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) :base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TEST_DB;Trusted_Connection=True;MultipleActiveResultSets=true");
		}
		public DbSet<Order> Orders { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderLine>().HasKey(ol => ol.Id);
		}
	}
}
