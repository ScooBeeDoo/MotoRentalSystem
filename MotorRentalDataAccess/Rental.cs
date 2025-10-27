using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorRentalDataAccess
{
    public class Rental
    {
        [Key] // ✅ Khóa chính
        public int RentalId { get; set; }

        [ForeignKey("Customer")] // ✅ Khóa ngoại tới Customer
        public int CustomerId { get; set; }

        [ForeignKey("Motorbike")] // ✅ Khóa ngoại tới Motorbike
        public int BikeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")] // ✅ Tránh cảnh báo precision
        public decimal TotalCost { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Motorbike Motorbike { get; set; }
    }
}
