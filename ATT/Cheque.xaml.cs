using ATT.Model.Database;
using ATT.Model.Models;
using System.Windows;

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
