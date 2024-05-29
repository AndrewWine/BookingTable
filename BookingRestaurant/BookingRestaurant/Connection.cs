using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRestaurant
{
    class Connection
    {
        public static string stringConnection = @"Data Source = ADMIN\SQLEXPRESS; Initial Catalog = DanhSachBan; User ID = sa; Password = 123";
        public static SqlConnection GetSqlConnection() 
        { 
            return new SqlConnection(stringConnection); 
        }
    }
}
