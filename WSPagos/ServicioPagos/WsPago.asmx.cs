using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioPagos
{
    /// <summary>
    /// Summary description for WsPago
    /// </summary>
    [WebService(Namespace = "http://ServicioPagos/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsPago : System.Web.Services.WebService
    {

        [WebMethod]
        public string infopago(int folio, string nombre, string concepto, string referencia, string correo, int resultado, DateTime fecha, float importe, int terminal)
        {
            Pago pago = new Pago();

            pago.Folio = folio;
            pago.Nombre = nombre;
            pago.Concepto = concepto;
            pago.Referencia = referencia;
            pago.Correo = correo;
            pago.Resultado = resultado;
            pago.Fecha = fecha;
            pago.Importe = importe;
            pago.Terminal = terminal;

            AccesoDatos accesoDatos = new AccesoDatos();
            accesoDatos.GuardarPagos(pago);

            return "Guardado Exitosamente";


        }
    }
}
