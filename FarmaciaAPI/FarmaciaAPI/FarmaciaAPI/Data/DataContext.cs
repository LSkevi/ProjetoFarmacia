using Microsoft.EntityFrameworkCore;

namespace FarmaciaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Farmacia> Farmacias => Set<Farmacia>();
    }
}
