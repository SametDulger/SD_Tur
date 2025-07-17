using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SDTur.Infrastructure.Data
{
    public class SDTurDbContextFactory : IDesignTimeDbContextFactory<SDTurDbContext>
    {
        public SDTurDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SDTurDbContext>();
            // Gerekirse connection stringi güncelleyin
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=SDTurDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true");
            return new SDTurDbContext(optionsBuilder.Options);
        }
    }
} 