using ATT.Model.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ATT
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
        }

        private void Cat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _type.IsEnabled = true;
            switch (((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString())
            {
                case "Медикаменты":
                    _type.ItemsSource = new string[]{ "По наименованию", "По действующему веществу", "По форме выпуска",
                    "По типу медикамента", "По производителю"};
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.ItemsSource = DBQueries.GetProductView();
                    break;
                case "Действующие вещества":
                    _type.ItemsSource = new string[] { "По наименованию" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.ItemsSource = DBQueries.GetActiveView();
                    break;
                case "Типы медикаментов":
                    _type.ItemsSource = new string[] { "По наименованию", "По ОКП" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.ItemsSource = DBQueries.GetTypeView();
                    break;
                case "Формы выпуска":
                    _type.ItemsSource = new string[] { "По наименованию", "По номеру" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.ItemsSource = DBQueries.GetFormView();
                    break;
                case "Производители":
                    _type.ItemsSource = new string[] { "По наименованию", "По ОКПО" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.ItemsSource = DBQueries.GetCreatorView();
                    break;
                default:
                    _type.IsEnabled = false;
                    break;
            }
            _find.Text = "";
        }

        private void _find_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTable();
        }

        private void _type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        void UpdateTable()
        {
            switch (((ComboBoxItem)_catalog.SelectedItem).Content.ToString())
            {
                case "Медикаменты":
                    switch (_type.SelectedItem)
                    {
                        case "По наименованию":
                            _table.ItemsSource = DBQueries.GetProductView().Where(x => x.Наименование.Contains(_find.Text));
                            break;
                        case "По действующему веществу":
                            _table.ItemsSource = DBQueries.GetProductView().Where(x => x.Действующее__вещество.Contains(_find.Text));
                            break;
                        case "По форме выпуска":
                            _table.ItemsSource = DBQueries.GetProductView().Where(x => x.Форма__выпуска.Contains(_find.Text));
                            break;
                        case "По типу медикамента":
                            _table.ItemsSource = DBQueries.GetProductView().Where(x => x.Тип__медикамента.Contains(_find.Text));
                            break;
                        case "По производителю":
                            _table.ItemsSource = DBQueries.GetProductView().Where(x => x.Производитель.Contains(_find.Text));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Действующие вещества":
                    switch (_type.SelectedItem)
                    {
                        case "По наименованию":
                            _table.ItemsSource = DBQueries.GetActiveView().Where(x => x.Наименование.Contains(_find.Text));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Типы медикаментов":
                    switch (_type.SelectedItem)
                    {
                        case "По наименованию":
                            _table.ItemsSource = DBQueries.GetTypeView().Where(x => x.Наименование.Contains(_find.Text));
                            break;
                        case "По ОКП":
                            break;
                        default:
                            break;
                    }
                    break;
                case "Формы выпуска":
                    switch (_type.SelectedItem)
                    {
                        case "По наименованию":
                            _table.ItemsSource = DBQueries.GetFormView().Where(x => x.Наименование.Contains(_find.Text));
                            break;
                        case "По номеру":
                            _table.ItemsSource = DBQueries.GetFormView().Where(x => x.Номер.Contains(_find.Text));
                            break;
                        default:
                            break;
                    }
                    break;
                case "Производители":
                    switch (_type.SelectedItem)
                    {
                        case "По наименованию":
                            _table.ItemsSource = DBQueries.GetFormView().Where(x => x.Наименование.Contains(_find.Text));
                            break;
                        case "По ОКПО":
                            _table.ItemsSource = DBQueries.GetCreatorView().Where(x => x.ОКПО.Contains(_find.Text));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _catalog.SelectedIndex = 0;
        }
    }
}
