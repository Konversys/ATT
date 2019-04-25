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
using System.Windows.Shapes;

namespace ATT
{
    /// <summary>
    /// Логика взаимодействия для Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        InvoiceATT invoice { get; set; }
        public Invoice()
        {
            InitializeComponent();
        }

        void UpdateType()
        {
            switch (_type.SelectedIndex)
            {
                case 1:
                    invoices.ItemsSource = DBQueries.GetInvoices(MainWindow.att).Where(x => x.taken == "Да");
                    break;
                case 2:
                    invoices.ItemsSource = DBQueries.GetInvoices(MainWindow.att).Where(x => x.taken == "Нет");
                    break;
                default:
                    invoices.ItemsSource = DBQueries.GetInvoices(MainWindow.att);
                    break;
            }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateType();
        }

        private void Invoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            invoice = ((InvoiceATT)(ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow).Item);
            _table.ItemsSource = DBQueries.GetRecords(invoice.id);
            if (invoice.taken == "Нет")
            {
                submit.IsEnabled = true;
            }
            else
            {
                submit.IsEnabled = false;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DBQueries.AddToATT(MainWindow.att, invoice);
            UpdateType();
            _table.ItemsSource = DBQueries.GetRecords(invoice.id);
            if (invoice.taken == "Нет")
            {
                submit.IsEnabled = true;
            }
            else
            {
                submit.IsEnabled = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _type.SelectedIndex = 0;
            type.SelectedIndex = 0;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateFind();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (find.Text != "")
            {
                UpdateFind();
            }
        }

        private void UpdateFind()
        {
            switch (((ComboBoxItem)type.SelectedItem).Content.ToString())
            {
                case "По наименованию":
                    _table.ItemsSource = DBQueries.GetRecords(invoice.id).Where(x => x.product.Contains(find.Text));
                    break;
                case "По действующему веществу":
                    _table.ItemsSource = DBQueries.GetRecords(invoice.id).Where(x => x.active.Contains(find.Text));
                    break;
                case "По производителю":
                    _table.ItemsSource = DBQueries.GetRecords(invoice.id).Where(x => x.creator.Contains(find.Text));
                    break;
                default:
                    break;
            }
        }
    }
}
