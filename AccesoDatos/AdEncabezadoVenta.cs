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
    public class AdEncabezadoVenta
    {
        public static DEncabezadoVentas EntidadEncabezadoventas(MySqlDataReader entidad)
        {

            var e = new DEncabezadoVentas();
            e.idventa = Convert.ToInt32(entidad["Id_Venta"]);
            e.total = Convert.ToDecimal(entidad["Total"]);
            e.fecharealizado = Convert.ToDateTime(entidad["FechaRealizado"]);
            e.idempleado = Convert.ToInt32(entidad["Id_Empleado"]);
            e.idmoneda = Convert.ToInt32(entidad["Id_Moneda"]);
            e.idcliente = Convert.ToInt32(entidad["Id_Cliente"]);
            e.idcentro = Convert.ToInt32(entidad["Id_Centro"]);
            return e;
        }

        //insertar encabezado

        public static bool AgregarEncabezadoventa(DEncabezadoVentas c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "INSERT INTO encabezado_venta VALUES (@idven,@tot,@fecha,@idemp,@idmon,@idclie,@idcentro)";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@idven", c.idventa);
                cmd.Parameters.AddWithValue("@tot", c.total);
                cmd.Parameters.AddWithValue("@fecha", c.fecharealizado);
                cmd.Parameters.AddWithValue("@idemp", c.idempleado);
                cmd.Parameters.AddWithValue("@idmon", c.idmoneda);
                cmd.Parameters.AddWithValue("@idclie", c.idcliente);
                cmd.Parameters.AddWithValue("@idcentro", c.idcentro);
                cn.Open();
                var r1 = Convert.ToBoolean(cmd.ExecuteNonQuery());
                return r1;
            }

        }

        //insertar detalle
        public static bool DetalleEncabezadoventa(DEncabezadoVentas c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                Boolean r2 = false;
                var cmd = new MySqlCommand();
                cn.Open();
                var consultadetalle = "INSERT INTO detalle_venta VALUES(@idventa,@iddetalleventa,@iddesecho,@cant,@precio,@subtotal);";
                foreach (DDetalleVenta lista in c.listardetalleventa)
                {
                    cmd = new MySqlCommand(consultadetalle, cn);
                    cmd.Parameters.AddWithValue("@idventa", lista.idventa);
                    cmd.Parameters.AddWithValue("@iddetalleventa", lista.iddetalleventa);
                    cmd.Parameters.AddWithValue("@iddesecho", lista.iddesecho);
                    cmd.Parameters.AddWithValue("@cant", lista.cantidad);
                    cmd.Parameters.AddWithValue("@precio", lista.precio);
                    cmd.Parameters.AddWithValue("@subtotal", lista.subtotal);
                    r2 = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                return r2;
            }
        }

        //id encabezadoventa

        public static int Idencabezadoventa()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "Select ifnull (max(Id_Venta),0) from encabezado_venta";
                var cmd = new MySqlCommand(consulta, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        public static int Iddetalleventa()
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {

                var iddetalle = "Select ifnull(max(Id_Detalle),0) from detalle_venta";
                var cmd = new MySqlCommand(iddetalle, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        public static bool EliminarEncabezadoVenta(int id)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "DELETE FROM encabezado_venta WHERE Id_Venta=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool eliminardetalleVenta(int id)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                string consulta = "DELETE FROM detalle_venta WHERE Id_Detalle=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
        }

        public static bool ActualizarTotalEncabezado(DEncabezadoVentas c)
        {
            using (MySqlConnection cn = new MySqlConnection(Conexion.Cadena))
            {
                var consulta = "update encabezado_venta set Total=@tot where Id_Venta=@id";
                var cmd = new MySqlCommand(consulta, cn);
                cmd.Parameters.AddWithValue("@id", c.idventa);
                cmd.Parameters.AddWithValue("@tot", c.total);
                cn.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

        }


    }
}
