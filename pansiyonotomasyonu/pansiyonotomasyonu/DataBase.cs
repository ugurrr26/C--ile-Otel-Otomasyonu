﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace pansiyonotomasyonu
{
    public class DataBase
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=UUR\SQLEXPRESS;Initial Catalog=otelotomasyonu;Integrated Security=True;MultipleActiveResultSets=True");
    }
}
