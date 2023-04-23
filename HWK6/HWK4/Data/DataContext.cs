using HWK4.Models;
using Microsoft.EntityFrameworkCore;

namespace HW2Rest
{
    // create the context of the data in the directory
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
            public DbSet<Car> Cars { get; set; }
        }
}

