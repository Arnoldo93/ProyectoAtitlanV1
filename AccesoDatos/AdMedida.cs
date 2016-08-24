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
    public class AdMedida
    {
        // metodos
        public static DMedida EntidadMedida(MySqlDataReader entidad)
        {
            var e = new DMedida();
            e.Id_medida = Convert.ToInt32(entidad["Id_Medida"]);
            e.Nombre = Convert.ToChar(entidad["Medida"]);
            return e;
        }

        //Listar
        public static List<DMedida> ListaMedida()
        {
            var lista = new List<DMedida>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from medida";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadMedida(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DMedida c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into medida values(@id,@nombre)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DMedida c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update medida set Id_Medida=@id, Medida=@nombre where Id_Medida=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from medida where Id_Medida=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_medida);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
