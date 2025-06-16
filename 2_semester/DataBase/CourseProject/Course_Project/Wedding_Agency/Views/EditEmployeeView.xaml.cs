using System.Windows;
using Wedding_Agency.Models;
using Wedding_Agency.Services;

namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeeView.xaml
    /// </summary>
    public partial class EditEmployeeView : Window
    {
        private IUpdateEmployeeService _service;
        private AgencyEmployee? _employee;   
        public EditEmployeeView(IUpdateEmployeeService service, int employeeId)
        {
            InitializeComponent();
            _service = service;
            _employee = _service.GetEmployeeById(employeeId)!;

            cbPositions.ItemsSource = _service.GetAllPositions();

            if (_employee != null)
            {
                tbFirstName.Text = _employee.FirstName;
                tbLastName.Text = _employee.LastName;
                tbPhone.Text = _employee.PhoneNumber;
                tbEmail.Text = _employee.Email;
                tbLogin.Text = _employee.Login;
                tbPassword.Text = _employee.Password;
                cbPositions.SelectedValue = _employee.FkPosition;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_employee == null)
            {
                MessageBox.Show("Ошибка: сотрудник не найден.");
                return;
            }

            _employee.FirstName = tbFirstName.Text;
            _employee.LastName = tbLastName.Text;
            _employee.PhoneNumber = tbPhone.Text;
            _employee.Email = tbEmail.Text;
            _employee.Login = tbLogin.Text;
            _employee.Password = tbPassword.Text;
            _employee.FkPosition = (int?)cbPositions.SelectedValue;

            _service.UpdateEmployee(_employee);
            MessageBox.Show("Данные сотрудника обновлены.");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
