using Microsoft.EntityFrameworkCore;

namespace TestCAP.StorageService.Models.Database
{
    public class StorageDbContext : DbContext
    {
        public string ConnStr { get; }

        public StorageDbContext(DbContextOptions options, string connStr) : base(options)
        {
            ConnStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnStr);
        }

        //public DbSet<Storage> Storages { get; set; }
    }
}
