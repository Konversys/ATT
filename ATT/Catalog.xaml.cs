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
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 210 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Действующее в-во", Width = 110 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Форма продажи", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Форма выпуска", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Тип медикамента", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Производитель", Width = 110 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Рецептурное", Width = 80 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Штрихкод", Width = 100 });
                    break;
                case "Действующие вещества":
                    _type.ItemsSource = new string[] { "По наименованию" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 400 });
                    break;
                case "Типы медикаментов":
                    _type.ItemsSource = new string[] { "По наименованию", "По ОКП" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 400 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "ОКП", Width = 260 });
                    break;
                case "Формы выпуска":
                    _type.ItemsSource = new string[] { "По наименованию", "По номеру" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 400 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Порядковый номер", Width = 260 });
                    break;
                case "Производители":
                    _type.ItemsSource = new string[] { "По наименованию", "По ОКПО" };
                    _table.Columns.Clear();
                    _type.SelectedItem = _type.Items[0];
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 400 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "ОКПО", Width = 260 });
                    break;
                default:
                    _type.IsEnabled = false;
                    break;
            }
            _find.Text = "";
        }
    }
}
