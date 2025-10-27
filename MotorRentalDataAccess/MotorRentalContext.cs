using Microsoft.EntityFrameworkCore;

namespace MotorRentalDataAccess
{
    public class MotorRentalContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ✅ Chuỗi kết nối LocalDB
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=DBMotorRental;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
