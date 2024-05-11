using Microsoft.EntityFrameworkCore;

namespace Test.Web.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
            
        }
        // Products tablodaki isim farklı bir isim kullanmak istersen
        //entity nesnesine gidip[Table("Products")]; demen lazım custom isim vermek için detaylı bakarsın


        public DbSet<Product> Products { get; set; }
    }
}
