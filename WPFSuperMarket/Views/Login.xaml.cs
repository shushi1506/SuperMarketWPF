using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSuperMarket.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public BackgroundWorker bw = new BackgroundWorker();

        private string _username { get; set; }
        private string _password { get; set; }

        public Login()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> input = e.Argument as List<string>;
            if (input[2].Equals("Login"))
            {
                if (!App.connectionController.TestConnection())
                {
                    e.Result = -1;
                    return;
                }
                e.Result = App.accountController.Login(input[0], input[1]) ? 1 : 0;
                Thread.Sleep(1000);

                return;
            }

            App.connectionController.InstallDatabase();
            e.Result = App.accountController.Login(input[0], input[1]) ? 1 : 0;
            Thread.Sleep(1000);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                txtWarning.Content = "Đã hủy!";
            }

            else if (!(e.Error == null))
            {
                txtWarning.Content = "Có lỗi";
            }
            else
            {
                if ((int)e.Result == 1)
                {
                    txtWarning.Content = "Đăng nhập Thành công.";
                    Mouse.OverrideCursor = null;
                    //txtBxuserName.IsEnabled = true;
                    txtBxuserName.IsReadOnly = false;
                    passBxPassword.IsEnabled = true;
                    btnLogin.IsEnabled = true;

                    App.ShowMainWindow(this);
                    return;
                }
                if ((int)e.Result == 0)
                {
                    txtWarning.Content = "Mật khẩu không đúng.";
                    //txtBxuserName.IsEnabled = true;
                    txtBxuserName.IsReadOnly = false;
                    txtBxuserName.BorderBrush = Brushes.Red;
                    passBxPassword.IsEnabled = true;
                    passBxPassword.BorderBrush = Brushes.Red;
                    btnLogin.IsEnabled = true;
                    Mouse.OverrideCursor = null;
                }

                if ((int)e.Result == -1)
                {
                    txtWarning.Content = "Không có kết nối.";
                    btnLogin.Content = "CÀI ĐẶT";
                    //txtBxuserName.IsEnabled = true;
                    txtBxuserName.IsReadOnly = false;
                    passBxPassword.IsEnabled = true;
                    btnLogin.IsEnabled = true;
                    Mouse.OverrideCursor = null;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtWarning.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtWarning.Content = "Đang xử lý...";
            txtWarning.Visibility = Visibility.Visible;
            //txtBxuserName.IsEnabled = false;
            txtBxuserName.IsReadOnly = true;
            txtBxuserName.Background = Brushes.Transparent;
            passBxPassword.IsEnabled = false;
            btnLogin.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;

            if (!bw.IsBusy)
            {
                if (btnLogin.Content.Equals("CÀI ĐẶT"))
                {
                    bw.RunWorkerAsync(new List<string>() { txtBxuserName.Text, passBxPassword.Password, "Setup" });
                    return;
                }
                bw.RunWorkerAsync(new List<string>() { txtBxuserName.Text, passBxPassword.Password, "Login" });
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void txtBxuserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBxuserName.BorderBrush = Brushes.White;
        }

        private void passBxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passBxPassword.BorderBrush = Brushes.White;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
