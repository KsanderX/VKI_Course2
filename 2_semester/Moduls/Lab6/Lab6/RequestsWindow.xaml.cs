using Azure.Core;
using Lab6.Models;
using Lab6.Service;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для RequestsWindow.xaml
    /// </summary>
    public partial class RequestsWindow : Window
    {
        private IService _service;
        public RequestsWindow(IService service)
        {
            InitializeComponent();
            _service = service;

            var requests = _service.GetRequests();

            foreach (var request in requests)
            {
              var requestView = new RequestControl(_service);
              var viewModel = new RequestViewModel
              {
                   Request = request
              };
              requestView.DataContext = viewModel;
              RequestsStackPanel.Children.Add(requestView);
            }
            
        }


        private void BtnFindRequest(object sender, RoutedEventArgs e)
        {
            RequestsStackPanel.Children.Clear();
            var findRequest = _service.GetRequestById(tbSelectedId.Text);
            if (findRequest != null)
            {

                var requestView = new RequestControl(_service);
                var viewModel = new RequestViewModel
                {
                    Request = findRequest
                };
                requestView.DataContext = viewModel;
                RequestsStackPanel.Children.Add(requestView);
            }
            else if (findRequest == null || tbSelectedId.Text == "")
            {

                var requests = _service.GetRequests();
                foreach (var request in requests)
                {
                    var requestView1 = new RequestControl(_service);
                    var viewModel1 = new RequestViewModel
                    {
                        Request = request
                    };
                    requestView1.DataContext = viewModel1;
                    RequestsStackPanel.Children.Add(requestView1);
                }
            }
        }

        private void btnStats(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Всего заявок: {_service.GetRequestsCount().ToString()} \nВсего выполненных заявок: {_service.GetCompletedRequestsCount().ToString()}");

            Dictionary<string, double> faultStatistics = _service.GetFaultStatistics();

            foreach (var item in faultStatistics)
            {
                MessageBox.Show($"{item.Key} = {item.Value}");
            }
        }

        private void btnOpenEngineeringWindow(object sender, RoutedEventArgs e)
        {
            var engineeringWindow = new EngineeringWindow(_service);
            engineeringWindow.ShowDialog();
        }
    }
    }

