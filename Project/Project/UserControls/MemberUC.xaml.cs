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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.UserControls
{
    /// <summary>
    /// Interaction logic for MemberUC.xaml
    /// </summary>
    public partial class MemberUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public MemberUC()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            lstPRO.ItemsSource = db.Managers.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Managers.Add(new Manager()
                {
                    UserName = txtUserName.Text,
                    Password = txtPass.Text,
                    Role = false,
                });
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm thành công", "Thành Công");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager manager = db.Managers.FirstOrDefault(x => x.UserName.Equals(txtUserName.Text));
                manager.UserName = txtUserName.Text;
                manager.Password = txtPass.Text;
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Sửa thành công", "Thành Công");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager manager = db.Managers.FirstOrDefault(x => x.UserName.Equals(txtUserName.Text));
                db.Managers.Remove(manager);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Xóa thành công", "Thành Công");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstPRO.ItemsSource = db.Managers.ToList().FindAll(x => x.UserName.Contains(txtSearch.Text));
        }

        private void lstPRO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager show = lstPRO.SelectedItem as Manager;

            if (show == null) return;
            txtUserName.Text = show.UserName;
            txtPass.Text = show.Password;
        }
    }
}
