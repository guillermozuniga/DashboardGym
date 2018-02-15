using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace ServicioPagos
{
    public class AccesoDatos
    {
        public void GuardarPagos(Pago pago)
        {
            string Cadenaconexion;
            Cadenaconexion = Utilidades.ObtenerConexion();
            SqlConnection conexion = new SqlConnection(Cadenaconexion);
            
            SqlCommand Commando = new SqlCommand("usp_GrabarPagos", conexion);
            Commando.CommandType = CommandType.StoredProcedure;
            Commando.Parameters.AddWithValue("folio",pago.Folio);
            Commando.Parameters.AddWithValue("nombre", pago.Nombre);
            Commando.Parameters.AddWithValue("concepto", pago.Concepto);
            Commando.Parameters.AddWithValue("correo", pago.Correo);
            Commando.Parameters.AddWithValue("referencia", pago.Referencia);
            Commando.Parameters.AddWithValue("resultado", pago.Resultado);
            Commando.Parameters.AddWithValue("fecha", pago.Fecha);
            Commando.Parameters.AddWithValue("importe", pago.Importe);
             Commando.Parameters.AddWithValue("terminal", pago.Terminal);
            try 
            {
                 conexion.Open();
             Commando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //context.Response.Write(ex.Message);
                throw ex;
                }
                finally
            {
                conexion.Close();
            }
               


             

           
        }

    }
}