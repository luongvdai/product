using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for WarehouseUC.xaml
    /// </summary>
    public partial class WarehouseUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public WarehouseUC()
        {
            InitializeComponent();

            LoadData();
            List<Provider> lstProvider = db.Providers.ToList();
            txtProvider.ItemsSource = lstProvider;
            txtProvider.SelectedValuePath = "ProviderId";
        }
        public void LoadData() => LstPurchase.ItemsSource = db.Purchases.Include(p => p.Provider).ToList();
        public void AddPurchase(Purchase purchase)
        {
            if (purchase == null) return;
            db.Purchases.Add(purchase);
            db.SaveChanges();
        }
        public void AddOrderDetails(List<OrderDetail> orderDetails)
        {
            if (orderDetails.Count == 0) return;
            foreach (var item in orderDetails)
            {
                db.OrderDetails.Add(item);
            }
            db.SaveChanges();
        }
        public void RemovePurchase(Purchase purchase)
        {
            if (purchase == null) return;
            db.Purchases.Remove(purchase);
            db.SaveChanges();
        }
        public void RemoveOrderDetails(List<OrderDetail> orderDetails)
        {
            if (orderDetails.Count == 0) return;
            foreach (var item in orderDetails)
            {
                db.OrderDetails.Remove(item);
            }
            db.SaveChanges();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Order] off");
                AddPurchase(new Purchase()
                {
                    ProductId = 0,
                    SalePrice = int.Parse(txtPriceOut.Text),
                    ProductName = txtName.Text,
                    PurchaseDate = DateTime.Parse(txtDateIn.Text),
                    PurchasePrice = decimal.Parse(txtPriceIn.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                });
                LoadData();
                MessageBox.Show("Thêm thành công", "Thành công");
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
                Purchase _pur = db.Purchases.FirstOrDefault(p => p.ProductId == int.Parse(txtId.Text));
                if (_pur != null)
                {
                    _pur.ProductName = txtName.Text;
                    _pur.PurchasePrice = decimal.Parse(txtPriceIn.Text);
                    _pur.SalePrice = decimal.Parse(txtPriceOut.Text);
                    _pur.Quantity = int.Parse(txtQuantity.Text);
                    _pur.PurchaseDate = DateTime.Parse(txtDateIn.Text);
                    if(txtProvider.SelectedValue != null)
                        _pur.ProviderId = int.Parse(txtProvider.SelectedValue.ToString());
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa thành công", "Thành công");
                }

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
                Purchase show = LstPurchase.SelectedItem as Purchase;
                List<OrderDetail> orderDetail = db.OrderDetails.ToList().FindAll(x => x.ProductId == show.ProductId);
                RemoveOrderDetails(orderDetail);

                RemovePurchase(db.Purchases.ToList().Find(x => x.ProductId == show.ProductId));
                LoadData();
                MessageBox.Show("Xóa thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void LstPurchase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Purchase show = LstPurchase.SelectedItem as Purchase;

            if (show == null) return;
            txtId.Text = show.ProductId.ToString();
            txtName.Text = show.ProductName;
            txtPriceOut.Text = show.SalePrice.ToString();
            txtDateIn.Text = show.PurchaseDate.ToString();
            txtPriceIn.Text = show.PurchasePrice.ToString();
            txtQuantity.Text = show.Quantity.ToString();
            txtProvider.Text = show.Provider?.ProviderName? .ToString();

        }
    }
}
