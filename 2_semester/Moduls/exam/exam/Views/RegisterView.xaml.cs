using System.Windows;
using exam.Services;
using Microsoft.Extensions.DependencyInjection;
namespace exam.Views
{
    public partial class RegisterView : Window
    {
        private IAuthService _authService;
        private IServiceProvider _serviceProvider;
        public RegisterView(IServiceProvider serviceProvider, IAuthService service)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authService = service;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string surname = tbSurName.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string login = tbLogin.Text;
            string password = tbPass.Text;
            string repeatPassword = tbRepeatPass.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(phoneNumber)
                || (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repeatPassword)))
            {
                MessageBox.Show("Заполните поля!");
            }
            else if (_authService.LoginExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
            else if (name.Length < 3)
            {
                MessageBox.Show("Имя должно быть не менее 3 символов!");
            }
            else
            {
                if (repeatPassword != password)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
                else
                {
                    MessageBox.Show("Пользователь зарегестрирован");
                    _authService.Register(name, surname, phoneNumber, login, password);
                    var authWin = _serviceProvider.GetRequiredService<AuthorizateView>();
                    this.Close();
                    authWin.ShowDialog();
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var authWin = _serviceProvider.GetRequiredService<AuthorizateView>();
            this.Close();
            authWin.ShowDialog();
        }
    }
}
