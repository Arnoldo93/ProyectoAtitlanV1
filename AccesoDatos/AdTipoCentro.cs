using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class AdTipoCentro
    {
        // metodos
        public static DTipoCentro EntidadTipoCentro(MySqlDataReader entidad)
        {
            var e = new DTipoCentro();
            e.Id_Tipocentro= Convert.ToInt32(entidad["Id_Tipo"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            return e;
        }

        //Listar
        public static List<DTipoCentro> ListaPuesto()
        {
            var lista = new List<DTipoCentro>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from tipo_centro";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadTipoCentro(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DTipoCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into tipo_centro values(@id,@nombre)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DTipoCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update tipo_centro set Id_Tipo=@id, Nombre=@nombre where Id_Tipo=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DTipoCentro u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,1) from tipo_centro where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DTipoCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from tipo_centro where Id_Tipo=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Tipocentro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
