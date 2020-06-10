using ConectionApp.DBContextMySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectionApp
{
    public class Tracking
    {
        public long codigounico { get; set; }
        public string cliente { get; set; }
        public string solicita { get; set; }
        public DateTime fechavence { get; set; }
        public string status { get; set; }
        public string dstracking { get; set; }
        public string newstatus { get; set; }
        public DateTime fechatracking { get; set; }


        public List<Tracking> View(long codigounico)
        {
            MysqlDBCore _connect = new MysqlDBCore();
            DataTable dt = new DataTable();
            List<Tracking> mylist = new List<Tracking>();
            try
            {
                if (_connect.Open())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "SELECT * FROM CRM_TRACKING where codigounico = " + codigounico.ToString();
                    comando.CommandType = CommandType.Text;
                    comando.Connection = _connect.Connection;

                    //comando.Parameters.Add("pcodigounico", MySqlDbType.Int64).Value = 0;
                    //comando.Parameters.Add("pestatus", MySqlDbType.VarChar, 1).Value = estatus;

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);

                    foreach (DataRow x in dt.Rows)
                    {
                        Tracking tracking = new Tracking();
                        tracking.codigounico = long.Parse(x["codigounico"].ToString());
                        tracking.cliente = x["cliente"].ToString();
                        tracking.solicita = x["solicita"].ToString();
                        tracking.fechavence = DateTime.Parse(x["fechavence"].ToString());
                        tracking.status = x["status"].ToString();
                        tracking.dstracking = x["dstracking"].ToString();
                        tracking.newstatus = x["newstatus"].ToString();
                        tracking.fechatracking = DateTime.Parse(x["fechatracking"].ToString());
                        mylist.Add(tracking);
                    }

                }
                else
                {
                    throw new Exception("Error de conexion a la base de datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error encontrado: " + ex.Message);
            }

            _connect.Close();

            return (mylist);
        }

        public string Insert(Tracking data)
        {
            MysqlDBCore _connect = new MysqlDBCore();
            DataTable dt = new DataTable();
            string result = "Fallo";

            try
            {
                if (_connect.Open())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "CRM_SP_TRACKING";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = _connect.Connection;

                    comando.Parameters.Add("pcodigounico", MySqlDbType.Int64).Value = data.codigounico;
                    comando.Parameters.Add("pcliente", MySqlDbType.VarChar, 100).Value = data.cliente;
                    comando.Parameters.Add("psolicita", MySqlDbType.VarChar, 500).Value = data.solicita;
                    comando.Parameters.Add("pfechavence", MySqlDbType.DateTime).Value = data.fechavence;
                    comando.Parameters.Add("pstatus", MySqlDbType.VarChar, 1).Value = data.status;
                    comando.Parameters.Add("pdstracking", MySqlDbType.VarChar, 500).Value = data.dstracking;
                    comando.Parameters.Add("pnewstatus", MySqlDbType.VarChar, 1).Value = data.newstatus;
                    comando.Parameters.Add("pfechatracking", MySqlDbType.DateTime).Value = data.fechatracking;

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    result = dt.Rows[0][0].ToString();

                }
                else
                {
                    throw new Exception("Error de conexion a la base de datos");

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error encontrado: " + ex.Message);

            }

            _connect.Close();

            return (result);
        }
    }

    


}
