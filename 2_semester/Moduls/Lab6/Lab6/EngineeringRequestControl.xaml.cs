using Lab6.Models;
using Lab6.Service;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для EngineeringRequestControl.xaml
    /// </summary>
    public partial class EngineeringRequestControl : UserControl
    {
        private IServiceProvider _serviceProvider;
        public EngineeringRequestControl(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }


        private void btnSave(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as RequestViewModel;
            if (viewModel != null)
            {
                var editWindow = _serviceProvider.GetRequiredService<EngineeringEditRequest>();
                editWindow.DataContext = viewModel;
                editWindow.ShowDialog();
            }
        }
    }
}
