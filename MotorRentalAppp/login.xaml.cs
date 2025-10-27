using MotorRentalBusiness;
using MotorRentalDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace MotorRentalApp
{
    public partial class Login : Window
    {
        private readonly CustomerService _customerService;

        public Login()
        {
            InitializeComponent();
            _customerService = new CustomerService();

            // ✅ Debug connection string để kiểm tra đang kết nối đúng DBMotorRental
            using var ctx = new MotorRentalContext();
            var conn = ctx.Database.GetDbConnection().ConnectionString;
            MessageBox.Show($"Đang kết nối đến:\n{conn}", "Debug Connection");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var phone = txtPhone.Text.Trim();
            var password = txtPassword.Password.Trim();

            // Kiểm tra người dùng nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tìm khách hàng theo số điện thoại
            var customer = _customerService.FindByPhone(phone);

            // Debug: Hiển thị thông tin để xác nhận dữ liệu thực tế trong DB
            if (customer == null)
            {
                MessageBox.Show($"Không tìm thấy tài khoản với số điện thoại: '{phone}'",
                                "Debug Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                MessageBox.Show($"DEBUG:\nDB Phone: '{customer.Phone}' (len={customer.Phone?.Length})\n" +
                                $"DB Pass: '{customer.Password}' (len={customer.Password?.Length})\n" +
                                $"Input Phone: '{phone}'\nInput Pass: '{password}'",
                                "Debug Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // ✅ So sánh mật khẩu đã trim để tránh khoảng trắng
            if (customer.Password != null && customer.Password.Trim() == password.Trim())
            {
                MessageBox.Show($"Chào mừng {customer.FullName}!", "Đăng nhập thành công",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai số điện thoại hoặc mật khẩu!",
                                "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
