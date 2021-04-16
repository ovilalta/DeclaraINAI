using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DeclaraINEAdmin.svr;

namespace DeclaraINEAdmin
{
 
    internal class clsSistema
    {
        private static String strKey
        {
            get { return "2B4420F077EAFF963001CC77B280DD796FDE1330A7F38DD719DAEF598F4D337837C0CDABCF0CBDDB63FD59F2E7CBB282CF3EB6392A1A38F3D6242508487432D5"; }
        }
        internal static Int32 NID_SISTEMA
        {
            get { return 6; }
        }


        public String V_SISTEMA
        {
            get { return strNombreSistema; }
        }
        
        public String TiluloPanelDeclaraINE
        {
            get
            {
                if (Convert.ToString(getParametro("V_TITULO_PANEL_ADMINISTRACION")) != null)
                {
                    return Convert.ToString(getParametro("V_TITULO_PANEL_ADMINISTRACION"));
                }
                else
                    return "";
            }
        }

        internal String strNombreSistema { get; private set; }
        private List<svr.parametro> listParametros { get; set; }


        internal String strMensajeInicial { get; private set; }
        internal Boolean lMensajeInicial
        {
            get { return !String.IsNullOrEmpty(strMensajeInicial); }
        }
        internal String strMensajeEstatico { get; private set; }
        internal Boolean lMensajeEstatico
        {
            get { return !String.IsNullOrEmpty(strMensajeEstatico); }
        }

        internal clsSistema()
        {

            svr.svrSoapClient oServicio = new svr.svrSoapClient();
            listParametros = oServicio.listSistemaParametro(NID_SISTEMA, strKey);
            strMensajeInicial = oServicio.strMensajeIncial(NID_SISTEMA, strKey);
            strMensajeEstatico = oServicio.strMensajeEstatico(NID_SISTEMA, strKey);
            strNombreSistema = oServicio.strNombreSistema(NID_SISTEMA, strKey);

        }

        private Object getParametro(String VID_PARAMETRO)
        {
            return listParametros.Where(p => p.VID_PARAMETRO == VID_PARAMETRO).Select(p => p.V_VALOR_PARAMETRO).First();
        }
       
    }

    public class parametro : svr.parametro { }

}