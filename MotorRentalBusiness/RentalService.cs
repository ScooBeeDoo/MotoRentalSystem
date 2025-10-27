using MotorRentalDataAccess;
using System.Collections.Generic;
using System.Linq;

namespace MotorRentalBusiness
{
    public class RentalService
    {
        private readonly MotorRentalContext _context;

        public RentalService()
        {
            _context = new MotorRentalContext();
        }

        // ✅ Lấy danh sách tất cả đơn thuê
        public List<Rental> GetAllRentals()
        {
            return _context.Rentals
                .OrderByDescending(r => r.StartDate)
                .ToList();
        }

        // ✅ Tạo đơn thuê mới
        public void AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        // ✅ Tính tổng chi phí thuê xe (ví dụ dùng trong report)
        public decimal GetTotalRevenue()
        {
            return _context.Rentals.Sum(r => r.TotalCost);
        }

        // ✅ Xóa đơn thuê
        public void DeleteRental(int id)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalId == id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }
        }
    }
}
