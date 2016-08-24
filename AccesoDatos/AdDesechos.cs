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

        //Listar
        public static List<DDesechos> ListaDesechos()
        {
            var lista = new List<DDesechos>();
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = " select * from desechos";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(EntidadDesecho(dr));
                }
                return lista;
            }
        }

        //agregar

        public static bool Agregar(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "insert into desechos values(@id,@nom,@idfam,@idcat,@idsubcat,@cant,@idmedi,@vol,@precos,@preven,@est)";
                var cmd = new MySqlCommand(consulta, cn);
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
        }

        public static bool Actualizar(DDesechos c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update desechos set Id_Desecho = @id,Nombre = @nom,Id_Familia = @idfam,Id_Categoria = @idcat,Id_SubCategoria = @idsubcat,Cantidad_Peso = @cant,Id_Medida = @idmedi,Volumen = @vol,Precio_Costo = @precos,Precio_Venta = @preven,Estado_desechos = @est  where Id_desecho=@id";
                var cmd = new MySqlCommand(consulta, cn);
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
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "delete from desechos where Id_Desecho=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.Id_desecho);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }
    }
}
