using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wedding_Agency.Models;
using Wedding_Agency.Services;
using Wedding_Agency.ViewModels;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для ContractView.xaml
    /// </summary>
    public partial class ContractView : Window
    {
        private IServiceProvider _serviceProvider;
        private WeddingAgencyContext _context;
        public ContractView(WeddingAgencyContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadContracts();
        }
            //var contracts = _context.Contracts.Include(c => c.FkClientNavigation).ToList();
            ////ContractsDataGrid.ItemsSource = contracts;
            //ContractListView.ItemsSource = contracts; 
        private void LoadContracts()
        {
            var contracts = _context.Contracts
                .Include(c => c.FkClientNavigation)
                .ToList();

            var bookings = _context.BookingLocations
                .Include(b => b.FkLocationNavigation)
                .ToList();

            var menuCaterings = _context.MenuCaterings
                .Include(mc => mc.FkMenuNavigation)
                .Include(mc => mc.FkCateringNavigation)
                .ToList();

            var caterings = _context.Caterings.ToList(); // чтобы найти по контракту
            var locations = _context.Locations.ToList();

            var contractDisplayList = contracts.Select(c =>
            {
                var booking = bookings.FirstOrDefault(b => b.FkContract == c.IdContract);
                var location = booking?.FkLocationNavigation;

                var catering = caterings.FirstOrDefault(cat => cat.FkContract == c.IdContract);
                var menu = menuCaterings.FirstOrDefault(mc => mc.FkCatering == catering?.IdCatering)?.FkMenuNavigation;


                return new ContractDisplayModel
                {
                    IdContract = c.IdContract,
                    ClientName = $"{c.FkClientNavigation.FirstName}",
                    ContractDate = c.ContractDate.HasValue ? c.ContractDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                    WeddingDate = c.WeddingDate.HasValue ? c.WeddingDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,                   
                    TotalBudget = c.TotalBudget,
                    Description = c.Description,
                    LocationName = location?.Name,
                    MenuName = menu?.Name
                };
            }).ToList();

            ContractListView.ItemsSource = contractDisplayList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnCreateContract_Click(object sender, RoutedEventArgs e)
        {
            var createView = _serviceProvider.GetService<CreateContractView>();
            createView?.ShowDialog();
            LoadContracts();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ContractListView.SelectedItem is ContractDisplayModel selected)
            {
                var editWindow = new EditContractView(
                    _serviceProvider.GetRequiredService<IUpdateContractService>(),
                    selected.IdContract
                );
                editWindow.ShowDialog();
                LoadContracts();
            }
            else
            {
                MessageBox.Show("Выберите контракт для редактирования.");
            }
        }
    }
}