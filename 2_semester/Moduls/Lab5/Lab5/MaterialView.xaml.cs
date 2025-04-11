using Lab5.Model;
using Lab5.Service;
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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MaterialView.xaml
    /// </summary>
    public partial class MaterialView : UserControl
    {
        private IDbWorker _worker;
        public MaterialView(IDbWorker worker)
        {
            InitializeComponent();
            _worker = worker;
        }

        private void btnOpenWindowWithProducts(object sender, RoutedEventArgs e)
        {
            Material selectedProduct = _worker.GetMaterialInId(int.Parse(tbId.Text));
            var customWindowWithProducts = new ProductsWindow(_worker, selectedProduct);
            customWindowWithProducts.ShowDialog();
        }
    }
}
