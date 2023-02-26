using System;
using HWK4.Models;
using Microsoft.EntityFrameworkCore;

namespace HWK4.Data
{
	public class DataContext : DbContext
    {
		public DataContext(DbContextOptions<DataContext>options) : base(options)
		{
		}
		public DbSet<Storeitems> Storeitems { get; set; }
	}
}

