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
    public class AdCategoriaDesecho
    {
        // metodos
        public static DCategoriaDesecho EntidadCategoriaDesecho(MySqlDataReader entidad)
        {
            var e = new DCategoriaDesecho();
            e.Id_Categoria = Convert.ToInt32(entidad["Id_Puesto"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            e.Id_Familia = Convert.ToInt32(entidad["Id_Familia"]);
            return e;
        }

        ////Listar
        //public static List<DCategoriaDesecho> ListaCategoriaDesecho()
        //{
        //    var lista = new List<DCategoriaDesecho>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from categoria_desecho";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadCategoriaDesecho(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DCategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarCategoriaDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DCategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarCategoriaDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
            

        }

        //metodo para verificar si existe
        public static bool Existe(DCategoriaDesecho u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,0) from categoria_desecho where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DCategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarCategoriaDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Categoria),0) from categoria_desecho";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaCategorias()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "SELECT categoria_desecho.Id_Categoria,categoria_desecho.Nombre,categoria_desecho.Id_Familia,familia.Nombre FROM categoria_desecho,familia where categoria_desecho.Id_Familia = familia.Id_Familia;";
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
