using MotorRentalBusiness;
using MotorRentalDataAccess;
using System.Windows;

namespace MotorRentalApp
{
    public partial class MotorbikeWindow : Window
    {
        private readonly MotorbikeService _motorbikeService;

        public MotorbikeWindow()
        {
            InitializeComponent();
            _motorbikeService = new MotorbikeService();
            LoadData();
        }

        // 🔹 Load danh sách xe
        private void LoadData()
        {
            dgMotorbikes.ItemsSource = _motorbikeService.GetAllMotorbikes();
        }

        // 🔹 Khi chọn xe
        private void dgMotorbikes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgMotorbikes.SelectedItem is Motorbike selected)
            {
                txtBikeCode.Text = selected.BikeCode;
                txtModel.Text = selected.Model;
                txtBrand.Text = selected.Brand;
                cbStatus.Text = selected.Status;
            }
        }

        // 🔹 Thêm xe
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBike = new Motorbike
            {
                BikeCode = txtBikeCode.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                Status = cbStatus.Text
            };

            _motorbikeService.AddMotorbike(newBike);
            MessageBox.Show("Thêm xe mới thành công!");
            LoadData();
        }

        // 🔹 Sửa xe
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgMotorbikes.SelectedItem is not Motorbike selected)
            {
                MessageBox.Show("Hãy chọn xe cần sửa!");
                return;
            }

            selected.BikeCode = txtBikeCode.Text.Trim();
            selected.Model = txtModel.Text.Trim();
            selected.Brand = txtBrand.Text.Trim();
            selected.Status = cbStatus.Text;

            _motorbikeService.UpdateMotorbike(selected);
            MessageBox.Show("Cập nhật thông tin xe thành công!");
            LoadData();
        }

        // 🔹 Xóa xe
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgMotorbikes.SelectedItem is not Motorbike selected)
            {
                MessageBox.Show("Hãy chọn xe cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa xe này?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _motorbikeService.DeleteMotorbike(selected.BikeCode);
                MessageBox.Show("Đã xóa xe!");
                LoadData();
            }
        }

        // 🔹 Làm mới form
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtBikeCode.Clear();
            txtModel.Clear();
            txtBrand.Clear();
            cbStatus.SelectedIndex = -1;
            dgMotorbikes.SelectedItem = null;
            LoadData();
        }
    }
}
