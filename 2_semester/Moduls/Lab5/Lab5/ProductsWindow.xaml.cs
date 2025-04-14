using Lab5.Model;
using Lab5.Service;
using Lab5.ViewModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private IDbWorker _worker;
        private Model.Material _material;

        public ProductsWindow(IDbWorker worker, Model.Material material)
        {
            InitializeComponent();
            _worker = worker;
            _material = material;

            if (_material != null) // если на форме с материалами мы нажали на кнопку материала значит он будет не null и я загружаю именно продукты данного материала 
            {
                LoadProductsByMaterial();
            }
            else // если материал пустой значит загружаю по умолчанию все продукты
            {
              LoadProducts();
            }
        }

        private void LoadProducts() 
        {
            var products = _worker.GetProducts();
            var materials = _worker.GetMaterials();

            foreach (var product in products)
            {
                var productView = new ProductView();
                var viewModel = new ProductViewModel()
                {
                    Product = product,
                    Materials = materials,
                };

                productView.DataContext = viewModel;

                myStackPanel.Children.Add(productView);
            }
        }

        private void LoadProductsByMaterial()
        {
            var productsTest = _worker.GetProductInMaterial(_material);
            var materials = _worker.GetMaterials();
            
            foreach (var product in productsTest)
            {
                var productView = new ProductView();
                var viewModel = new ProductViewModel()
                {
                    Product = product,
                    Materials = materials,
                };

                productView.DataContext = viewModel;

                myStackPanel.Children.Add(productView);
            }
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            _worker.SaveChanges();
        }
    }
}
