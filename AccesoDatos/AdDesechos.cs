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
    public class AdDesechos
    {
        // metodos
        public static DDesechos EntidadDesecho(MySqlDataReader entidad)
        {
            var e = new DDesechos();
            e.Id_desecho = Convert.ToInt32(entidad["Id_Desecho"]);
            e.Nombre = Convert.ToString(entidad["Nombre"]);
            e.Id_familia = Convert.ToInt32(entidad["Id_Familia"]);
            e.Id_categoria = Convert.ToInt32(entidad["Id_Categoria"]);
            e.Id_subcategoria = Convert.ToInt32(entidad["Id_SubCategoria"]);
            e.Cantida_peso = Convert.ToDecimal(entidad["Cantidad_Peso"]);
            e.Id_medida = Convert.ToInt32(entidad["Id_Medida"]);
            e.Volumen = Convert.ToInt32(entidad["Volumen"]);
            e.Precio_costo = Convert.ToDouble(entidad["Precio_Costo"]);
            e.PrecioVenta = Convert.ToDouble(entidad["Precio_Venta"]);
            e.Estado_desecho = Convert.ToByte(entidad["Estado_desechos"]);
            return e;
        }

        ////Listar
        //public static List<DDesechos> ListaDesechos()
        //{
        //    var lista = new List<DDesechos>();
        //    using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
        //    {
        //        var consulta = " select * from desechos";
        //        var cmd = new MySqlCommand(consulta, cn);
        //        cn.Open();
        //        var dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lista.Add(EntidadDesecho(dr));
        //        }
        //        return lista;
        //    }
        //}

        //agregar

        public static bool Agregar(DDesechos c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "InsertarDesecho";

                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idfam", c.Id_familia);
                cmd.Parameters.AddWithValue("@idcat", c.Id_categoria);
                cmd.Parameters.AddWithValue("@idsubcat", c.Id_subcategoria);
                cmd.Parameters.AddWithValue("@cant", c.Cantida_peso);
                cmd.Parameters.AddWithValue("@idmedi", c.Id_medida);
                cmd.Parameters.AddWithValue("@vol", c.Volumen);
                cmd.Parameters.AddWithValue("@precos", c.Precio_costo);
                cmd.Parameters.AddWithValue("@preven", c.PrecioVenta);
                cmd.Parameters.AddWithValue("@est", c.Estado_desecho);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Actualizar(DDesechos c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "actualizarDesechos";

                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@idfam", c.Id_familia);
                cmd.Parameters.AddWithValue("@idcat", c.Id_categoria);
                cmd.Parameters.AddWithValue("@idsubcat", c.Id_subcategoria);
                cmd.Parameters.AddWithValue("@cant", c.Cantida_peso);
                cmd.Parameters.AddWithValue("@idmedi", c.Id_medida);
                cmd.Parameters.AddWithValue("@vol", c.Volumen);
                cmd.Parameters.AddWithValue("@precos", c.Precio_costo);
                cmd.Parameters.AddWithValue("@preven", c.PrecioVenta);
                cmd.Parameters.AddWithValue("@est", c.Estado_desecho);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }

        }
        //actualiza cantidad peso desde ingreso desechos
        public static bool ActualizarCantidadPeso(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update desechos set Cantidad_Peso = @cant where Nombre=@nom AND Id_Desecho=@id;";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@cant", c.Cantida_peso);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }
        //obtiene cantidadproducto en desecho
        public static int CantidadProducto(string iddesecho)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select Cantidad_Peso from desechos where Nombre=@nom";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", iddesecho);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        //obtiene cantidad en desecho de volumen
        public static int Volumen(string iddesecho)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select Volumen from desechos where Nombre=@nom";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", iddesecho);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        //actualizar volumen de ingresodesechos
        public static bool ActualizarVolumen(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update desechos set Volumen =@vol where Nombre=@nom AND Id_Desecho=@id;";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@vol", c.Volumen);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }

        //metodo para verificar si existe
        public static bool Existe(DDesechos u)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select ifnull(Nombre,1) from desechos where Nombre=@nombre";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        //Eliminar

        public static bool Eliminar(DDesechos c)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(Conexion.Cadena);
                var cmd = new MySqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "EliminarDesechos";

                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(Exception)
            {
                return false;
            }
        }

        //id
        public static int Id()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select IFNULL (max(Id_Desecho),0) from desechos";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        //Listar
        public static DataTable ListaDesecho()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "select desechos.Id_Desecho,desechos.Nombre as Desecho,desechos.Id_Familia,familia.Nombre as Familia,desechos.Id_Categoria,categoria_desecho.Nombre as Categoria, desechos.Id_SubCategoria,subcategoria_desecho.Nombre as Subcategoria,desechos.Cantidad_Peso, desechos.Id_Medida,medida.Medida,desechos.Volumen,desechos.Precio_Costo,desechos.Precio_Venta,desechos.Estado_desechos FROM desechos,familia,categoria_desecho,subcategoria_desecho,medida WHERE desechos.Id_Familia = familia.Id_Familia and desechos.Id_Categoria = categoria_desecho.Id_Categoria and desechos.Id_SubCategoria = subcategoria_desecho.Id_SubCategoria and desechos.Id_Medida = medida.Id_Medida";
                MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }

        public static DataTable listd()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select * from desechos";
                MySqlConnection cnn = new MySqlConnection(Conexion.Cadena);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }

        //obtener cantidad,volumen,precio de desechos

        public static DataTable ObtenerCantidadpesodesechos(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "Select Id_Desecho,Nombre,Cantidad_Peso,Precio_Venta from desechos where Id_Desecho=@id and Nombre=@nom";
                MySqlCommand cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                cn.Open();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }

        public static DataTable ObtenerVolumendesechos(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "Select Id_Desecho,Nombre,Volumen,Precio_Venta from desechos where Id_Desecho=@id and Nombre=@nom";
                MySqlCommand cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cmd.Parameters.AddWithValue("@nom", c.Nombre);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                cn.Open();
                mdatos.Fill(dtDatos);
                return dtDatos;
            }
        }
    }
}
