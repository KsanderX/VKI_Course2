using Lab5.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для MaterialsDataGridWindow.xaml
    /// </summary>
    public partial class MaterialsDataGridWindow : Window
    {
        private IDbWorker _dbWorker;
        public MaterialsDataGridWindow(IDbWorker dbWorker)
        {
            InitializeComponent();
            _dbWorker = dbWorker;
        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _dbWorker.SaveChanges();
        }
    }
}
