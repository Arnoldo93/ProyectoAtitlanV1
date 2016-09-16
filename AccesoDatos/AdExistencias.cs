using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AdExistencias
    {
        // metodos
        public static DExistencias EntidadExistencias(MySqlDataReader entidad)
        {
            var e = new DExistencias();
            //idexistencias es autonumerico
            e.idcentro = Convert.ToInt32(entidad["centro_Id_Centro"]);
            e.iddesecho = Convert.ToInt32(entidad["desechos_Id_Desecho"]);
            e.preciocosto = Convert.ToDouble(entidad["Precio_Costo"]);
            e.precioventa = Convert.ToDouble(entidad["Precio_Venta"]);
            e.cantidadpeso = Convert.ToDouble(entidad["Peso"]);
            e.cantidadvolumen = Convert.ToUInt64(entidad["Volumen"]);
            return e;
        }

        public static bool AgregaryActualizar(DExistencias c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "Existencias";

                cmd.Parameters.AddWithValue("@idcentro", c.idcentro);
                cmd.Parameters.AddWithValue("@iddesecho", c.iddesecho);
                cmd.Parameters.AddWithValue("@precost", c.preciocosto);
                cmd.Parameters.AddWithValue("@preven", c.precioventa);
                cmd.Parameters.AddWithValue("@canpeso", c.cantidadpeso);
                cmd.Parameters.AddWithValue("@volum", c.cantidadvolumen);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ActualizarExistenciaPorVenta(DExistencias c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "ActualizarExistencias";

                cmd.Parameters.AddWithValue("@idcentro", c.idcentro);
                cmd.Parameters.AddWithValue("@iddesecho", c.iddesecho);
                cmd.Parameters.AddWithValue("@canpeso", c.cantidadpeso);
                cmd.Parameters.AddWithValue("@volum", c.cantidadvolumen);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Eliminar(DExistencias c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarExistencias";

                cmd.Parameters.AddWithValue("@idcentro", c.idcentro);
                cmd.Parameters.AddWithValue("@iddesecho", c.iddesecho);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable pesoyvolumen(DExistencias c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select ifnull(Peso,0.0),ifnull(Volumen,0.0),ifnull(Precio_Costo,0.0),ifnull(Precio_Venta,0.0) from existencias where centro_Id_Centro=@idcentro and desechos_Id_Desecho=@iddesecho ";
                var cmdd = new MySqlCommand(consulta, cn);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(cmdd);
                DataTable dtDatos = new DataTable();
                cmdd.Parameters.AddWithValue("@idcentro", c.idcentro);
                cmdd.Parameters.AddWithValue("@iddesecho", c.iddesecho);
                cn.Open();
                mdatos.Fill(dtDatos);
                return dtDatos;

            }
        }
    }
}
