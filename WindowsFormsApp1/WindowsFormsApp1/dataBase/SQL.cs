using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.dataBase
{
   public class SQL
    {
        //создаем метод к базе данных
        static SqlConnection sqlConnection = new SqlConnection();
        //подключение к базе данных
        static public void ConnectDB()

        {
            sqlConnection.Close();
            sqlConnection.ConnectionString = Properties.Settings.Default.SQLconnecteon;
            sqlConnection.Open();
        }
        // возращает подключение к базу данных
        static public SqlConnection GetDB() { return sqlConnection; }
      
    }
}
