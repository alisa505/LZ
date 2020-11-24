using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Globals
{
     public class User
    {
        static public long m_ID;
        static public string m_Login;
        static public string Getname()
        {
            return m_Login;
        }
        static public bool loginuser(string login, string passwort)
        {
            if (String.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(passwort))
            {
                MessageBox.Show("Не верный логин или пароль");
                return false;
            }
            if (!checklogin(login, passwort))
            {
                MessageBox.Show("Не верный логин или пароль");
                return false;
            }
            return true;
               


        }
        static public bool checklogin(string login, string passwort)
        {
            bool ok = false;
            SqlCommand smd = dataBase.SQL.GetDB().CreateCommand();
            smd.CommandText = @String.Format("select id from [auth] where login = '{0}'", login);
            SqlDataReader sqlDataReader = smd.ExecuteReader();
            ok = sqlDataReader.HasRows;
            if (!ok)
            {
                sqlDataReader.Close();
                return false;
            }
            sqlDataReader.Close();
           
            smd.CommandText = @String.Format("select id from [auth] where login = '{0}' and password = '{1}'", login, passwort);
            sqlDataReader = smd.ExecuteReader();
            ok = sqlDataReader.HasRows;
            if (!ok) 
            {
                sqlDataReader.Close();
                return false;
            }

            return false; 
            
        }
    }

}
