using ATT.Model.Database;
using ATT.Model.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ATT
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        public static ChequeView cheque {get; private set;}
        public History()
        {
            InitializeComponent();
            history.ItemsSource = DBQueries.GetCheques(MainWindow.att);
        }

        void Update()
        {
            switch (((ComboBoxItem)type.SelectedItem).Content.ToString())
            {
                case "По кассиру":
                    if (date_start.SelectedDate == null || date_end.SelectedDate == null)
                    {
                        if (date_start.SelectedDate == null)
                        {
                            history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => new DateTime(1990,1,1).CompareTo(x.date) <= 0 && date_end.SelectedDate?.CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                        }
                        if (date_end.SelectedDate == null)
                        {
                            history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => date_start.SelectedDate?.CompareTo(x.date) <= 0 && new DateTime(2100, 1, 1).CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                        }
                    }
                    else
                    {
                        history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => date_start.SelectedDate?.CompareTo(x.date) <= 0 && date_end.SelectedDate?.CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                    }
                    break;
                default:
                    if (date_start.SelectedDate == null || date_end.SelectedDate == null)
                    {
                        if (date_start.SelectedDate == null)
                        {
                            history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => new DateTime(1990, 1, 1).CompareTo(x.date) <= 0 && date_end.SelectedDate?.CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                        }
                        if (date_end.SelectedDate == null)
                        {
                            history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => date_start.SelectedDate?.CompareTo(x.date) <= 0 && new DateTime(2100, 1, 1).CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                        }
                    }
                    else
                    {
                        history.ItemsSource = DBQueries.GetCheques(MainWindow.att).Where(x => date_start.SelectedDate?.CompareTo(x.date) <= 0 && date_end.SelectedDate?.CompareTo(x.date) >= 0).Where(x => x.person.Contains(find.Text));
                    }
                    break;
            }
        }

        private void Date_start_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Date_end_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
 
        private void History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cheque = ((ChequeView)(ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow).Item);
            Cheque window = new Cheque();
            window.Show();
        }

        private void Find_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Update();
            }
        }
    }
}
