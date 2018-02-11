using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioPagos
{
    [Serializable]
    public class Pago
    {
        int folio;

        public int Folio
        {
            get { return folio; }
            set { folio = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string concepto;

        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }
        string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
        string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        int resultado;

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        double importe;

        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        int terminal;

        public int Terminal
        {
            get { return terminal; }
            set { terminal = value; }
        }


    }
}