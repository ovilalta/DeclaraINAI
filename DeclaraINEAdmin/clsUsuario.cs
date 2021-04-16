using DeclaraINEAdmin.svr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace DeclaraINEAdmin
{
    internal class clsUsuario
    {

        #region Propiedades

        private static String strKey
        {
            get { return "2B4420F077EAFF963001CC77B280DD796FDE1330A7F38DD719DAEF598F4D337837C0CDABCF0CBDDB63FD59F2E7CBB282CF3EB6392A1A38F3D6242508487432D5"; }
        }

        private Int32 NID_SISTEMA
        {
            get { return 6; }
        }

        internal String strMenu { get; private set; }

        internal String VID_USUARIO { get; set; }
        internal Int32 NID_AREA { get; private set; }
        internal String V_AREA
        {
            get
            {
               return listAreasActivas.Where(p => p.NID_AREA == this.NID_AREA).First().V_AREA;
            }
        }
 
        internal Int32 NID_SUBDIRECCION { get; private set; }
        internal String V_SUBDIRECCION
        {
            get
            {
                return listSubdireccionesActivas.Where(p => p.NID_AREA == this.NID_SUBDIRECCION).First().V_AREA;
            }
        }

        internal Boolean L_SUPERUSUARIO { get; private set; }
        internal Char C_GENERO { get; private set; }

        internal List<svr.area> listAreasActivas { get; private set; }
        internal List<svr.area> listAreasTodas { get; private set; }

        internal List<svr.area> listSubdireccionesActivas { get; private set; }
        internal List<svr.area> listSubdireccionesTodas { get; private set; }
        internal List<String> Formas { get; private set; }
        internal List<svr.permiso> Permisos { get; private set; }
        internal List<svr.perfil> Perfil { get; private set; }
        internal SISTEMA_MENU_USUARIO[] Menu { get; private set; }
        internal List<svr.puesto> listPuestos
        {
            get
            {
                svr.svrSoapClient oServicio = new svr.svrSoapClient();
                return oServicio.listPuestos(strKey, C_GENERO);
            }
        }


        #endregion

        #region Contructores

        internal clsUsuario(String strEquipo, String strIP, String VID_USUARIO, String V_PASSWORD)
        {

            try { this.VID_USUARIO = VID_USUARIO.ToLower().Trim(); }
            catch { }
            if (String.IsNullOrEmpty(this.VID_USUARIO) || String.IsNullOrEmpty(V_PASSWORD.Trim()))
            {
                String vInnerException = "El usuario y contraseña no pueden ser vacios " + VID_USUARIO;
                Exception ex = new Exception("El usuario y contraseña no pueden ser vacios ", new Exception(vInnerException));
                ex.Data.Add(4666, vInnerException);
                throw ex;
            }

            svr.svrSoapClient oServicio = new svr.svrSoapClient();


            try
            {
                if (oServicio.VerificaLogin(clsSistema.NID_SISTEMA, strEquipo, strIP, this.VID_USUARIO, encripta(V_PASSWORD.Trim()), strKey))
                {

                    this.L_SUPERUSUARIO = oServicio.lEsSuperUsuario(NID_SISTEMA, this.VID_USUARIO, strKey);
                    this.NID_AREA = oServicio.nUsuarioAreaPrincipal(NID_SISTEMA,1, this.VID_USUARIO, strKey);
                    this.NID_SUBDIRECCION = oServicio.nUsuarioAreaPrincipal(NID_SISTEMA,2, this.VID_USUARIO, strKey);
                    this.C_GENERO = oServicio.cUsuarioGenero(this.VID_USUARIO, strKey);
                    listAreasActivas = oServicio.listUsuarioAreasActivas(NID_SISTEMA,1, VID_USUARIO, strKey);
                    listAreasTodas = oServicio.listUsuarioAreasTodas(NID_SISTEMA,1, VID_USUARIO, strKey);
                    listSubdireccionesActivas = oServicio.listUsuarioAreasActivas(NID_SISTEMA,2, VID_USUARIO, strKey);
                    listSubdireccionesTodas = oServicio.listUsuarioAreasTodas(NID_SISTEMA,2, VID_USUARIO, strKey);
                    Formas = oServicio.listUsuarioFormas(NID_SISTEMA, VID_USUARIO, strKey);
                    Permisos = oServicio.listUsuarioPermiso(NID_SISTEMA, VID_USUARIO, strKey);
                    Perfil = oServicio.listUsuarioPerfil(VID_USUARIO, strKey);
                    Menu = oServicio.Menu(NID_SISTEMA, VID_USUARIO);
                    //strMenu = oServicio.strMenuJSON(NID_SISTEMA, VID_USUARIO);

                }
                else
                {
                    String vInnerException = "El usuario no tiene permiso para ingresar a este sistema " + VID_USUARIO;
                    Exception ex = new Exception("El usuario no tiene permiso para ingresar a este sistema ", new Exception(vInnerException));
                    ex.Data.Add(4666, vInnerException);
                    throw ex;
                }
            }
            catch (SoapException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            { 

                throw ex;
            }


        }

        internal void CambiaPassword(string Actual, string Nueva, string Confirmacion)
        {
            if (Nueva.Trim() != Confirmacion.Trim())
                throw new Exception("Contraseñas ingresadas son distintas");

            if (Actual.Trim() == Confirmacion.Trim())
                throw new Exception("Nueva contraseña debe ser distinta a la anterior");

            svr.svrSoapClient oServicio = new svr.svrSoapClient();
            oServicio.ModificaPassword(this.VID_USUARIO, encripta(Actual.Trim()), encripta(Nueva.Trim()), encripta(Confirmacion.Trim()), strKey);
        }

        #endregion

        #region Metodos

        private string encripta(string VID_USUARIO)
        {
            String strOverride = "QRTdj+mlvOfANfeIq";
            String strEncodedUser = String.Empty;
            String strEncodedUserAux = String.Empty;
            System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512Managed.Create();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            Byte[] stream = null;
            Byte[] byt = null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();


            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(VID_USUARIO, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            byt = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            strEncodedUser = Convert.ToBase64String(byt);
            foreach (char character in strEncodedUser) strEncodedUserAux += ((Char)(character + (Char)3)).ToString();
            strEncodedUser = strEncodedUserAux;
            strEncodedUserAux = null;
            sb = null;
            stream = null;
            sb = new System.Text.StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(strEncodedUser, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            return sb.ToString().ToUpper();
        }

        internal void ModificaPassword(string strPasswordAnterior, string strPasswordNueva, string strPasswordConfirmacion)
        {
            svr.svrSoapClient oServicio = new svr.svrSoapClient();
            oServicio.ModificaPassword(VID_USUARIO, encripta(strPasswordAnterior.Trim()), encripta(strPasswordNueva.Trim()), encripta(strPasswordConfirmacion.Trim()), strKey);
        }

        internal List<svr.control> Controles(String strForma)
        {
            svr.svrSoapClient oServicio = new svr.svrSoapClient();
            return oServicio.listUsuarioControles(NID_SISTEMA, strForma, VID_USUARIO, strKey);
        }

        #endregion

    }
    public class permiso : svr.permiso { }

    public class control : svr.control { }

    public class area : svr.area { }

    public class puesto : svr.puesto { }

    public class perfil : svr.perfil { }
}