using Lab5.Model;
using Lab5.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        private IDbWorker _dbWorker;
        private Material material;
        public MyWindow(IDbWorker dbWorker)
        {
            InitializeComponent();
            _dbWorker = dbWorker;
        }

        private void openMaterials(object sender, RoutedEventArgs e)
        {
            var dataGridWindowWithProducts = new DataGridWindow(_dbWorker);
            dataGridWindowWithProducts.DataContext = _dbWorker.GetMaterials();
            dataGridWindowWithProducts.ShowDialog();
        }

        private void openProducts(object sender, RoutedEventArgs e)
        {
            var dataGridWindowWithProducts = new DataGridWindow(_dbWorker);
            dataGridWindowWithProducts.DataContext = _dbWorker.GetProducts();
            dataGridWindowWithProducts.ShowDialog();
        }

        private void OpenWindowWithMaterials(object sender, RoutedEventArgs e)
        {
            var windowWithMaterials = new MaterialsDataGridWindow(_dbWorker);
            windowWithMaterials.DataContext = _dbWorker.GetMaterials();
            windowWithMaterials.ShowDialog();
        }

        private void OpenWindowWithProducts(object sender, RoutedEventArgs e)
        {
            var windowWithProduct = new ProductsDataGridWindow(_dbWorker);
            windowWithProduct.DataContext = _dbWorker.GetProducts();
            windowWithProduct.ShowDialog();
        }

        private void btnOpenCustomWindowWithMaterials(object sender, RoutedEventArgs e)
        {
            var windowWithMaterial = new MaterialsWindow(_dbWorker);
            windowWithMaterial.ShowDialog();
        }

        private void btnOpenCustomWindowWithProducts(object sender, RoutedEventArgs e)
        {
            var customWindowWithProducts = new ProductsWindow(_dbWorker, material);
            customWindowWithProducts.ShowDialog();
        }
    }
}