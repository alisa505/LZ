using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

            return true; 
            
        }

        static public bool checkname(string name)
        {
            string[] name1;
            name1 = name.Split(' ');
            if (name1.Length < 3 || name1.Length > 3)
                return false;
            if (string.IsNullOrWhiteSpace(name1[0]))
                return false;
            if (string.IsNullOrWhiteSpace(name1[1]))
                return false;
            if (string.IsNullOrWhiteSpace(name1[2]))
                return false;
            return true; 
        }
        static public bool checkdate(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return false;

            return true;
        }

        static public bool checkphone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            return true;
        }
         
        static public bool checkemail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            bool ok = false;
            SqlCommand smd = dataBase.SQL.GetDB().CreateCommand();
            smd.CommandText = @String.Format("select id from [auth] where login = '{0}'", email);
            SqlDataReader sqlDataReader = smd.ExecuteReader();
            ok = sqlDataReader.HasRows;
            if (!ok)
            {
                sqlDataReader.Close();
                return false;
            }
            sqlDataReader.Close();
            return true;
        }
        static public bool checkpassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMinimum8Chars = new Regex(@".{8,}");

            bool IsValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
            return IsValidated;
        }

    }


}
