using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ServicioPagos
{
    /// <summary>
    /// Summary description for ejemplo
    /// </summary>
    public class pago : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          
            try
            {
                
                Pago pago = new Pago();
                pago.Folio = int.Parse(context.Request.Form["folio"]);
                pago.Nombre = context.Request.Form["nombre"];
                pago.Concepto = context.Request.Form["concepto"];
                pago.Referencia = context.Request.Form["referencia"];
                pago.Correo = context.Request.Form["correo"];
                pago.Resultado = int.Parse(context.Request.Form["resultado"]); ;
                pago.Fecha = DateTime.Parse(context.Request.Form["fecha"]);
                pago.Importe = float.Parse(context.Request.Form["importe"]);
                pago.Terminal = int.Parse(context.Request.Form["terminal"]);
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.GuardarPagos(pago);            
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
                throw ex;
                
            }            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}