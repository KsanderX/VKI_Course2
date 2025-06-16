using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wedding_Agency.Models;
using Wedding_Agency.Services;
using Wedding_Agency.ViewModels;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private WeddingAgencyContext _context;
        private IServiceProvider _serviceProvider;
        public EmployeeView(WeddingAgencyContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            var employees = _context.AgencyEmployees.Include(e => e.FkPositionNavigation).Select(e => new AgencyEmployeeViewModel
            {
                FirstName = e.FirstName ?? string.Empty,
                LastName = e.LastName ?? string.Empty,
                Email = e.Email ?? string.Empty,
                PhoneNumber = e.PhoneNumber ?? string.Empty,
                PositionTitle = e.FkPositionNavigation != null ? e.FkPositionNavigation.Title ?? string.Empty : string.Empty
            }).ToList();
            EmployeeList.ItemsSource = employees;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = _serviceProvider.GetRequiredService<CreateEmployeeView>();
            addWindow.ShowDialog();
            LoadEmployees();
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedItem is AgencyEmployeeViewModel selected)
            {
                var employee = _context.AgencyEmployees.FirstOrDefault(e => e.FirstName == selected.FirstName && e.LastName == selected.LastName);

                if (employee != null)
                {
                    var editWindow = new EditEmployeeView(
                        _serviceProvider.GetRequiredService<IUpdateEmployeeService>(),
                        employee.IdAgencyEmployee
                    );
                    editWindow.ShowDialog();
                    LoadEmployees();
                }
                else
                {
                    MessageBox.Show("Не удалось найти сотрудника.");
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.");
            }
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedItem is AgencyEmployeeViewModel selected)
            {
                var employee = _context.AgencyEmployees
                    .FirstOrDefault(e => e.FirstName == selected.FirstName && e.LastName == selected.LastName);

                if (employee == null)
                {
                    MessageBox.Show("Сотрудник не найден.");
                    return;
                }

                var result = MessageBox.Show($"Удалить сотрудника {selected.FullName}?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var deleteService = _serviceProvider.GetRequiredService<IDeleteEmployeeService>();
                    deleteService.DeleteEmployee(employee.IdAgencyEmployee);

                    MessageBox.Show("Сотрудник удалён.");
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника.");
            }
        }
    }
}
