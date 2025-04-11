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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        private IDbWorker _worker;
        public MaterialsWindow(IDbWorker worker)
        {
            InitializeComponent();
            _worker = worker;

            var materials = _worker.GetMaterials();

            foreach (var material in materials)
            {
                var myMaterialView = new MaterialView(_worker);

                myMaterialView.DataContext = material;

                myStackPanel.Children.Add(myMaterialView);
                
            }
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            _worker.SaveChanges();
        }
    }
}
