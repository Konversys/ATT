using ATT.Model.Database;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            att.ItemsSource = DBQueries.GetATTs().Select(x => $"{x.id} {x.kladr} {x.chief}");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int person = DBQueries.CheckTabel(tabel.Text);
            if (person >= 0)
            {
                if (att.SelectedItem == null)
                {
                    MessageBox.Show("Выберите АТТ", "Ошибка");
                    return;
                }
                string select = att.SelectedItem.ToString().Split(' ')[0];
                MainWindow.att = int.Parse(select);
                MainWindow.person = person;
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Сотрудника с таким табельным номером не существует", "Ошибка");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            att.SelectedIndex = 0;
        }
    }
}
