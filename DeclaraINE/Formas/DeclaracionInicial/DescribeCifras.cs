using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeclaraINAI.Formas.DeclaracionInicial
{
    public  class DescribeCifras
    {
        
        public static string DescribeCantidad(string Cantidad)
        {
            int ExistePunto = Cantidad.IndexOf(".");
            string enteros = "0";
            string centavos = "0";
            string letrasCentavos = "";
            string letrasMonedaPlural = "PESOS";
            string letrasMonedaSingular = "PESO";
            if (ExistePunto > 0)
            {
                enteros = Cantidad.Substring(0, ExistePunto);
                centavos = Cantidad.Substring(ExistePunto + 1, Cantidad.Length - ExistePunto - 1);
            }
            else
            {
                enteros = Cantidad.Substring(0, Cantidad.Length);

            }
            if (centavos != "")
                letrasCentavos = "CON " + centavos + "/100";
            if (enteros == "0")
            {
                return "CERO " + letrasMonedaPlural + " " + letrasCentavos;
            }
            if (enteros == "1")
            {
                return Millones(enteros) + " " + letrasMonedaSingular + " " + letrasCentavos;
            }
            else
                return Millones(enteros) + " " + letrasMonedaPlural + " " + letrasCentavos;

        }
        private static string Millones(string Dato)
        {
            int divisor = 1000000;
            //cientos = Math.floor(num / divisor)
            // resto = num - (cientos * divisor)
            int cientos = Convert.ToInt32(Math.Floor(Convert.ToDouble((Convert.ToInt32(Dato) / divisor))));
            int resto = Convert.ToInt32(Dato) - cientos * divisor;

            string strMillones = Seccion(Convert.ToInt32(Dato), divisor, "UN MILLON", "MILLONES");
            string strMiles = Miles(resto);
            if (strMillones == "")
                return strMiles;
            return strMillones + " " + strMiles;
        }
        private static string Miles(int num)
        {
            int divisor = 1000;
            int cientos = Convert.ToInt32(Math.Floor(Convert.ToDouble(num / divisor)));
            int resto = num - cientos * divisor;
            string strMiles = Seccion(num, divisor, "UN MIL", "MIL");
            string strCentenas = Centenas(resto);
            if (strMiles == "")
                return strCentenas;
            return strMiles + " " + strCentenas;
        }

        private static string Seccion(int num, int divisor, string strSingular, string strPlural)
        {

            int cientos = Convert.ToInt32(Math.Floor(Convert.ToDouble(num / divisor)));
            int resto = num - cientos * divisor;

            string letras = "";
            if (cientos > 0)
            {
                if (cientos > 1)
                    letras = Centenas(cientos) + " " + strPlural;
                else
                    letras = strSingular;
            }
            if (resto > 0)
            {
                letras += "";
            }
            return letras;

        }




        private static string Centenas(int num)
        {

            int centenas = Convert.ToInt32(Math.Floor(Convert.ToDouble(num / 100)));
            int decenas = num - centenas * 100;

            switch (centenas)
            {

                case 1:
                    if (decenas > 0)
                        return "CIENTO " + Decenas(decenas);
                    break;
                case 2: return "DOSCIENTOS " + Decenas(decenas);
                case 3: return "TRESCIENTOS " + Decenas(decenas);
                case 4: return "CUATROCIENTOS " + Decenas(decenas);
                case 5: return "QUINIENTOS " + Decenas(decenas);
                case 6: return "SEISCIENTOS " + Decenas(decenas);
                case 7: return "SETECIENTOS " + Decenas(decenas);
                case 8: return "OCHOCIENTOS " + Decenas(decenas);
                case 9: return "NOVECIENTOS " + Decenas(decenas);
            }
            return Decenas(decenas);
        }
        private static string DecenasY(string strSin, int numUnidades)
        {
            if (numUnidades > 0)
                return strSin + " Y " + Unidades(numUnidades);

            return strSin;
        }
        private static string Decenas(int num)
        {


            double decena = Math.Floor(Convert.ToDouble(num / 10));
            int unidad = Convert.ToInt32(num - (decena * 10));
            switch (decena)
            {
                case 1:
                    switch (unidad)
                    {
                        case 0: return "DIEZ";
                        case 1: return "ONCE";
                        case 2: return "DOCE";
                        case 3: return "TRECE";
                        case 4: return "CATORCE";
                        case 5: return "QUINCE";
                        default: return "DIECI" + Unidades(unidad);
                    }
                case 2:
                    switch (unidad)
                    {
                        case 0: return "VEINTE";
                        default: return "VEINTI" + Unidades(unidad);
                    }
                case 3: return DecenasY("TREINTA", unidad);
                case 4: return DecenasY("CUARENTA", unidad);
                case 5: return DecenasY("CINCUENTA", unidad);
                case 6: return DecenasY("SESENTA", unidad);
                case 7: return DecenasY("SETENTA", unidad);
                case 8: return DecenasY("OCHENTA", unidad);
                case 9: return DecenasY("NOVENTA", unidad);
                case 0: return Unidades(unidad);
                default: return "";
            }
        }

        private static string Unidades(int num)
        {
            switch (num)
            {
                case 1: return "UN";
                case 2: return "DOS";
                case 3: return "TRES";
                case 4: return "CUATRO";
                case 5: return "CINCO";
                case 6: return "SEIS";
                case 7: return "SIETE";
                case 8: return "OCHO";
                case 9: return "NUEVE";
            }

            return "";
        }
    }
}