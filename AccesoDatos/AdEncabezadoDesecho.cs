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

        public static bool AgregarEncabezado(DEncabezadoDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                  
                //insertar encabezado
               
                    var consulta = "insert into encabezado_ingreso values(@iden,@fecha,@idem,@idcen)";
                    var cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@iden", c.Idencabezado);
                    cmd.Parameters.AddWithValue("@fecha", c.fecharealizado);
                    cmd.Parameters.AddWithValue("@idem", c.idempleado);
                    cmd.Parameters.AddWithValue("@idcen", c.idcentro);
                    cn.Open();
                    var r1 = Convert.ToBoolean(cmd.ExecuteNonQuery());
                return r1;
            }

        }

        public static bool DetalleEncabezado(DEncabezadoDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                Boolean r2 = false;
                var cmd = new MySqlCommand();
                //obtenemos el id del ultimo ingreso para guardar el detalle del ingreso 
                //var consultamax = "Select ifnull(max(Id_Encabezado),0) from encabezado_ingreso";
                //cmd = new MySqlCommand(consultamax, cn);
                //var maxid = Convert.ToInt32(cmd.ExecuteScalar());

                //insertar detalle
                cn.Open();
                var consultadetalle = "insert into detalle_ingreso values(@iden,@idde,@idve,@idd,@can)";
                foreach (DDetalleIngreso lista in c.listardetalle)
                {
                    cmd = new MySqlCommand(consultadetalle, cn);
                    cmd.Parameters.AddWithValue("@iden", lista.idencabezado);
                    cmd.Parameters.AddWithValue("@idde", lista.iddetalle);
                    cmd.Parameters.AddWithValue("@idve", lista.idVehiculo);
                    cmd.Parameters.AddWithValue("@idd", lista.iddesecho);
                    cmd.Parameters.AddWithValue("@can", lista.cantidad);
                 r2 = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
              return r2;
            }
        }

        public static int Idencabezado()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select ifnull (max(Id_Encabezado),0) from encabezado_ingreso";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //id detalle
        public static int Iddetalle()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                
                var iddetalle = "Select ifnull(max(Id_Detalle),0) from detalle_ingreso";
                var cmd = new MySqlCommand(iddetalle, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        public static bool EliminarEncabezado(int id)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "DELETE FROM encabezado_ingreso WHERE Id_Encabezado=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool eliminardetalle(int id)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "DELETE FROM detalle_ingreso WHERE Id_Detalle=@id";
                MySqlCommand cmd = new MySqlCommand(consulta,cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
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

        //reporte Produccion por Zona De Gestion

        public static DataTable ProduccionPorZonaDeGestion(int zonagestion,DateTime fecha, DateTime fecha1)
        {
          
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "ProduccionPorZonaGestionDetalleIngreso";

                cmd.Parameters.AddWithValue("@zonagestion", zonagestion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cn.Open();
            MySqlDataAdapter mdatos = new MySqlDataAdapter(cmd);
            DataTable dtdatos = new DataTable();
            mdatos.Fill(dtdatos);
            return dtdatos;
           
        }
    }
}
