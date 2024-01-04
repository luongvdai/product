using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Project.ViewModels;
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
    /// Interaction logic for ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public ProductUC()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData() => lstPRO.ItemsSource = db.Purchases.Include(p => p.Provider).ToList();

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Purchase>? Data = db.Purchases.Include(p => p.Provider).ToList().FindAll(x => x.ProductName.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim()));


            lstPRO.ItemsSource = Data;
        }

        private void lstPRO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Purchase show = lstPRO.SelectedItem as Purchase;

            if (show == null) return;
            txtID.Text = show.ProductId.ToString();
            txtName.Text = show.ProductName;
            txtOutPrice.Text = show.SalePrice.ToString();
            txtQ.Text = show.Quantity.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Purchase _pur = db.Purchases.FirstOrDefault(p => p.ProductId == int.Parse(txtID.Text));
                if (_pur != null)
                {
                    _pur.ProductName = txtName.Text;
                    _pur.SalePrice = decimal.Parse(txtOutPrice.Text);
                    _pur.Quantity = int.Parse(txtQ.Text);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa thành công", "Thành công");
                }
                else MessageBox.Show("Không thành công");
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
                Purchase show = db.Purchases.ToList().Find(x => x.ProductId == int.Parse(txtID.Text));
                List<OrderDetail> orderDetail = db.OrderDetails.ToList().FindAll(x => x.ProductId == int.Parse(txtID.Text));
                foreach (var item in orderDetail)
                    db.OrderDetails.Remove((item));

                db.Purchases.Remove(show);

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Xóa thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
    }
}
