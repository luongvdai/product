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
    /// Interaction logic for ReportUC.xaml
    /// </summary>
    public partial class ReportUC : UserControl
    {
        clothesManagerContext db = new clothesManagerContext();
        public ReportUC()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var obj = (from z in (from x in db.OrderDetails.Include(o => o.Order).Include(o => o.Product)
                                  join y in db.Purchases.Include(p => p.Provider) on x.ProductId equals y.ProductId
                                  select new
                                  {
                                      id = y.ProductId,
                                      name = y.ProductName,
                                      qOut = x.Quantity,
                                      Quanity = y.Quantity,
                                      moneyOut = y.SalePrice,
                                  }).ToList()
                       group z by z.id into list
                       select new
                       {
                           id = list.Key,
                           Name = list.FirstOrDefault(x => x.id == list.Key)?.name,
                           qOut = list.Sum(x => x.qOut),
                           moneyOut = list.Sum(x => x.qOut * list.FirstOrDefault(y => y.id == list.Key)?.moneyOut),
                           Quantityall = list.Sum(x => x.Quanity)
                       }).ToList();
            int? sln = 0;
            int? slb = 0;
            int? htk = 0;
            decimal? tl = 0;
            foreach (var item in obj)
            {
                sln += item.Quantityall + item.qOut;
                slb += item.qOut;
                htk += item.Quantityall;
                tl += item.moneyOut;

            }

            tbSLN.Text = sln.ToString();
            tbSLB.Text = slb.ToString();
            tbHTK.Text = htk.ToString();
            tbTL.Text = tl.ToString();
            lstdata.ItemsSource = obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = (from z in (from x in db.OrderDetails.Include(o => o.Order).Include(o => o.Product)
                                  join y in db.Purchases.Include(p => p.Provider) on x.ProductId equals y.ProductId
                                  select new
                                  {
                                      id = y.ProductId,
                                      name = y.ProductName,
                                      qOut = x.Quantity,
                                      Quanity = y.Quantity,
                                      moneyOut = y.SalePrice,
                                      date = y.PurchaseDate
                                  }).ToList()
                       group z by z.id into list
                       select new
                       {
                           id = list.Key,
                           Name = list.FirstOrDefault(x => x.id == list.Key)?.name,
                           qOut = list.Sum(x => x.qOut),
                           moneyOut = list.Sum(x => x.qOut * list.FirstOrDefault(y => y.id == list.Key)?.moneyOut),
                           Quantityall = list.Sum(x => x.Quanity),
                           datet = list.FirstOrDefault(y => y.id == list.Key)?.date

                       }).ToList().FindAll(x => x.datet >= DateTime.Parse(txtDateIn.Text) || x.datet <= DateTime.Parse(txtDateOut.Text));

            lstdata.ItemsSource = obj;
        }
    }
}
