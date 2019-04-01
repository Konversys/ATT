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
            att.ItemsSource = DBQueries.GetATTs().Select(x => x.id + " " + x.kladr + " " + x.chief);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int person = DBQueries.CheckTabel(tabel.Text);
            if (person >= 0)
            {
                string select = att.SelectedItem.ToString().Split(' ')[0];
                MainWindow window = new MainWindow();
                MainWindow.att = int.Parse(select);
                MainWindow.person = person;
                window.Show();
                this.Close();
            }
        }
    }
}
