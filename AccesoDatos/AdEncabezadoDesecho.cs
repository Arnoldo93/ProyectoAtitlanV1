using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;

namespace AccesoDatos
{
    public class AdEncabezadoDesecho
    {
        public static DEncabezadoDesecho EntidadEncabezado(MySqlDataReader entidad)
        {

            var e = new DEncabezadoDesecho();
            e.Idencabezado = Convert.ToInt32(entidad["Id_Encabezado"]);
            e.fecharealizado = Convert.ToDateTime(entidad["FechaRealizado"]);
            e.idempleado = Convert.ToInt32(entidad["Id_Empleado"]);
            e.idcentro = Convert.ToInt32(entidad["Id_Centro"]);
            return e;
        }

        //Listar
        public static List<DEncabezadoDesecho> ListaEncabezadoIngreso(DateTime fech_ini,DateTime fech_fin)
        {
            var lista = new List<DEncabezadoDesecho>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from encabezado_ingreso where FechaRealizado>=@fech_ini and FechaRealizado<=@fech_fin ";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@fech_ini", fech_ini);
                cmd.Parameters.AddWithValue("@fech_fin", fech_fin);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadEncabezado(dr));
                }
                return lista;
            }
        }

        public static bool Agregar(DEncabezadoDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into encabezado_ingreso values(@iden,@fecha,@idem,@idcen)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@iden", c.Idencabezado);
                cmd.Parameters.AddWithValue("@fecha", c.fecharealizado);
                cmd.Parameters.AddWithValue("@idem", c.idempleado);
                cmd.Parameters.AddWithValue("@idcen", c.idcentro);
                cn.Open();
                var r1= Convert.ToBoolean(cmd.ExecuteNonQuery());
                consulta = "Select isnull(max(Id_Encabezado),0) from encabezado_ingreso";
                cmd = new MySqlCommand(consulta,cn);
                var maxid =Convert.ToInt32(cmd.ExecuteScalar());
                //obtenemos el id del ultimo ingreso para guardar el detalle del ingreso 

                consulta = "insert into detalle_ingreso values(@iden,@idde,@idve,@idde,@can)";
                foreach(DDetalleIngreso lista in c.listardetalle)
                {
                    cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@iden", maxid);
                    cmd.Parameters.AddWithValue("@idde", lista.iddetalle);
                    cmd.Parameters.AddWithValue("@idve", lista.idVehiculo);
                    cmd.Parameters.AddWithValue("@idde", lista.iddesecho);
                    cmd.Parameters.AddWithValue("@can", lista.cantidad);
                    r1 = r1 && Convert.ToBoolean(cmd.ExecuteNonQuery()); 
                }
                return r1;


            }
        }

        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Encabezado),0) from encabezado_ingreso";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        public static DataTable ListaDeDechosDetalle ()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "Select Id_Desecho,Nombre from desechos ";
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta,cn);
                DataTable dtDatos = new DataTable();
                cn.Open();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }

        }
    }
}
