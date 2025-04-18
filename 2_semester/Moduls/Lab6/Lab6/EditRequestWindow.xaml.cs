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
    /// Логика взаимодействия для EditRequestWindow.xaml
    /// </summary>
    public partial class EditRequestWindow : Window
    {
        private IService _service;
        public EditRequestWindow(RequestViewModel viewModel, IService service)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _service = service;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            var viewModel = (RequestViewModel)this.DataContext;

            int requestStatus = viewModel.Request.RequestStatusId;
            var request = viewModel.Request;
            if (requestStatus == 3)
            {
                request.CompletionDate = DateTime.Now;
                var dateCreate = request.Date;
                var dateCompletion = request.CompletionDate;
                var differentDate = dateCompletion - dateCreate;
                string message = $"Отредактировано! Статус заявки: УСПЕШНО \n" +
                         $"Дата выполнения заявки: {differentDate.Days} дней, " +
                         $"{differentDate.Hours} часов, " +
                         $"{differentDate.Minutes} минут.";

                MessageBox.Show(message);

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
