using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;

namespace AccesoDatos
{
    public class AdTipoDeCliente
    {
        // metodos
        public static DTipoDeCliente EntidadTipoCliente(MySqlDataReader entidad)
        {

            var e = new DTipoDeCliente();
            e.Idtipo = Convert.ToInt32(entidad["Id_Categoria"]);
            e.nombretipo = Convert.ToString(entidad["Nombre"]);
            return e;
        }

        public static bool Agregar(DTipoDeCliente c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into categoria_cliente values(@id,@nombre)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cmd.Parameters.AddWithValue("@nombre", c.nombretipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool Actualizar(DTipoDeCliente c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update categoria_cliente set Id_Categoria=@id, Nombre=@nombre where Id_Categoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cmd.Parameters.AddWithValue("@nombre", c.nombretipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }
        //Eliminar

        public static bool Eliminar(DTipoDeCliente c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from categoria_cliente where Id_Categoria=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        //Id ultimo ingresado
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Categoria),0) from categoria_cliente";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //listado
        public static DataTable ListaTipoDeCliente()
        {
            string Consulta = "Select * From categoria_cliente";
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }
    }
}
