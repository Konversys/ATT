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
    /// Логика взаимодействия для Cheque.xaml
    /// </summary>
    public partial class Cheque : Window
    {
        ChequeView cheque { get; set; }
        public Cheque()
        {
            InitializeComponent();
            cheque = History.cheque;
            table.ItemsSource = DBQueries.GetSales(cheque.id);
            number.Text = $"Чек #{cheque.id}";
            total.Text = $"ИТОГО {cheque.sum}";
            person.Text = $"Кассир: {cheque.person}";
            date.Text = $"Дата: {cheque.date.ToShortDateString()} {cheque.date.ToShortTimeString()}";
        }
    }
}
