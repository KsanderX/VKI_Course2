using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Tkachev_KR.DataBase;
using Tkachev_KR.Services;
using Tkachev_KR.ViewModel;


namespace Tkachev_KR.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private IAuthorization _authorization;
        private IOrderService _orderService;
        private IServiceProvider _serviceProvider;
        private Customer _customer = null!; 

        public OrderWindow(IAuthorization authorization, IOrderService orderService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authorization = authorization;
            _orderService = orderService;
            _serviceProvider = serviceProvider;
            LoadCustomer();
            LoadOrders();
            this.DataContext = _serviceProvider.GetRequiredService<OrderViewModel>();
        }

        public void LoadCustomer()
        {
            _customer = _authorization.GetCurrentCustomer();
        }

        public void LoadOrders()
        {
            List<Order> indents = _orderService.GetOrder(_customer.CustomerId);
            customerOrder.ItemsSource = indents;
        }

        private void btnFiltrNameProduct_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.ItemsSource = _orderService.SortNameProduct(_customer.CustomerId);
        }

        private void btnSortPriceProduct_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.ItemsSource = _orderService.SortPriceProduct(_customer.CustomerId);
        }

        private void btnSortDateProduct_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.ItemsSource = _orderService.SortDateProduct(_customer.CustomerId);
        }
    }
}
