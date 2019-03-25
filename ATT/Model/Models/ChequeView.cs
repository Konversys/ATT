using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    public class ChequeView
    {
        public int id { get; set; }
        public string person {get; set;}
        public DateTime date { get; set; }
        public double sum { get; set; }
    }
}
