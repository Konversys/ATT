using ATT.Model.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = ATT.Model.Models.Type;

namespace ATT.Model.Database
{
    class DBQueries
    {
        public static List<Product> GetProductView()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * from ProductView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    Действующее__вещество = reader.GetString(2),
                    Упаковка = reader.GetString(3),
                    Количество = reader.GetInt32(4),
                    Ед__измерения = reader.GetString(5),
                    Производитель = reader.GetString(6),
                    Форма__выпуска = reader.GetString(7),
                    Тип__медикамента = reader.GetString(8),
                    Штрихкод = reader.GetString(10),
                };
                if (reader.GetBoolean(9))
                    product.Рецепт = "Да";
                else
                    product.Рецепт = "Нет";
                products.Add(product);
            }
            DBHelper.GetConnect().Close();
            return products;
        }

        public static List<Active> GetActiveView()
        {
            List<Active> items = new List<Active>();
            string query = "SELECT * from ActiveView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Active()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    //About = reader.GetString(2)
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }

        public static List<Creator> GetCreatorView()
        {
            List<Creator> items = new List<Creator>();
            string query = "SELECT * from CreatorView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Creator()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    ОКПО = reader.GetString(2)
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }

        public static List<Deliver> GetDeliverView()
        {
            List<Deliver> items = new List<Deliver>();
            string query = "SELECT * from DeliverView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Deliver()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    КЛАДР = reader.GetString(2)
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }

        public static List<Form> GetFormView()
        {
            List<Form> items = new List<Form>();
            string query = "SELECT * from FormView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Form()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    Номер = reader.GetString(2)
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }

        public static List<Type> GetTypeView()
        {
            List<Type> items = new List<Type>();
            string query = "SELECT * from TypeView";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Type()
                {
                    //Id = reader.GetInt32(0),
                    Наименование = reader.GetString(1),
                    ОКП = reader.GetString(2)
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }
    }
}
