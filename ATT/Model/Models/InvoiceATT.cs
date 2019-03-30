using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    class InvoiceATT
    {
        public int id { get; set; }
        public string product { get; set; }
        public string stock { get; set; }
        public string date { get; set; }
        public bool taken { get; set; }

    }
}
