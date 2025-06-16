using System.Windows;
using Wedding_Agency.Models;
using Wedding_Agency.Services;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для EditContractView.xaml
    /// </summary>
    public partial class EditContractView : Window
    {
        private IUpdateContractService _updateContractService;
        private Contract _contract;
        private BookingLocation? _bookingLocation;
        private MenuCatering? _menuCatering;
        public EditContractView(IUpdateContractService service, int contractId)
        {
            InitializeComponent();
            _updateContractService = service;

            cbClients.ItemsSource = _updateContractService.GetAllClients();
            cbLocation.ItemsSource = _updateContractService.GetAllLocation();
            cbMenu.ItemsSource = _updateContractService.GetAllMenus();

            _contract = _updateContractService.GetContractById(contractId)!;
            _bookingLocation = _updateContractService.GetBookingByContractId(contractId);
            _menuCatering = _updateContractService.GetMenuCateringByContractId(contractId);

            if (_contract != null)
            {
                cbClients.SelectedValue = _contract.FkClient;
                dpWeddingDate.SelectedDate = _contract.WeddingDate.HasValue ? _contract.WeddingDate.Value.ToDateTime(TimeOnly.MinValue) : null;
                tbBudget.Text = _contract.TotalBudget?.ToString();
                tbDescription.Text = _contract.Description;

                if (_bookingLocation != null)
                    cbLocation.SelectedValue = _bookingLocation.FkLocation;

                if (_menuCatering != null)
                    cbMenu.SelectedValue = _menuCatering.FkMenu;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_contract != null)
            {
                _contract.FkClient = (int)cbClients.SelectedValue;
                _contract.WeddingDate = dpWeddingDate.SelectedDate.HasValue
                    ? DateOnly.FromDateTime(dpWeddingDate.SelectedDate.Value)
                    : _contract.WeddingDate;
                _contract.TotalBudget = int.TryParse(tbBudget.Text, out var budget) ? budget : _contract.TotalBudget;
                _contract.Description = tbDescription.Text;
                _updateContractService.UpdateContract(_contract);
                if (_bookingLocation != null && cbLocation.SelectedValue is int locId)
                {
                    _bookingLocation.FkLocation = locId;
                    _updateContractService.UpdateBookingLocation(_bookingLocation);
                }

                if (_menuCatering != null && cbMenu.SelectedValue is int menuId)
                {
                    _menuCatering.FkMenu = menuId;
                    _updateContractService.UpdateMenuCatering(_menuCatering);
                }
                MessageBox.Show("Контракт обновлён.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
