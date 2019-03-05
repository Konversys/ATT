using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    public class Product
    {
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
