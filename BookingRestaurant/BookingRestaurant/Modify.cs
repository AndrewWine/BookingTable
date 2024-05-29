using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingRestaurant
{
    class Modify
    {
        public Modify() 
        { 
        }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public List<Account> accounts (string query)// check tai khoan
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) 
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    accounts.Add(new Account(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return accounts;
        }
        public void  Command(string query) // dung de dang ky tai khoan 
        {
            using (SqlConnection sqlConnection= Connection.GetSqlConnection()) 
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand (query, sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi truy van
                sqlConnection.Close();
            }
        }
    }
}
