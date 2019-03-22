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
        public static List<ProductATT> sellList;
        public static ProductATT product { get; private set; }
        public static int att { get; set; }
        public MainWindow()
        {
            sellList = new List<ProductATT>();
            InitializeComponent();
            att = 2;
            title_date.Text = "Остатки на " + System.DateTime.Now.ToLongDateString();
            table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            product = ((ProductATT)(ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow).Item);
            Sell window = new Sell();
            window.Show();
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            Catalog window = new Catalog();
            window.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            table_sell.ItemsSource = new List<ProductATT>();
            table_sell.ItemsSource = sellList;
            double total_count = 0;
            foreach (var item in sellList)
            {
                total_count += item.price * item.sell;
            }
            total.Text = $"К оплате: {total_count}";
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void _find_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        void Update()
        {
            switch (((ComboBoxItem)_type.SelectedItem).Content.ToString())
            {
                case "По наименованию":
                    table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0).Where(x => x.title.Contains(_find.Text));
                    break;
                case "По действующему веществу":
                    table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0).Where(x => x.active.Contains(_find.Text));
                    break;
                case "По форме выпуска":
                    table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0).Where(x => x.form.Contains(_find.Text));
                    break;
                case "По типу медикамента":
                    table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0).Where(x => x.type.Contains(_find.Text));
                    break;
                case "По производителю":
                    table.ItemsSource = DBQueries.GetProductsATT(att).Where(x => x.count > 0).Where(x => x.creator.Contains(_find.Text));
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}