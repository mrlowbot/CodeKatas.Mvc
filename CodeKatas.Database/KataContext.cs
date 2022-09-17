using Microsoft.EntityFrameworkCore;

namespace CodeKatas.Database
{
    public class KataContext : DbContext
    {        
        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public KataContext(DbContextOptions options) : base(options)
        {

        }

    }
}
