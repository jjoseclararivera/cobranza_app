using ConectionApp.DBContextMySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

namespace ConectionApp
{
    public class Solicitud
    {
        public long codigounico { get; set; }
        public string tiporeclamo { get; set; }
        public string cliente { get; set; }
        public string motivo { get; set; }
        public string solicita { get; set; }  
        public DateTime fechavence { get; set; }
        public string status { get; set; }

        public string dstracking { get; set; }
        public string newstatus { get; set; }

        public int diasvence { get; set; }

        public long Insert(Dictionary<string, string> data)
        {
            MysqlDBCore _connect = new MysqlDBCore();
            DataTable dt = new DataTable();
            long num = 0;

            try
            {
                if (_connect.Open())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "CRM_SP_SOLICITUD";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = _connect.Connection;

                    comando.Parameters.Add("pmodo", MySqlDbType.Int32).Value = 1;
                    comando.Parameters.Add("pcodigounico", MySqlDbType.Int64).Value = 0;
                    comando.Parameters.Add("pfecha", MySqlDbType.DateTime).Value = DateTime.Parse(data["fecha"]);
                    comando.Parameters.Add("ptiporeclamo", MySqlDbType.VarChar, 100).Value = data["tiporeclamo"];
                    comando.Parameters.Add("psucursal", MySqlDbType.VarChar, 100).Value = data["sucursal"];
                    comando.Parameters.Add("pcliente", MySqlDbType.VarChar, 250).Value = data["cliente"];
                    comando.Parameters.Add("pcodigo_operacion", MySqlDbType.VarChar, 50).Value = data["codigo_operacion"];
                    comando.Parameters.Add("pcedula", MySqlDbType.VarChar, 100).Value = data["cedula"];
                    comando.Parameters.Add("ptelefono", MySqlDbType.VarChar, 100).Value = data["telefono"];
                    comando.Parameters.Add("pemail", MySqlDbType.VarChar, 100).Value = data["email"];
                    comando.Parameters.Add("pdepartamento", MySqlDbType.VarChar, 100).Value = data["departamento"];
                    comando.Parameters.Add("pmunicipio", MySqlDbType.VarChar, 100).Value = data["municipio"];
                    comando.Parameters.Add("pdireccion", MySqlDbType.VarChar, 250).Value = data["direccion"];
                    comando.Parameters.Add("ptpersona", MySqlDbType.VarChar, 100).Value = data["tpersona"];
                    comando.Parameters.Add("prazonsocial", MySqlDbType.VarChar, 100).Value = data["razonsocial"];
                    comando.Parameters.Add("prepresentantelegal", MySqlDbType.VarChar, 100).Value = data["representantelegal"];
                    comando.Parameters.Add("ptelrazonsocial", MySqlDbType.VarChar, 100).Value = data["telrazonsocial"];
                    comando.Parameters.Add("pemailrepresentantelegal", MySqlDbType.VarChar, 100).Value = data["emailrepresentantelegal"];
                    comando.Parameters.Add("pdirrazonsocial", MySqlDbType.VarChar, 250).Value = data["dirrazonsocial"];
                    comando.Parameters.Add("pmotivo", MySqlDbType.VarChar, 500).Value = data["motivo"];
                    comando.Parameters.Add("psolicitud", MySqlDbType.VarChar, 500).Value = data["solicitud"];
                    comando.Parameters.Add("pdocumentos", MySqlDbType.VarChar, 250).Value = data["documentos"];
                    comando.Parameters.Add("penviorepuesta", MySqlDbType.VarChar, 100).Value = data["enviorepuesta"];
                    comando.Parameters.Add("preciberepuesta", MySqlDbType.VarChar, 100).Value = data["reciberepuesta"];
                    comando.Parameters.Add("pfecharepuesta", MySqlDbType.DateTime).Value = DateTime.Parse(data["fecharepuesta"]);
                    comando.Parameters.Add("precibidopor", MySqlDbType.VarChar, 100).Value = data["recibidopor"];
                    comando.Parameters.Add("pcargodelrecibido", MySqlDbType.VarChar, 100).Value = data["cargodelrecibido"];
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    num = Convert.ToInt64(dt.Rows[0]["num"]);

                }
                else
                {
                    throw new Exception("Error de conexion a la base de datos");
                }
            }catch(Exception ex)
            {
                throw new Exception("Error encontrado: " + ex.Message);
            }
            
            _connect.Close();

            return (num);
        }

        
        public List<Solicitud> View(string estatus)
        {
            MysqlDBCore _connect = new MysqlDBCore();
            DataTable dt = new DataTable();
            List<Solicitud> mylist = new List<Solicitud>();
            try
            {
                if (_connect.Open())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "CRM_SP_SOLICITUD_VIEW";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = _connect.Connection;

                    comando.Parameters.Add("pcodigounico", MySqlDbType.Int64).Value = 0;
                    comando.Parameters.Add("pestatus", MySqlDbType.VarChar,1).Value = estatus;
                   
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);

                    foreach (DataRow x in dt.Rows)
                    {
                        Solicitud solicitud = new Solicitud();
                        solicitud.codigounico = long.Parse(x["codigounico"].ToString());
                        solicitud.tiporeclamo = x["tiporeclamo"].ToString();
                        solicitud.cliente = x["cliente"].ToString();
                        solicitud.motivo = x["motivo"].ToString();
                        solicitud.solicita = x["solicitud"].ToString();
                        solicitud.fechavence =DateTime.Parse( x["fecharepuesta"].ToString());
                        solicitud.diasvence = (DateTime.Now - solicitud.fechavence).Days; 
                        solicitud.status = x["estatus"].ToString();
                        mylist.Add(solicitud);
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



        public List<Solicitud> View(string estatus, string strCriterio)
        {
            MysqlDBCore _connect = new MysqlDBCore();
            DataTable dt = new DataTable();
            List<Solicitud> mylist = new List<Solicitud>();
            try
            {
                if (_connect.Open())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "CRM_SP_SOLICITUD_VIEW";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = _connect.Connection;

                    comando.Parameters.Add("pcodigounico", MySqlDbType.Int64).Value = 0;
                    comando.Parameters.Add("pestatus", MySqlDbType.VarChar, 1).Value = estatus;

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(dt);

                    DataRow[] dr = dt.Select("cliente like '%" + strCriterio + "%'");

                    foreach (DataRow x in dr)
                    {
                        Solicitud solicitud = new Solicitud();
                        solicitud.codigounico = long.Parse(x["codigounico"].ToString());
                        solicitud.tiporeclamo = x["tiporeclamo"].ToString();
                        solicitud.cliente = x["cliente"].ToString();
                        solicitud.motivo = x["motivo"].ToString();
                        solicitud.solicita = x["solicitud"].ToString();
                        solicitud.fechavence = DateTime.Parse(x["fecharepuesta"].ToString());
                        solicitud.diasvence = (DateTime.Now - solicitud.fechavence).Days;
                        solicitud.status = x["estatus"].ToString();
                        mylist.Add(solicitud);
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

    }

    


}
