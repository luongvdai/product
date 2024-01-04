

using Project.ViewModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class NavigationVM : RootViewModel
    {
        private RootViewModel _currentView;
        public RootViewModel CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand ProductCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand WarehouseCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand MemberCommand { get; set; }
        public NavigationVM()
        {
            //StartUp page
            CurrentView = new ProductVM();

            ProductCommand = new RelayCommand(NavigateToProductView);
            OrderCommand = new RelayCommand(NavigateToOrderView);
            ReportCommand = new RelayCommand(NavigateToReportView);
            WarehouseCommand = new RelayCommand(NavigateToWarehouseView);
            CustomerCommand = new RelayCommand(NavigateToCustomerView);
            MemberCommand = new RelayCommand(NavigateToMemberView);

        }

        private void NavigateToProductView()
        {
            CurrentView = new ProductVM();

        }
        private void NavigateToOrderView()
        {

            CurrentView = new OrderVM();

        }
        private void NavigateToReportView()
        {

            CurrentView = new ReportVM();


        }
        private void NavigateToWarehouseView()
        {

            CurrentView = new WarehouseVM();
        }
        private void NavigateToCustomerView()
        {
            CurrentView = new CustomerVM();
        }
        private void NavigateToMemberView()
        {
            CurrentView = new MemberVM();
        }
    }
}
