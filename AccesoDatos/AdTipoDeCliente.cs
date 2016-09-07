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
            try
            {

                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                MySqlCommand cmd = new MySqlCommand();

                // setear parametros del command
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarCategoriaCliente";

                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cmd.Parameters.AddWithValue("@nom", c.nombretipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DTipoDeCliente c)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                MySqlCommand cmd = new MySqlCommand();

                // setear parametros del command
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarCategoriaCliente";

                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cmd.Parameters.AddWithValue("@nom", c.nombretipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }

        }
        //Eliminar

        public static bool Eliminar(DTipoDeCliente c)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                MySqlCommand cmd = new MySqlCommand();

                // setear parametros del command
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarCategoriaCliente";

                cmd.Parameters.AddWithValue("@id", c.Idtipo);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
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

        public static DataTable listacombinadatipocliente(int id)
        {
            MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
            string Consulta = "Select cliente.Id_Categoria,categoria_cliente.Nombre from cliente, categoria_cliente where cliente.Id_Categoria=categoria_cliente.Id_Categoria and cliente.Id_Cliente=@id";
            MySqlCommand cmd = new MySqlCommand(Consulta, cnn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            return dtDatos;
        }

    }
}
