using Microsoft.EntityFrameworkCore;
using SQLLiteDBTest.Model;

namespace SQLLiteDBTest.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=E:\gitClone\TMP2\SQLLiteDBTest\SQLLiteDBTest\Model\AppDB.db;");
        }

        public DbSet<Category> Category { get; set; }
    }
}
