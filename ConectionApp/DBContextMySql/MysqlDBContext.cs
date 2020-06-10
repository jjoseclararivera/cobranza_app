using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace ConectionApp.DBContextMySql
{
    class MysqlDBCore
    {

        string StringConnexionCore = WebConfigurationManager.ConnectionStrings["CoreDBContext"].ToString();
        public MySqlConnection Connection;

        public MysqlDBCore()
        {
            Connection = new MySqlConnection(StringConnexionCore);
        }

        public bool Open()
        {
            try
            {
                Connection.Open();
                
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
        }
        public bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }

        }


    }

    class MysqlDBMicrofin
    {
        string StringConnexionMicrofin = WebConfigurationManager.ConnectionStrings["MicroFinDBContext"].ToString();
        public MySqlConnection Connection;
        public MysqlDBMicrofin()
        {
            Connection = new MySqlConnection(StringConnexionMicrofin);
        }

        public bool Open()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
        }
        public bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }

        }


    }

}