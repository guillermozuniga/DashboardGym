using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace ServicioPagos
{
    public class Utilidades
    {
        public static string ObtenerConexion()
        {

            //return ConfigurationManager.AppSettings["CadenaBD"].ToString();
            return ConfigurationManager.ConnectionStrings["LocalSQLServer"].ToString();



        }

    }
}