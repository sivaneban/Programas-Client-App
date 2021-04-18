using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataContext
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Customer>()
            .HasOne(c=> c.CustomerAddress)
            .WithOne(ad => ad.Customer)
            .HasForeignKey<Address>(ad => ad.CustomerId);

        }
    }
}
