using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    public class Product
    {

        _table.Columns.Add(new DataGridTextColumn() { Header = "Наименование", Width = 210 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Действующее в-во", Width = 110 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Форма продажи", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Форма выпуска", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Тип медикамента", Width = 130 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Производитель", Width = 110 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Рецептурное", Width = 80 });
                    _table.Columns.Add(new DataGridTextColumn() { Header = "Штрихкод", Width = 100 });

        public int Id { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }
        public string Type { get; set; }
        public string Creator { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }

        

        public Product()
        {
        }

        public Product(int id, string title, string form, string type, string creator, double price, int count, string date)
        {
            Id = id;
            Title = title;
            Form = form;
            Type = type;
            Creator = creator;
            Price = price;
            Count = count;
            Date = date;
        }
    }
}
