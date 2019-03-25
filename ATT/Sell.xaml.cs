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
    /// Логика взаимодействия для Sell.xaml
    /// </summary>
    public partial class Sell : Window
    {
        ProductATT product { get; set; }
        public Sell()
        {
            InitializeComponent();
            table.Items.Clear();
            product = DBQueries.GetProductATT(MainWindow.att, MainWindow.product.id);
            table.Items.Add(product);
            count.Text = MainWindow.product.sell.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(count.Text) > product.count)
            {
                MessageBox.Show("Введите меньшее количество для продажи", "Ошибка");
            }
            else
            {
                if (int.Parse(count.Text) == 0)
                {
                    MainWindow.sellList.RemoveAll(x => x.id == product.id);
                }
                else if (MainWindow.sellList.Where(x => x.id == product.id).Count() == 0)
                {
                    product.sell = int.Parse(count.Text);
                    MainWindow.sellList.Add(product);
                }
                else
                {
                    for (int i = 0; i < MainWindow.sellList.Count; i++)
                    {
                        var item = MainWindow.sellList[i];
                        if (item.id == product.id)
                        {
                            ProductATT temp = item;
                            temp.sell = int.Parse(count.Text);
                            MainWindow.sellList[i] = temp;
                            break;
                        }
                    }
                }
            }
            this.Close();
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            int temp;
            if (!int.TryParse(count.Text, out temp))
            {
                return;
            }
            if (int.Parse(count.Text) > product.count || count.Text == "")
            {
                count.Text = product.count.ToString();
                return;
            }
            total.Text = $"ВСЕГО: {int.Parse(count.Text) * product.price}";
        }
    }
}
