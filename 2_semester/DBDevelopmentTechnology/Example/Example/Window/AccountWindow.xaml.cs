using System.Collections;
using System.Windows;
using Example.DataBase;
using Example.Service;
using Example.ViewModel;
using Microsoft.Extensions.DependencyInjection;


namespace Example
{
    /// <summary>
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private IAuthorizationService _authorizationService;
        private IIndentService _indentService;
        private IServiceProvider _serviceProvider;
        private Client _client;
        public AccountWindow(IAuthorizationService authorizationService
            , IIndentService indentService
            , IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authorizationService = authorizationService;
            _indentService = indentService;
            _serviceProvider = serviceProvider;
            LoadClient();
            LoadIndents();
            this.DataContext = _serviceProvider.GetRequiredService<IndentViewModel>();
        }

        public void LoadClient()
        {
            _client = _authorizationService.GetCurrentClient();
        }
        public void LoadIndents()
        {
           List<Indent> indents = _indentService.GetIndent(_client.Id);
           clientIndents.ItemsSource = indents;
        }

        private void btnFindIndexById_Click(object sender, RoutedEventArgs e)
        {
            Indent findIndent = _indentService.GetIndetsById(tbSelectedId.Text,
                _client.Id);

            clientIndents.ItemsSource = null;
            clientIndents.ItemsSource = new List<Indent>{findIndent};
        }
    }
}
