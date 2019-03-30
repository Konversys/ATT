﻿using ATT.Model.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Type = ATT.Model.Models.Type;

namespace ATT.Model.Database
{
    class DBQueries
    {
        #region Catalog
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
        #endregion

        #region MainWindow
        public static ProductATT GetProductATT(int att, int product_id)
        {
            ProductATT product = new ProductATT();
            string query = "SELECT att_list.id, product.title, active.title as active, box.title as box, " +
                "product.count as inside, measures.title as measures, creator.title as creator, " +
                "form.title as form, type.title as type, product.recipe as recipe, att_list.count as count, " +
                "att_list.price as price, att_list.date as date, att_list.valid as valid, att_list.arrival as arrival " +
                "FROM att_list, product, box, creator, form, type, active, measures " +
                "WHERE att_list.product = product.id AND product.active = active.id " +
                "AND product.box = box.id AND product.creator = creator.id " +
                "AND product.measures = measures.id AND product.form = form.id " +
                $"AND product.type = type.id AND att_list.att = {att} " +
                $"AND att_list.id = {product_id}";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product.id = reader.GetInt32(0);
                product.title = reader.GetString(1);
                product.active = reader.GetString(2);
                product.box = reader.GetString(3);
                product.inside = reader.GetString(4);
                product.measures = reader.GetString(5);
                product.creator = reader.GetString(6);
                product.form = reader.GetString(7);
                product.type = reader.GetString(8);
                product.count = reader.GetInt32(10);
                product.price = reader.GetDouble(11);
                product.date = reader.GetString(12).Split(' ')[0];
                product.valid = reader.GetString(13).Split(' ')[0];
                product.arrival = reader.GetString(14).Split(' ')[0];
                if (reader.GetBoolean(9))
                    product.recipe = "Да";
                else
                    product.recipe = "Нет";
            }
            DBHelper.GetConnect().Close();
            return product;
        }

        public static List<ProductATT> GetProductsATT(int att)
        {
            List<ProductATT> products = new List<ProductATT>();
            string query = "SELECT att_list.id, product.title, active.title as active, box.title as box, " +
                "product.count as inside, measures.title as measures, creator.title as creator, " +
                "form.title as form, type.title as type, product.recipe as recipe, att_list.count as count, " +
                "att_list.price as price, att_list.date as date, att_list.valid as valid, att_list.arrival as arrival " +
                "FROM att_list, product, box, creator, form, type, active, measures " +
                "WHERE att_list.product = product.id AND product.active = active.id " +
                "AND product.box = box.id AND product.creator = creator.id " +
                "AND product.measures = measures.id AND product.form = form.id " +
                "AND product.type = type.id AND att_list.att = " + att;
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProductATT product = new ProductATT()
                {
                    id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    active = reader.GetString(2),
                    box = reader.GetString(3),
                    inside = reader.GetString(4),
                    measures = reader.GetString(5),
                    creator = reader.GetString(6),
                    form = reader.GetString(7),
                    type = reader.GetString(8),
                    count = reader.GetInt32(10),
                    price = reader.GetDouble(11),
                    date = reader.GetString(12).Split(' ')[0],
                    valid = reader.GetString(13).Split(' ')[0],
                    arrival = reader.GetString(14).Split(' ')[0],
                };
                if (reader.GetBoolean(9))
                    product.recipe = "Да";
                else
                    product.recipe = "Нет";
                products.Add(product);
            }
            DBHelper.GetConnect().Close();
            return products;
        }

        public static bool AddCheque(int att, int person, List<ProductATT> products)
        {
            int cheque_id = -1;
            string query_insertCheque = $"INSERT INTO cheque (person, date, att) VALUES({person}, NOW(), {att})";
            string query_lastId = "SELECT MAX(id) from cheque";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query_insertCheque;
            if (command.ExecuteNonQuery() == 0)
            {
                return false;
            }
            command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query_lastId;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cheque_id = reader.GetInt32(0);
            }
            reader.Close();
            foreach (var item in products)
            {
                string query_updateCount = $"UPDATE att_list SET att_list.count = {item.count - item.sell} WHERE att_list.att = {att} AND att_list.id = {item.id}";
                command.CommandText = query_updateCount;
                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                reader.Close();
                string query_insertSale = $"INSERT INTO sale (product, cheque, count, price) VALUES({item.id}, {cheque_id}, {item.sell}, {item.sell * item.price})";
                command.CommandText = query_insertSale;
                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                reader.Close();
            }
            DBHelper.GetConnect().Close();
            return true;
        }
        #endregion

        #region History
        public static List<ChequeView> GetCheques(int att)
        {
            List<ChequeView> items = new List<ChequeView>();
            string query = $"SELECT cheque.id, person.fio, cheque.date, SUM(sale.price) as sum from sale, cheque, person WHERE sale.cheque = cheque.id AND person.id = cheque.person AND cheque.att = {att} GROUP BY cheque.id";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new ChequeView()
                {
                    id = reader.GetInt32(0),
                    person = reader.GetString(1),
                    date = reader.GetDateTime(2),
                    sum = reader.GetDouble(3),
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }
        #endregion

        #region Cheque
        public static List<Sale> GetSales(int cheque)
        {
            List<Sale> items = new List<Sale>();
            string query = "SELECT sale.id, product.title, box.title as box, product.count as inside, " +
                "measures.title as measures,sale.count, att_list.price, sale.price as total " +
                "FROM sale, product, att_list, box, measures " +
                "WHERE sale.product = att_list.id AND att_list.product = product.id " +
                "AND product.measures = measures.id AND product.box = box.id " +
                $"AND sale.cheque = {cheque}";
            DBHelper.GetConnect().Open();
            MySqlCommand command = DBHelper.GetConnect().CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Sale()
                {
                    id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    box = reader.GetString(2),
                    inside = reader.GetString(3),
                    measures = reader.GetString(4),
                    count = reader.GetInt32(5),
                    price = reader.GetDouble(6),
                    total = reader.GetDouble(7),
                });
            }
            DBHelper.GetConnect().Close();
            return items;
        }
        #endregion
    }
}