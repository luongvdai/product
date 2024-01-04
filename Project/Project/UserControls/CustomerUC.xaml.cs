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
    /// Interaction logic for CustomerUC.xaml
    /// </summary>
    public partial class CustomerUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public CustomerUC()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            LstProvider.ItemsSource = db.Providers.ToList();
            lstCus.ItemsSource = db.Customers.ToList();
            txtCusId.Text = String.Empty;
            txtCusName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtProviderId.Text = String.Empty;
            txtProviderName.Text = String.Empty;
            txtProviderAddress.Text = String.Empty;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstProvider.ItemsSource = db.Providers.Where(x => x.ProviderName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

        }

        private void txtCustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstCus.ItemsSource = db.Customers.Where(x => x.CustomerName.ToLower().Contains(txtCustomerSearch.Text.ToLower())).ToList();
        }

        private void LstProvider_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Provider proselected = LstProvider.SelectedItem as Provider;
            if (proselected == null) return;
            txtProviderId.Text = proselected.ProviderId.ToString();
            txtProviderName.Text = proselected.ProviderName;
            txtProviderAddress.Text = proselected.Address;

        }

        private void lstCus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer cusSelected = lstCus.SelectedItem as Customer;
            if (cusSelected == null) return;
            txtCusId.Text = cusSelected.CustomerId.ToString();
            txtCusName.Text = cusSelected.CustomerName;
            txtPhone.Text = cusSelected.Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Provider _pro = new Provider()
                {
                    ProviderName = txtProviderName.Text,
                    Address = txtProviderAddress.Text,
                };
                db.Providers.Add(_pro);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm");
            }
            LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Provider _pro = db.Providers.FirstOrDefault(p => p.ProviderId == int.Parse(txtProviderId.Text));
                if (_pro == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa");
                }
                else
                {
                    _pro.ProviderName = txtProviderName.Text;
                    _pro.Address = txtProviderAddress.Text;
                    db.Providers.Update(_pro);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa");
            }
            LoadData();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Provider _pro = db.Providers.FirstOrDefault(p => p.ProviderId == int.Parse(txtProviderId.Text));
                if (_pro == null)
                {
                    MessageBox.Show("Không thể xóa");
                }
                else
                {
                    db.Providers.Remove(_pro);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "xóa");
            }
            LoadData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer _cus = new Customer()
                {
                    CustomerName = txtCusName.Text,
                    Phone = txtPhone.Text,
                };
                db.Customers.Add(_cus);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm");
            }
            LoadData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer _cus = db.Customers.FirstOrDefault(p => p.CustomerId == int.Parse(txtCusId.Text));
                if (_cus == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa");
                }
                else
                {
                    _cus.CustomerName = txtCusName.Text;
                    _cus.Phone = txtPhone.Text;
                    db.Customers.Update(_cus);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa");
            }
            LoadData();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer _cus = db.Customers.FirstOrDefault(p => p.CustomerId == int.Parse(txtCusId.Text));
                if (_cus == null)
                {
                    MessageBox.Show("Không thể xóa");
                }
                else
                {
                    db.Customers.Remove(_cus);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa");
            }
            LoadData();
        }
    }
}
