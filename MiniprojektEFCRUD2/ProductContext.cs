using Microsoft.EntityFrameworkCore;

namespace MiniprojektEFCRUD2
{
    class ProductContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; Initial catalog=Product_Extended; User=sa;Password=myPassw0rd; MultipleActiveResultSets=True;");
        }
    }
}
