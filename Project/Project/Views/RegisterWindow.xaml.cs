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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        clothesManagerContext db = new clothesManagerContext();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password.Equals(txtRePassword.Password) && db.Managers.All(x => !x.UserName.Equals(txtUserName.Text)))
                {
                    db.Managers.Add(new Manager()
                    {
                        UserName = txtUserName.Text,
                        Password = txtPassword.Password,
                        Role = false,
                    });
                    db.SaveChanges();
                    MessageBox.Show("Đăng ký thành công", "Thành Công");

                    OpenLogin();
                }

                MessageBox.Show("Có thế sai mật khẩu hoặc trùng tên đăng nhập", "Thất bại");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        private void OpenLogin()
        {
            WindowLogin login = new WindowLogin();
            this.Close();
            login.ShowDialog();

        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenLogin();
        }
    }
}
