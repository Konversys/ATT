using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    public class Sale
    {
        public int id { get; set; }
        public string title { get; set; }
        public string box { get; set; }
        public string inside { get; set; }
        public string measures { get; set; }
        public int count { get; set; }
        public double price { get; set; }
        public double total { get; set; }
    }
}
