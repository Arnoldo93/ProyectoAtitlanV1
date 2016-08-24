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

        //Listar
        public static List<DCategoriaDesecho> ListaCategoriaDesecho()
        {
            var lista = new List<DCategoriaDesecho>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from categoria_desecho";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadCategoriaDesecho(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DCategoriaDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into categoria_desecho values(@id,@nombre,@idfamilia)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DCategoriaDesecho c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update categoria_desecho set Id_Categoria=@id, Nombre=@nombre,Id_Familia=@idfamilia where Id_Categoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idfamilia", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from categoria_desecho where Id_Categoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Categoria);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
