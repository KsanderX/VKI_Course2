using System.Windows;
using Wedding_Agency.Models;
using Wedding_Agency.Services;
namespace Wedding_Agency.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateEmployeeView.xaml
    /// </summary>
    public partial class CreateEmployeeView : Window
    {
        private ICreateEmployeeService _service;
        public CreateEmployeeView(ICreateEmployeeService service)
        {
            InitializeComponent();
            _service = service;
            cbPositions.ItemsSource = _service.GetAllPositions();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Password))
            {
                MessageBox.Show("Логин и пароль обязательны.");
                return;
            }

            var employee = new AgencyEmployee
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                PhoneNumber = tbPhone.Text,
                Email = tbEmail.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Password,
                FkPosition = (int?)cbPositions.SelectedValue
            };

            _service.AddEmployee(employee);
            MessageBox.Show("Сотрудник добавлен.");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
