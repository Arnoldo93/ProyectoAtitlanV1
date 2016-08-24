using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static List<DSubcategoriaDesecho> ListaSubcategoria()
        {
            var lista = new List<DSubcategoriaDesecho>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from subcategoria_desecho";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadSubCategoria(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DSubcategoriaDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into subcategoria_desecho values(@id,@nombre,@idcat,@idfamilia)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idcat", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DSubcategoriaDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update subcategoria_desecho set Id_SubCategoria=@id, Nombre=@nombre,Id_Categoria=@idcat,Id_Familia=@idfamilia where Id_SubCategoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idcat", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from subcategoria_desecho where Id_SubCategoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_SubCategoria);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
