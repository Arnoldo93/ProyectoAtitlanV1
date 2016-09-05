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
    public class AdSubcategoriaDesecho
    {
        // metodos
        public static DSubcategoriaDesecho EntidadSubCategoria(MySqlDataReader entidad)
        {
            var e = new DSubcategoriaDesecho();
            e.Id_SubCategoria = Convert.ToInt32(entidad["Id_SubCategoria"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            e.Id_Categoria = Convert.ToInt32(entidad["Id_Categoria"]);
            e.Id_Familia = Convert.ToInt32(entidad["Id_Familia"]);
            return e;
        }

        //Listar
        //public static List<DSubcategoriaDesecho> ListaSubcategoria()
        //{
        //    var lista = new List<DSubcategoriaDesecho>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from subcategoria_desecho";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadSubCategoria(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DSubcategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarSubCategoriaDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idcat", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DSubcategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarSubCategoiraDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idcat", c.Id_Categoria);
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
        public static bool Existe(DSubcategoriaDesecho u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,0) from subcategoria_desecho where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DSubcategoriaDesecho c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarSubCategoriaDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
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
                var consulta = "select IFNULL (max(Id_SubCategoria),0) from subcategoria_desecho";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaSubcategoria()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "SELECT Id_SubCategoria,subcategoria_desecho.Nombre as SubCategoria ,categoria_desecho.Id_Categoria,categoria_desecho.Nombre as Categoria,familia.Id_Familia,familia.Nombre as Familia  FROM subcategoria_desecho,categoria_desecho,familia where subcategoria_desecho.Id_Categoria=categoria_desecho.Id_Categoria and categoria_desecho.Id_Familia=familia.Id_Familia";
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
