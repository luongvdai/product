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
    /// Interaction logic for OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public OrderUC()
        {
            InitializeComponent();
            LoadDataOrd();
            LoadDataPRO();

        }

        public void LoadDataPRO() => lstPRO.ItemsSource = db.Purchases.Include(p => p.Provider).ToList();

        public void LoadDataOrd()
        {
            var obj = (from x in db.OrderDetails.Include(od => od.Order).Include(od => od.Product)
                       join y in db.Orders.Include(o => o.Customer) on x.OrderId equals y.OrderId
                       join z in db.Purchases.Include(p => p.Provider) on x.ProductId equals z.ProductId
                       select new
                       {
                           id = x.OrderDetailId,
                           name = db.Customers.FirstOrDefault(c => c.CustomerId == y.CustomerId).CustomerName ?? "",
                           nameP = z.ProductName,
                           dateout = y.OrderDate,
                           quantity = x.Quantity,
                           totalMoney = x.Quantity * z.SalePrice,
                       }).ToList();

            LstOrd.ItemsSource = obj;
            txtCustomer.ItemsSource = db.Customers.ToList();
            txtCustomer.SelectedValuePath = "CustomerId";
        }

        private void lstPRO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Purchase show = lstPRO.SelectedItem as Purchase;

            if (show == null) return;
            txtIdP.Text = show.ProductId.ToString();
            txtProductName.Text = show.ProductName;
        }

        public void addOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Purchase show = db.Purchases.Include(p => p.Provider).ToList().Find(x => x.ProductId == int.Parse(txtIdP.Text));
                if (show.Quantity - int.Parse(txtQuatity.Text) <= 0)
                {
                    MessageBox.Show("Không đủ hàng", "Lỗi");
                    return;
                }
                db.Purchases.Remove(show);

                db.Purchases.Add(new Purchase()
                {
                    ProductId = show.ProductId,
                    ProductName = show.ProductName,
                    PurchaseDate = show.PurchaseDate,
                    PurchasePrice = show.PurchasePrice,
                    ProviderId = show.ProviderId,
                    Quantity = show.Quantity - int.Parse(txtQuatity.Text),
                    SalePrice = show.SalePrice,
                });

                addOrder(new Order()
                {
                    CustomerId = int.Parse(txtCustomer.SelectedValue.ToString()),
                    OrderDate = DateTime.Now,
                });

                db.OrderDetails.Add(new OrderDetail()
                {
                    OrderId = db.Orders.ToList().Find(x => x.CustomerId == int.Parse(txtCustomer.SelectedValue.ToString())).OrderId,
                    ProductId = show.ProductId,
                    Quantity = int.Parse(txtQuatity.Text),
                });

                db.SaveChanges();
                LoadDataOrd();
                LoadDataPRO();
                MessageBox.Show("Xuất thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            var obj = (from x in db.OrderDetails.Include(od => od.Order).Include(od => od.Product)
                       join y in db.Orders.Include(o => o.Customer) on x.OrderId equals y.OrderId
                       join z in db.Purchases.Include(p => p.Provider) on x.ProductId equals z.ProductId
                       select new
                       {
                           id = x.OrderDetailId,
                           name = db.Customers.FirstOrDefault(c => c.CustomerId == y.CustomerId).CustomerName ?? "",
                           nameP = z.ProductName,
                           dateout = y.OrderDate,
                           quantity = x.Quantity,
                           totalMoney = x.Quantity * z.SalePrice,
                       }).ToList().FindAll(x => x.name.ToLower().Trim().Contains(txtSearch.Text.ToLower().Trim()));

            LstOrd.ItemsSource = obj;
        }

    }
}
