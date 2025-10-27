using MotorRentalDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MotorRentalBusiness
{
    public class MotorbikeService
    {
        private readonly MotorRentalContext _context;

        public MotorbikeService()
        {
            _context = new MotorRentalContext();
        }

        // 🔹 Lấy danh sách tất cả xe
        public List<Motorbike> GetAllMotorbikes()
        {
            return _context.Motorbikes.AsNoTracking().ToList();
        }

        // 🔹 Thêm xe mới
        public void AddMotorbike(Motorbike bike)
        {
            _context.Motorbikes.Add(bike);
            _context.SaveChanges();
        }

        // 🔹 Cập nhật thông tin xe
        public void UpdateMotorbike(Motorbike bike)
        {
            _context.Motorbikes.Update(bike);
            _context.SaveChanges();
        }

        // 🔹 Xóa xe theo mã
        public void DeleteMotorbike(string bikeCode)
        {
            var b = _context.Motorbikes.FirstOrDefault(x => x.BikeCode == bikeCode);
            if (b != null)
            {
                _context.Motorbikes.Remove(b);
                _context.SaveChanges();
            }
        }

        // 🔹 Tìm kiếm xe theo tình trạng
        public List<Motorbike> FindByStatus(string status)
        {
            return _context.Motorbikes
                           .Where(m => m.Status.ToLower().Contains(status.ToLower()))
                           .AsNoTracking()
                           .ToList();
        }
    }
}
