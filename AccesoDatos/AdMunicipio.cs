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
    public class AdMunicipio
    {
        // metodos
        public static DMunicipio EntidadMunicipio(MySqlDataReader entidad)
        {
            var e = new DMunicipio();
            e.Id_Municipio = Convert.ToInt32(entidad["Id_Municipio"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            e.Id_zona = Convert.ToInt32(entidad["Id_Zona"]);
            return e;
        }

        //Listar
        //public static List<DMunicipio> Listamunicipios()
        //{
        //    var lista = new List<DMunicipio>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from municipio";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadMunicipio(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DMunicipio c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into municipio values(@id,@nombre,@idzona)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idzona", c.Id_zona);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DMunicipio c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update municipio set Id_Municipio=@id, Nombre=@nombre,Id_Zona=@idzona where Id_Municipio=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Municipio);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@idzona", c.Id_zona);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DMunicipio u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,1) from municipio where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DMunicipio c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from municipio where Id_Municipio=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_Municipio);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
        //Id
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Municipio),0) from municipio";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaMunicipio()
        {
            string Consulta = "SELECT  municipio.Id_Municipio,municipio.Nombre as Municipio,municipio.Id_Zona,zona_gestiom.Nombre as Zona FROM municipio, zona_gestiom where municipio.Id_Zona = zona_gestiom.Id_Zona";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }
    }
}
