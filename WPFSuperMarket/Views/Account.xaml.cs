using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSuperMarket.Models;
using System.Globalization;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : UserControl
    {
        /// <summary>
        /// Địa chỉ ảnh đại diện trong thư mục chương trình
        /// </summary>
        private string AccountPicturePath { get; set; }

        public Account()
        {
            InitializeComponent();
            CheckPerMission();
            btnAddAccount_Cancel.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccountTable();
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            presentationSource.ContentRendered += PresentationSource_ContentRendered;
            ((TableView)gridControl1.View).BestFitColumns();
        }

        private void PresentationSource_ContentRendered(object sender, EventArgs e)
        {
            ((TableView)gridControl1.View).BestFitColumns();
        }

        /// <summary>
        /// Sử lý sự kiện click chuột vào bảng Account
        /// </summary>
        /// 
        //Cấp Quyền Hạn
        private void CheckPerMission()
        {
            try
            {
                Models.Account account = App.accountController.Account;
                if (account.Admin.HasValue && account.Admin.Value == 1)
                {
                    btnAddAccount.IsEnabled = true;
                    btnDeleteAccount.IsEnabled = true;
                    btnSaveChangeAccount.IsEnabled = true;
                }
                if (account.Admin.HasValue && account.Admin.Value == 2)
                {
                    btnAddAccount.IsEnabled = false;
                    btnDeleteAccount.IsEnabled = false;
                    btnSaveChangeAccount.IsEnabled = false;
                    btnAddAccount_Cancel.IsEnabled = false;
                    btnSaveChangeAccount_Cancel.IsEnabled = false;
                }
               
            }
            catch { }
        }
        private void gridControl1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AccountTableModel item = (AccountTableModel)gridControl1.SelectedItem;
                Models.Account account = App.accountController.GetAccountById(item.Id);
                txtAccountId.Text = account.Id.ToString();
                txtAccountCreateTime.Text = account.CreateTime.ToString("dd/MM/yyyy HH:mm:ss");
                txtAccountCreatedBy.Text = (account.ParentAccount != null) ? account.ParentAccount.Name : "";
                txtAccountUsername.Text = account.Username;
                txtAccountEmail.Text = account.Email;
                txtAccountIdCard.Text = account.IdCard;
                txtAccountPhone.Text = account.Phone;
                txtAccountDetail.Text = account.Detail;
                txtAccountName.Text = account.Name;
                //*********//
                if (account.Admin.HasValue && account.Admin.Value == 2)
                {
                    _comboboxquyenhan.SelectedIndex = 0;
                }
                if (account.Admin.HasValue && account.Admin.Value == 3)
                {
                    _comboboxquyenhan.SelectedIndex = 1;
                }

                if (account.Admin.HasValue && account.Admin.Value == 4)
                {
                    _comboboxquyenhan.SelectedIndex = 2;
                }
                //*********//
                try
                {
                    imageAccountPicture.EditValue = System.IO.File.ReadAllBytes(App.BaseImageDirectory + account.Picture);
                }
                catch (Exception ex)
                {
                    imageAccountPicture.EditValue = System.IO.File.ReadAllBytes(App.DefaultAccountImagePath);
                }

                if (account.Admin.HasValue && account.Admin.Value == 1)
                {
                    btnSetAdmin.Visibility = Visibility.Hidden;
                    btnUnSetAdmin.Visibility = Visibility.Visible;
                }
                else
                {
                    btnSetAdmin.Visibility = Visibility.Visible;
                    btnUnSetAdmin.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào khung thông tin bởi người sử dụng
        /// </summary>
        private string ValidateAccountInformationsWithoutPassword
        {
            get
            {
                string warning = "";

                if (String.IsNullOrWhiteSpace(txtAccountUsername.Text) || txtAccountUsername.Text.Length < 5)
                {
                    warning += "Tên tài khoản có độ dài tối thiểu 5 ký tự." + '\n';
                }

                if (String.IsNullOrWhiteSpace(txtAccountEmail.Text))
                {
                    warning += "Vui lòng nhập Thư điện tử." + '\n';
                }
                if (String.IsNullOrWhiteSpace(txtAccountName.Text))
                {
                    warning += "Vui lòng nhập Họ tên." + '\n';
                }
                if (String.IsNullOrWhiteSpace(txtAccountIdCard.Text))
                {
                    warning += "Vui lòng nhập Số Chứng minh Nhân dân." + '\n';
                }
                if (String.IsNullOrWhiteSpace(_comboboxquyenhan.Text))
                {
                    warning += "Vui lòng chọn quyền hạn." + '\n';
                }
                return warning;
            }
        }

        /// <summary>
        /// Đổ dữ liệu từ cơ sở dữ liệu vào bảng Account
        /// Đồng thời ảnh hưởng đến sự kiện gridControl1_SelectedItemChanged, khiến dữ liệu đổ vào
        /// khung chi tiết
        /// </summary>
        private void LoadAccountTable()
        {
            ClearAccountInformations();
            DataContext = new DataSource();
            ((TableView)gridControl1.View).BestFitColumns();

        }
        
        /// <summary>
        /// Xóa thông tin account trong khung thông tin.
        /// </summary>
        private void ClearAccountInformations()
        {
            imageAccountPicture.Clear();
            txtAccountId.Text = "";
            txtAccountCreateTime.Text = "";
            txtAccountCreatedBy.Text = "";
            txtAccountUsername.Text = "";
            txtAccountEmail.Text = "";
            txtAccountIdCard.Text = "";
            txtAccountPhone.Text = "";
            txtAccountDetail.Text = "";
            txtAccountName.Text = "";
            _comboboxquyenhan.Text = null;
            btnSetAdmin.Visibility = Visibility.Hidden;
            btnUnSetAdmin.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Thêm tài khoản
        /// </summary>
        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            /// Sử lý khi lần đầu ấn nút Tạo mới
            if (btnAddAccount.Content.Equals("Tạo mới"))
            {
                txtAccountUsername.IsEnabled = true;
                txtAccountEmail.IsEnabled = true;
                btnSaveChangeAccount.IsEnabled = false;
                btnAddAccount.Content = "Hoàn tất";
                btnChangePasswordAccount.IsEnabled = false;
                txtAccountHashedPassword.IsEnabled = true;
                btnDeleteAccount.IsEnabled = false;
                btnAddAccount_Cancel.Visibility = Visibility.Visible;
                btnSaveChangeAccount_Cancel.IsEnabled = false;

                ClearAccountInformations();
                return;
            }

            string warning = ValidateAccountInformationsWithoutPassword;
            if (String.IsNullOrWhiteSpace(txtAccountHashedPassword.Text) || txtAccountHashedPassword.Text.Length < 6)
            {
                warning += "Mật khẩu có độ dài tối thiểu 6 ký tự." + '\n';
            }
            if (!warning.Equals(""))
            {
                MessageBox.Show(
                    warning, 
                    "Thêm mới Tài khoản", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            /// Sử lý khi ấn nút Hoàn tất - Tạo mới 2
            Models.Account account = new Models.Account();
            account.AccountId = App.accountController.Account.Id;
            account.Username = txtAccountUsername.Text;
            account.HashedPassword = txtAccountHashedPassword.Text;
            account.Email = txtAccountEmail.Text;
            account.Phone = txtAccountPhone.Text;
            account.IdCard = txtAccountIdCard.Text;
            account.Name = txtAccountName.Text;
            account.Detail = txtAccountDetail.Text;
            account.Picture = AccountPicturePath;
            if(_comboboxquyenhan.Text=="Quản Lý")
            {
                account.Admin = 2;
            }
            if(_comboboxquyenhan.Text=="Nhân Viên")
            {
                account.Admin = 3;
            }
            if (_comboboxquyenhan.Text == "Thủ Kho")
            {
                account.Admin = 4;
            }
            if (App.accountController.Add(account))
            {
                MessageBox.Show(
                    "Thêm mới thành công", 
                    "Thêm mới Tài khoản", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(
                    "Thêm mới thất bại", 
                    "Thêm mới Tài khoản", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }

            txtAccountHashedPassword.IsEnabled = false;
            txtAccountHashedPassword.Text = "";
            btnAddAccount.Content = "Tạo mới";
            btnAddAccount.IsEnabled = true;

            txtAccountUsername.IsEnabled = false;
            txtAccountEmail.IsEnabled = false;
            btnChangePasswordAccount.IsEnabled = true;
            btnSaveChangeAccount.IsEnabled = true;
            btnDeleteAccount.IsEnabled = true;
            btnAddAccount_Cancel.Visibility = Visibility.Hidden;
            btnSaveChangeAccount_Cancel.IsEnabled = true;

            LoadAccountTable();
        }

        /// <summary>
        /// Hủy thêm tài khoản
        /// </summary>
        private void btnAddAccount_Cancel_Click(object sender, RoutedEventArgs e)
        {
            txtAccountHashedPassword.IsEnabled = false;
            txtAccountHashedPassword.Text = "";
            btnAddAccount.Content = "Tạo mới";
            btnAddAccount.IsEnabled = true;

            txtAccountUsername.IsEnabled = false;
            txtAccountEmail.IsEnabled = false;
            btnChangePasswordAccount.IsEnabled = true;
            btnSaveChangeAccount.IsEnabled = true;
            btnDeleteAccount.IsEnabled = true;
            btnAddAccount_Cancel.Visibility = Visibility.Hidden;
            btnSaveChangeAccount_Cancel.IsEnabled = true;

            LoadAccountTable();
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtAccountId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số tài khoản không hợp lệ", "Đổi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            /// Sử lý khi lần đầu ấn nút Đổi mật khẩu
            if (btnChangePasswordAccount.Content.Equals("Đổi mật khẩu"))
            {
                txtAccountHashedPassword.Clear();
                txtAccountHashedPassword.IsEnabled = true;

                btnChangePasswordAccount.Content = "Lưu thay đổi";
                btnChangePasswordAccount_Cancel.Visibility = Visibility.Visible;

                btnAddAccount.IsEnabled = false;
                btnSaveChangeAccount.IsEnabled = false;
                btnSaveChangeAccount_Cancel.IsEnabled = false;
                btnDeleteAccount.IsEnabled = false;

                return;
            }

            /// Kiểm tra mật khẩu
            if (String.IsNullOrWhiteSpace(txtAccountHashedPassword.Text) 
                || txtAccountHashedPassword.Text.Length < 6)
            {
                MessageBox.Show(
                    "Mật khẩu có độ dài tối thiểu 6 ký tự", 
                    "Đổi mật khẩu", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            /// Sử lý khi ấn nút Lưu thay đổi - Đổi mật khẩu 2
            if (App.accountController.ChangePassword(
                Convert.ToInt32(txtAccountId.Text), 
                txtAccountHashedPassword.Text))
            {
                MessageBox.Show(
                    "Đổi mật khẩu thành công", 
                    "Đổi mật khẩu", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(
                    "Đổi mật khẩu thất bại", 
                    "Đổi mật khẩu", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }

            txtAccountHashedPassword.IsEnabled = false;
            txtAccountHashedPassword.Clear();

            btnChangePasswordAccount.Content = "Đổi mật khẩu";
            btnChangePasswordAccount_Cancel.Visibility = Visibility.Hidden;

            btnAddAccount.IsEnabled = true;
            btnSaveChangeAccount.IsEnabled = true;
            btnSaveChangeAccount_Cancel.IsEnabled = true;
            btnDeleteAccount.IsEnabled = true;
        }

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtAccountId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số tài khoản không hợp lệ", 
                    "Xóa tài khoản", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }

            /// Hỏi lại có chắc xóa tài khoản không
            if (MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản: " + txtAccountUsername.Text,
                "Xóa tài khoản", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                if (App.accountController.Delete(Convert.ToInt32(txtAccountId.Text)))
                {
                    MessageBox.Show(
                        "Xóa tài khoản thành công", 
                        "Xóa tài khoản", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Xóa tài khoản thất bại", 
                        "Xóa tài khoản", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }

                LoadAccountTable();
            }
        }

        /// <summary>
        /// Hủy đổi mật khẩu
        /// </summary>
        private void btnChangePassword_Account_Cancel_Click(object sender, RoutedEventArgs e)
        {
            txtAccountHashedPassword.IsEnabled = false;
            txtAccountHashedPassword.Clear();

            btnChangePasswordAccount.Content = "Đổi mật khẩu";
            btnChangePasswordAccount_Cancel.Visibility = Visibility.Hidden;

            btnAddAccount.IsEnabled = true;
            btnSaveChangeAccount.IsEnabled = true;
            btnSaveChangeAccount_Cancel.IsEnabled = true;
            btnDeleteAccount.IsEnabled = true;
        }

        /// <summary>
        /// Sử lý khi thay đổi Ảnh đại diện. Lưu ảnh tạm vào thư mục chương trình.
        /// </summary>
        private void imageAccountPicture_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (imageAccountPicture.HasImage)
            {
                try
                {
                    AccountPicturePath = txtAccountId.Text + ".jpg";
                    try
                    {
                        System.IO.File.Delete(App.BaseImageDirectory + AccountPicturePath);
                    }
                    catch 
                    {
                       
                    }
                    System.IO.File.WriteAllBytes(
                        App.BaseImageDirectory + AccountPicturePath,
                        (byte[])imageAccountPicture.EditValue);

                    return;
                }
                catch (Exception ex)
                {
                }
            }

            //AccountPicturePath = "";
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản
        /// </summary>
        private void btnAccount_SaveChange_Click(object sender, RoutedEventArgs e)
        {
            /// Kiểm tra Id
            try
            {
                Convert.ToInt32(txtAccountId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số tài khoản không hợp lệ",
                    "Cập nhật tài khoản",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            string warning = ValidateAccountInformationsWithoutPassword;
            if (!warning.Equals(""))
            {
                MessageBox.Show(
                    warning,
                    "Cập nhật Tài khoản",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            Models.Account account = new Models.Account();
            account.Id = Convert.ToInt32(txtAccountId.Text);
            account.Name = txtAccountName.Text;
            account.Phone = txtAccountPhone.Text;
            account.Detail = txtAccountDetail.Text;
            account.IdCard = txtAccountIdCard.Text;
            AccountPicturePath = txtAccountId.Text + ".jpg";
            if (imageAccountPicture.HasImage)
            {
                try
                {
                   
                    try
                    {
                        System.IO.File.Delete(App.BaseImageDirectory + AccountPicturePath);
                    }
                    catch
                    {

                    }
                    System.IO.File.WriteAllBytes(
                        App.BaseImageDirectory + AccountPicturePath,
                        (byte[])imageAccountPicture.EditValue);


                }
                catch (Exception ex)
                {
                }
            }

            else { AccountPicturePath = ""; }
            account.Picture =  AccountPicturePath;

            if (!App.accountController.Update(account))
            {
                MessageBox.Show(
                    "Cập nhật thất bại",
                    "Cập nhật Tài khoản",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thành công",
                    "Cập nhật Tài khoản",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            LoadAccountTable();
        }

        /// <summary>
        /// Hủy thay đổi Loại Mặt hàng
        /// </summary>
        private void btnSaveChangeAccount_Cancel_Click(object sender, RoutedEventArgs e)
        {
            LoadAccountTable();
        }

        private void gridControl1_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            gridControl1_MouseDown(null, null);
        }

        private void btnSetAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAccountId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số Tài khoản không hợp lệ",
                    "Đặt làm Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Bạn có chắc chắn muốn đặt tài khoản làm Quản trị viên?",
                    "Đặt làm Quản trị viên",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (App.accountController.SetAdmin(Convert.ToInt32(txtAccountId.Text)))
                {
                    MessageBox.Show(
                    "Đặt làm Quản trị viên Thành công",
                    "Đặt làm Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Đặt làm Quản trị viên Thất bại",
                    "Đặt làm Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

                LoadAccountTable();
            }

        }

        private void btnUnSetAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAccountId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Mã số Tài khoản không hợp lệ",
                    "Hủy quyền Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy quyền Quản trị viên của tài khoản?",
                    "Hủy quyền Quản trị viên",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (App.accountController.UnSetAdmin(Convert.ToInt32(txtAccountId.Text)))
                {
                    MessageBox.Show(
                    "Bỏ quyền Quản trị viên Thành công",
                    "Hủy quyền Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Bỏ quyền Quản trị viên Thất bại",
                    "Hủy quyền Quản trị viên",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

                LoadAccountTable();
            }
        }
    }

    /// <summary>
    /// Dữ liệu cho bảng danh sách tài khoản
    /// </summary>
    public class DataSource
    {
        List<AccountTableModel> Accounts;

        public DataSource()
        {
            Accounts = App.accountController.ListAccountsTableModel;
        }

        public List<AccountTableModel> DataAccount { get { return Accounts; } }
    }
    public class StringToResource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Application.Current.FindResource(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class imageConvertAcount : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string k = value as string;
            if (k == null) return App.DefaultAccountImagePath;
            return App.BaseImageDirectory + k;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

