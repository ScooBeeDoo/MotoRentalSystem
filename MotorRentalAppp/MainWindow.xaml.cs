using MotorRentalBusiness;
using MotorRentalDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MotorRentalApp
{
    public partial class MainWindow : Window
    {
        private readonly CustomerService _customerService;

        public MainWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            LoadData();
        }

        // 🔹 Hiển thị dữ liệu lên DataGrid
        private void LoadData()
        {
            dgCustomers.ItemsSource = _customerService.GetAllCustomers();
        }

        // 🔹 Khi chọn 1 dòng trong DataGrid
        private void dgCustomers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                txtCustomerCode.Text = selected.CustomerCode;
                txtFullName.Text = selected.FullName;
                txtPhone.Text = selected.Phone;
                txtPassword.Text = selected.Password;
            }
        }

        // 🔹 Thêm khách hàng
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCustomer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };

                _customerService.AddCustomer(newCustomer);
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadData();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm khách hàng!");
            }
        }

        // 🔹 Cập nhật khách hàng
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is not Customer selected)
            {
                MessageBox.Show("Hãy chọn khách hàng cần sửa!");
                return;
            }

            selected.CustomerCode = txtCustomerCode.Text.Trim();
            selected.FullName = txtFullName.Text.Trim();
            selected.Phone = txtPhone.Text.Trim();
            selected.Password = txtPassword.Text.Trim();

            _customerService.UpdateCustomer(selected);
            MessageBox.Show("Cập nhật thành công!");
            LoadData();
        }

        // 🔹 Xóa khách hàng
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is not Customer selected)
            {
                MessageBox.Show("Hãy chọn khách hàng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(selected.CustomerCode);
                MessageBox.Show("Đã xóa khách hàng!");
                LoadData();
            }
        }

        // 🔹 Làm mới form
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerCode.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            dgCustomers.SelectedItem = null;
            LoadData();
        }

        private void btnOpenMotorbike_Click(object sender, RoutedEventArgs e)
        {
            MotorbikeWindow mb = new MotorbikeWindow();
            mb.ShowDialog();
        }
    


    }
}
