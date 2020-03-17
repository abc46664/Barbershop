using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BarberShop
{
    class DBStruct
    {
        public bool Init()
        {
            string db = AppDomain.CurrentDomain.BaseDirectory + "barbershop.db";
            if (!File.Exists(db))
            {

            }
        }
    }
}
