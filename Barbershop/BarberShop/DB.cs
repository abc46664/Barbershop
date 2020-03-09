using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarberShop
{
    class DB
    {
        static public List<User> AllUser = new List<User>();
        static public List<Goods> AllGoods = new List<Goods>();
        static public int GetUserID(string usr)
        {
            foreach (User u in AllUser)
            {
                if (u.name == usr)
                    return u.id;
            }
            return -1;
        }
        static public int GetGoodsID(string goods)
        {
            foreach (Goods g in AllGoods)
            {
                if (g.name == goods)
                {
                    return g.id;
                }
            }
            return -1;
        }
    }
    class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public string memo { get; set; }
        public string add { get; set; }
    }
    class Goods
    {
        public int id { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public string memo { get; set; }
        public int price { get; set; }
    }
}
