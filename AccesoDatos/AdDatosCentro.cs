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
    public class AdDatosCentro
    {
        // metodos
        public static DDatosCentro EntidadDatosCentro(MySqlDataReader entidad)
        {
            var e = new DDatosCentro();
            e.Id_Centro = Convert.ToInt32(entidad["Id_Centro"]);
            e.Nombre = Convert.ToString(entidad["Nombre_centro"]);
            e.Id_Municipio = Convert.ToInt32(entidad["Id_Municipio"]);
            e.Id_tipo = Convert.ToInt32(entidad["Id_Tipo"]);
            e.Telefono = Convert.ToInt32(entidad["Telefono"]);
            e.Direccion = Convert.ToString(entidad["Direccion"]);
            e.Estado = Convert.ToByte(entidad["Estado_centro"]);
            return e;
        }

        //Listar
        public static List<DDatosCentro> ListaDatosCentro()
        {
            var lista = new List<DDatosCentro>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from centro";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadDatosCentro(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DDatosCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into centro values(@id,@nom,@idmuni,@idtipo,@tel,@dir,@esta)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idmuni", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@idtipo", c.Id_tipo);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@esta", c.Estado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DDatosCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update centro set Id_Centro=@id,Nombre_centro=@nom ,Id_Municipio=@idmuni,Id_Tipo=@idtipo,Telefono=@tel,Direccion=@dir,Estado_centro=@esta where Id_Centro=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idmuni", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@idtipo", c.Id_tipo);
                cmd.Parameters.AddWithValue("@tel", c.Telefono);
                cmd.Parameters.AddWithValue("@dir", c.Direccion);
                cmd.Parameters.AddWithValue("@esta", c.Estado);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DDatosCentro u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre_centro,1) from centro where Nombre_centro=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DDatosCentro c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from centro where Id_Centro=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Centro);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
