using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRentalDataAccess
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        // Quan hệ 1-n với Rental
        public ICollection<Rental> Rentals { get; set; }
    }
}

