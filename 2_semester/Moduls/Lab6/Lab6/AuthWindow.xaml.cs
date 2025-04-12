using Lab6.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private IService _service;
        public AuthWindow(IService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            bool result = _service.Authorization(login,password);
            if (result)
            {
                var adminWindow = new MainWindow(_service);
                adminWindow.ShowDialog();
            }
            else
            {
                var engineerWindow = new EngineeringWindow(_service);
                engineerWindow.ShowDialog();
            }
        }

    }
}
