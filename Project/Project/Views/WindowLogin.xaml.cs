using BusinessObject;
using BusinessObject.Models;
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
using System.Windows.Shapes;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        clothesManagerContext db = new clothesManagerContext();

        public WindowLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager manager = db.Managers.FirstOrDefault(x => x.UserName.Equals(txtUserName.Text) && x.Password.Equals(txtPassword.Password));
                if (manager != null)
                {
                    MainWindow main = new MainWindow(manager.Role);
                    this.Close();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại tài khoản hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đăng nhập");
                throw;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            this.Close();
            register.ShowDialog();
        }
    }
}
