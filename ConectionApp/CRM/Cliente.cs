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
    public class Cliente
    {
        public long CODIGOCLIENTE { get; set; }
        public string NOMBRECOMPLETO { get; set; }
        public string IDENTIFICACION { get; set; }
        public string codigo_operacion { get; set; }
        public double monto_aprobado { get; set; }
        public int codigo_moneda { get; set; }
        public string situacion_operacion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string tipopersona { get; set; }
        public string Oficina { get; set; }
  
        public List<Cliente> GetFilterClientesMicrofin(string strCriterio)
        {
            MysqlDBMicrofin _connect = new MysqlDBMicrofin();
            DataTable dt = new DataTable();
            List<Cliente> myCliente = new List<Cliente>();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "sp_clientes_activos";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);

               DataRow[] dr = dt.Select("nombre_completo like '%" + strCriterio + "%' OR valor_documento_identificacion like '%" + strCriterio + "%'");

                foreach(DataRow x in dr)
                {   
                    Cliente cli = new Cliente();
                    cli.CODIGOCLIENTE = long.Parse(x["codigo_cliente"].ToString());
                    cli.NOMBRECOMPLETO = x["nombre_completo"].ToString();
                    cli.IDENTIFICACION = x["valor_documento_identificacion"].ToString();
                    cli.codigo_operacion = x["codigo_operacion"].ToString();
                    cli.monto_aprobado = double.Parse(x["monto_aprobado"].ToString());
                    cli.codigo_moneda = int.Parse(x["codigo_moneda"].ToString());
                    cli.situacion_operacion = x["situacion_operacion"].ToString();
                    cli.telefono = x["telefono_movil_1"].ToString();
                    cli.email = x["correo_electronico_1"].ToString();
                    cli.tipopersona = x["tipo_persona"].ToString();
                    cli.Oficina = x["descripcion_oficina"].ToString();
                    
                    myCliente.Add(cli);
                }


            }
            _connect.Close();
            return myCliente;
        }

        public Cliente GetIdClientesMicrofin(string codOperacion)
        {
            MysqlDBMicrofin _connect = new MysqlDBMicrofin();
            DataTable dt = new DataTable();
            Cliente cli = new Cliente();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "sp_clientes_activos";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;


                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);

                DataRow[] dr = dt.Select("codigo_operacion = '" + codOperacion + "'");

                foreach (DataRow x in dr)
                {
                   
                    cli.CODIGOCLIENTE = long.Parse(x["codigo_cliente"].ToString());
                    cli.NOMBRECOMPLETO = x["nombre_completo"].ToString();
                    cli.IDENTIFICACION = x["valor_documento_identificacion"].ToString();
                    cli.codigo_operacion = x["codigo_operacion"].ToString();
                    cli.monto_aprobado = double.Parse(x["monto_aprobado"].ToString());
                    cli.codigo_moneda = int.Parse(x["codigo_moneda"].ToString());
                    cli.situacion_operacion = x["situacion_operacion"].ToString();
                    cli.telefono = x["telefono_movil_1"].ToString();
                    cli.email = x["correo_electronico_1"].ToString();
                    cli.tipopersona = x["tipo_persona"].ToString();
                    cli.Oficina = x["descripcion_oficina"].ToString();
                }


            }
            _connect.Close();
            return cli;
        }
    }

}

