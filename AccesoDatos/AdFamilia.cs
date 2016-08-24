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
    public class AdFamilia
    {
        // metodos
        public static DFamilia EntidadFamilia(MySqlDataReader entidad)
        {
            var e = new DFamilia();
            e.Id_Familia = Convert.ToInt32(entidad["Id_Familia"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            return e;
        }

        //Listar
        public static List<DFamilia> ListaFamilia()
        {
            var lista = new List<DFamilia>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from familia";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadFamilia(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DFamilia c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into familia values(@id,@nombre)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Familia);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DFamilia c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update familia set Id_Familia=@id, Nombre=@nombre where Id_Familia=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Familia);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DFamilia u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,1) from familia where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DFamilia c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from familia where Id_Familia=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Familia);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
