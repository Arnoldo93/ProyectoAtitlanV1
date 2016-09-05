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
    public class AdVehiculo
    {
        // metodos
        public static DVehiculo EntidadVehiculo(MySqlDataReader entidad)
        {
            var e = new DVehiculo();
            e.Idvehiculo = Convert.ToInt32(entidad["Id_Vehiculo"]);
            e.Nombrevehiculo = Convert.ToString(entidad["Vehiculo"]);
            e.Volumen = Convert.ToInt32(entidad["volumen"]);
            return e;
        }

        //agregar

        public static bool Agregar(DVehiculo c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText= "insertarVehiculo";

                cmd.Parameters.AddWithValue("@id", c.Idvehiculo);
                cmd.Parameters.AddWithValue("@nombre", c.Nombrevehiculo);
                cmd.Parameters.AddWithValue("@vol", c.Volumen);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DVehiculo c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarVehiculo";

                cmd.Parameters.AddWithValue("@id", c.Idvehiculo);
                cmd.Parameters.AddWithValue("@nombre", c.Nombrevehiculo);
                cmd.Parameters.AddWithValue("@vol", c.Volumen);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar

        public static bool Eliminar(DVehiculo c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarVehiculo";

                cmd.Parameters.AddWithValue("@id", c.Idvehiculo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }
        // Id
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Vehiculo),0) from vehiculo";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaVehiculos()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from vehiculo";
                MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }
    }
}
