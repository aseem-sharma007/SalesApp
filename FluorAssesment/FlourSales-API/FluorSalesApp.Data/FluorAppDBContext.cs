using FluorSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluorSalesApp.Data
{
    public class FluorAppDBContext : DbContext
    {
        public FluorAppDBContext(DbContextOptions<FluorAppDBContext> options) : base(options) { }

        public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
    }
}
