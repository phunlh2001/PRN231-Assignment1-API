using BusinessObject.Helpers;
using BusinessObject.Object;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // connect to db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;database=PRN231_Assignment1");
            }
        }

        // create db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetUp();

            modelBuilder.Seed();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<TypeCustomer> TypeCustomers { get; set; }
    }
}
