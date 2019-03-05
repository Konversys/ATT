using ATT.Model.Database;
using ATT.Model.Models;
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

namespace ATT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int product { get; private set; }
        public static int ATT { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ATT = 1;
            table.ItemsSource = DBQueries.GetProducts(ATT).Where(x => x.Count > 0);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            product = ((Product)(ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow).Item).Id;

        }
    }
}
