using MotorRentalDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MotorRentalBusiness
{
    public class CustomerService
    {
        private readonly MotorRentalContext _context;

        public CustomerService()
        {
            _context = new MotorRentalContext();
        }

        // ✅ Lấy tất cả khách hàng
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.AsNoTracking().ToList();
        }

        // ✅ Thêm khách hàng mới
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        // ✅ Tìm khách hàng theo số điện thoại (đã xử lý trim & EF safe)
        public Customer? FindByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return null;

            var normalized = phone.Trim();
            return _context.Customers
                           .AsNoTracking()
                           .FirstOrDefault(c => EF.Functions.Like(c.Phone.Trim(), normalized));
        }

        // ✅ Cập nhật khách hàng
        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        // ✅ Xóa khách hàng theo mã
        public void DeleteCustomer(string customerCode)
        {
            var c = _context.Customers.FirstOrDefault(x => x.CustomerCode == customerCode);
            if (c != null)
            {
                _context.Customers.Remove(c);
                _context.SaveChanges();
            }
        }
    }
}
