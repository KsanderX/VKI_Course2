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
    /// Логика взаимодействия для EngineeringWindow.xaml
    /// </summary>
    public partial class EngineeringWindow : Window
    {
        private IService _service;
        public EngineeringWindow(IService service)
        {
            InitializeComponent();
            _service = service;

            var requests = _service.GetRequests();

            //foreach (var request in requests)
            //{
            //    //var engineeringRequestView = new EngineeringRequestControl(_service);
            //    var viewModel = new RequestViewModel
            //    {
            //        Request = request
            //    };
            //    engineeringRequestView.DataContext = viewModel;
            //    RequestsStackPanel.Children.Add(engineeringRequestView);
            //}
        }

       
    }
}
