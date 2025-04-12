using Lab6.Models;
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
    /// Логика взаимодействия для EngineeringEditRequest.xaml
    /// </summary>
    public partial class EngineeringEditRequest : Window
    {
        private IService _service;
        public EngineeringEditRequest(IService service, RequestViewModel request)
        {
            InitializeComponent();
            _service = service;
            DataContext = request;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            var viewModel = (RequestViewModel)this.DataContext;

            int requestStatus = viewModel.Request.RequestStatusId;
            if (requestStatus == 3)
            {
                MessageBox.Show($"Отредактировано! Статус заявки: УСПЕШНО");

            }
            else
            {
                MessageBox.Show($"Отредактировано!");
            }

            _service.Save();
            this.Close();
        }
    }
}
