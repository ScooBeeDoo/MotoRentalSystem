using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // 👈 cần thêm dòng này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRentalDataAccess
{
    public class Motorbike
    {
        [Key] // 👈 đánh dấu đây là khóa chính
        public int BikeId { get; set; }

        public string BikeCode { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; } // "Available", "Rented", "Maintenance"

        // Quan hệ 1-n với Rental
        public ICollection<Rental> Rentals { get; set; }
    }
}
