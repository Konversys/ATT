using ATT.Model.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Model.Database
{
    class DBQueries
    {
        public static List<Product> GetProducts(int att)
        {
            List<Product> products = new List<Product>();
            string query = "select att_list.id, product.title, form.title, type.title, creator.title, " +
                "att_list.price, att_list.count, att_list.date " +
                "from product, form, type, creator, att_list " +
                "WHERE product.form = form.id and product.type = type.id and " +
                "product.creator = creator.id and att_list.product = product.id and " +
                "att_list.att = " + att;
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6), reader.GetString(7).Split(' ')[0]));
            }
            DBHelper.GetConnect().Close();
            return products;
        }

        public static List<Product> GetProduct(int att, int product)
        {
            List<Product> products = new List<Product>();
            string query = String.Format("select att_list.id, product.title, form.title, type.title, creator.title, " +
                "att_list.price, att_list.count, att_list.date " +
                "from product, form, type, creator, att_list " +
                "WHERE product.form = form.id and product.type = type.id and " +
                "product.creator = creator.id and att_list.product = product.id and " +
                "att_list.att = {0}, att_list.product = {1}", att, product);
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetDouble(5), reader.GetInt32(6), reader.GetString(7).Split(' ')[0]));
            }
            DBHelper.GetConnect().Close();
            return products;
        }
    }
}
