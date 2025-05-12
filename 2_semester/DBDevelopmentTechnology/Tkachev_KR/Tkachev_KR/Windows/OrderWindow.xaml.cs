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
        private Customer _customer;

        public OrderWindow(IAuthorization authorization, IOrderService orderService
            , IServiceProvider serviceProvider )
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
            clientIndents.ItemsSource = indents;
        }

        private void btnFindIndexById_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
