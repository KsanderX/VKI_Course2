using System.Windows;
using Wedding_Agency.Models;
using Wedding_Agency.Services;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateContractView.xaml
    /// </summary>
    public partial class CreateContractView : Window
    {
        private ICreateContractService _createContractService;
        public CreateContractView(ICreateContractService contractService)
        {
            InitializeComponent();
            _createContractService = contractService;

            cbClients.ItemsSource = _createContractService.GetAllClients();
            cbLocation.ItemsSource = _createContractService.GetAllLocations();
            cbMenu.ItemsSource = _createContractService.GetAllMenus();
            cbDesign.ItemsSource = _createContractService.GetAllDesigns();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int? clientId = null;

            if (cbNewClient.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text))
                {
                    MessageBox.Show("Введите имя и фамилию нового клиента.");
                    return;
                }

                var newClient = new Client
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    PhoneNumber = tbPhone.Text,
                    Email = tbEmail.Text,
                    PassportData = tbPassport.Text
                };

                _createContractService.AddClient(newClient);
                clientId = newClient.IdClient;
            }
            else
            {
                if (cbClients.SelectedValue == null)
                {
                    MessageBox.Show("Выберите клиента.");
                    return;
                }
                clientId = (int)cbClients.SelectedValue;
            }

            if (!int.TryParse(tbBudget.Text, out int budget))
            {
                MessageBox.Show("Неверный формат бюджета.");
                return;
            }

            var contract = new Contract
            {
                FkClient = clientId.Value,
                ContractDate = dpContractDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpContractDate.SelectedDate.Value) : null,
                WeddingDate = dpWeddingDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpWeddingDate.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now),
                TotalBudget = budget,
                Description = tbDescription.Text
            };

            _createContractService.AddContract(contract);

            if (cbLocation.SelectedValue is int locId)
            {
                var booking = new BookingLocation
                {
                    FkContract = contract.IdContract,
                    FkLocation = locId,
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    TimeFrom = TimeOnly.FromTimeSpan(new TimeSpan(15, 0, 0)),
                    TimeTo = TimeOnly.FromTimeSpan(new TimeSpan(23, 0, 0)),
                    TotalCost = 100000
                };
                _createContractService.AddBookingLocation(booking);
            }

            // меню
            if (cbMenu.SelectedValue is int menuId)
            {
                var menuCatering = new MenuCatering
                {
                    FkMenu = menuId,
                    PortionSize = "Полная порция",
                    CostPerPerson = 3000
                };
                _createContractService.AddMenuCatering(menuCatering);
            }

            // дизайн — просто сохранить в контракте или позже
            if (cbDesign.SelectedValue is int designId)
            {
                // можно создать связь в отдельной таблице если она есть
            }

            MessageBox.Show("Контракт создан.");
            this.Close();
        }

        private void cbNewClient_Checked(object sender, RoutedEventArgs e)
        {
            newClientPanel.Visibility = Visibility.Visible;
            existingClientPanel.Visibility = Visibility.Collapsed;
        }
        private void cbNewClient_Unchecked(object sender, RoutedEventArgs e)
        {
            newClientPanel.Visibility = Visibility.Collapsed;
            existingClientPanel.Visibility = Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
