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
    public class AdMedida
    {
        // metodos
        public static DMedida EntidadMedida(MySqlDataReader entidad)
        {
            var e = new DMedida();
            e.Id_medida = Convert.ToInt32(entidad["Id_Medida"]);
            e.Nombre = Convert.ToString(entidad["Medida"]);
            return e;
        }

        ////Listar
        //public static List<DMedida> ListaMedida()
        //{
        //    var lista = new List<DMedida>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from medida";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadMedida(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DMedida c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarMedida";

                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DMedida c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarMedida";

                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DMedida u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Medida,1) from medida where Medida=@medi";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@medi", u.Id_medida);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DMedida c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarMedida";

                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        //Id ultimo ingresado
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Medida),0) from medida";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaMedida()
        {
            string Consulta = "Select * From medida";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }
    }
}
