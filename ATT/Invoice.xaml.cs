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
            switch (((ComboBoxItem)_type.SelectedItem).Content.ToString())
            {
                case "Обработанные":
                    invoices.ItemsSource = DBQueries.GetInvoices(MainWindow.att).Where(x => x.taken == "Да");
                    break;
                case "Ожидающие":
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
        }
    }
}
