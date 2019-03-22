using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Models
{
    public class Product
    {
        //public int Id { get; set; }
        public string Наименование { get; set; }
        public string Действующее__вещество { get; set; }
        public string Упаковка { get; set; }
        public int Количество { get; set; }
        public string Ед__измерения { get; set; }
        public string Производитель { get; set; }
        public string Форма__выпуска { get; set; }
        public string Тип__медикамента { get; set; }
        public string Рецепт { get; set; }
        public string Штрихкод { get; set; }

        public Product()
        {
        }
    }
}
