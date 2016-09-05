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
    public class AdZona
    {
        // metodos
        public static DZona EntidadZona(MySqlDataReader entidad)
        {
            var e = new DZona();
            e.Id_zona = Convert.ToInt32(entidad["Id_Zona"]);
            e.Nombrezona = Convert.ToString(entidad["Nombre"]);
            return e;
        }

        ////Listar
        //public static List<DZona> Lista()
        //{
        //    var lista = new List<DZona>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from zona_gestiom";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadZona(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DZona c)
        {
        try {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "insertarZonaGestion";
                cmd.Parameters.AddWithValue("@id", c.Id_zona);
                cmd.Parameters.AddWithValue("@nom", c.Nombrezona);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DZona c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "ActualizarZonaGestion";
                cmd.Parameters.AddWithValue("@id", c.Id_zona);
                cmd.Parameters.AddWithValue("@nom", c.Nombrezona);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        //metodo para verificar si existe
        public static bool Existe(DZona u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,1) from zona_gestiom where Nombre=@nom";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", u.Nombrezona);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DZona c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarZonaGestion";
                cmd.Parameters.AddWithValue("@id", c.Id_zona);
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
                var consulta = "select IFNULL (max(Id_Zona),0) from zona_gestiom";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaZona()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from zona_gestiom";
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
