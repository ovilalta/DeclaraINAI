using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System.IO;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_USUARIO_REC_PASS : bll_USUARIO_REC_PASS
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_USUARIO_REC_PASS.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_USUARIO_REC_PASS.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_USUARIO_REC_PASS.VID_HOMOCLAVE; }
        //        }

        //        public String V_CORREO
        //        {
        //          get { return datos_USUARIO_REC_PASS.V_CORREO; }
        //        }


        //        public Int32 N_USOS
        //        {
        //          get { return datos_USUARIO_REC_PASS.N_USOS; }
        //          set { datos_USUARIO_REC_PASS.N_USOS = value; }
        //        }


        //        public DateTime F_SOLICITUD
        //        {
        //          get { return datos_USUARIO_REC_PASS.F_SOLICITUD; }
        //          set { datos_USUARIO_REC_PASS.F_SOLICITUD = value; }
        //        }

        internal static Int32 Codigo
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(100000000, 999999999);
            }
        }


        //internal Int32 N_CODIGO_tmp;
        //static DateTime F_Fecha = DateTime.Now;
        //internal String V_CORREO_tmp;
        #endregion


        #region *** Constructores (Extended) ***

        public blld_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, DateTime F_SOLICITUD)
         : base()
        {
            Int32 N_USOS = -1;
            datos_USUARIO_REC_PASS = new dald_USUARIO_REC_PASS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, N_USOS, F_SOLICITUD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }

        public blld_USUARIO_REC_PASS(MODELDeclara_V2.USUARIO_REC_PASS USUARIO_REC_PASS, String V_CODIGO)
         : base(USUARIO_REC_PASS)
        {
            if (F_SOLICITUD > DateTime.Now.AddHours(36))
            {
                datos_USUARIO_REC_PASS.delete();
                throw new CustomException("El código de recuperación ha caducado");
            }
            if (N_USOS > 3)
                throw new CustomException("El código de ha superado el número de intentos permitido, solicite nuevamente la recuperación de contraseña");
            if (!V_CODIGO.Equals(blld_USUARIO_REC_PASS.encriptarCodigo(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO)))
               throw new CustomException("El código de validación es incorrecto");
        }

        #endregion


        #region *** Metodos (Extended) ***

        public void Clear()

        {
            datos_USUARIO_REC_PASS.delete();
        }

        public static void SolicitaRecuperacion(String VID_RFC)
        {
            dald_USUARIO datos_USUARIO;
            blld__l_USUARIO_CORREO oCorreo = new blld__l_USUARIO_CORREO();

            try
            {
                String VID_NOMBRE = VID_RFC.Substring(0, 4);
                String VID_FECHA = VID_RFC.Substring(4, 6);
                String VID_HOMOCLAVE = VID_RFC.Substring(10, 3);
                datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

                oCorreo.VID_NOMBRE = new Declara_V2.StringFilter(VID_NOMBRE);
                oCorreo.VID_FECHA = new Declara_V2.StringFilter(VID_FECHA);
                oCorreo.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_HOMOCLAVE);
                oCorreo.L_CONFIRMADO = true;
                oCorreo.select();
            }
            catch { }
            if (oCorreo.lista_USUARIO_CORREO == null) { throw new Exception("El RFC no existe en la base de datos"); }
            if (oCorreo.lista_USUARIO_CORREO.Any())
                blld_USUARIO_REC_PASS.EnviarCorreoRecuperacionS(oCorreo.lista_USUARIO_CORREO);

        }

        public static string SolicitaRecuperacionV2(String VID_RFC)
        {
            dald_USUARIO datos_USUARIO;
            blld__l_USUARIO_CORREO oCorreo = new blld__l_USUARIO_CORREO();

            try
            {
                String VID_NOMBRE = VID_RFC.Substring(0, 4);
                String VID_FECHA = VID_RFC.Substring(4, 6);
                String VID_HOMOCLAVE = VID_RFC.Substring(10, 3);
                datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

                oCorreo.VID_NOMBRE = new Declara_V2.StringFilter(VID_NOMBRE);
                oCorreo.VID_FECHA = new Declara_V2.StringFilter(VID_FECHA);
                oCorreo.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_HOMOCLAVE);
                oCorreo.L_CONFIRMADO = true;
                oCorreo.select();
            }
            catch { }
            if (oCorreo.lista_USUARIO_CORREO == null) { throw new Exception("El RFC no existe en la base de datos"); }
            if (oCorreo.lista_USUARIO_CORREO.Any())
                blld_USUARIO_REC_PASS.EnviarCorreoRecuperacionS(oCorreo.lista_USUARIO_CORREO);

            return string.Join(", ", oCorreo.lista_USUARIO_CORREO.Select(x => x.V_CORREO));
        }


        public static void EnviarCorreoRecuperacionS(List<USUARIO_CORREO> lista_USUARIO_CORREO)
        {

            String url = String.Empty;
            blld_USUARIO oUsuario = new blld_USUARIO(lista_USUARIO_CORREO.First().VID_NOMBRE
                                                    , lista_USUARIO_CORREO.First().VID_FECHA
                                                    , lista_USUARIO_CORREO.First().VID_HOMOCLAVE
                   );
            Int32 N_CODIGO = blld_USUARIO_REC_PASS.Codigo;

            foreach (blld_USUARIO_REC_PASS rec in oUsuario.USUARIO_REC_PASSs)
                rec.delete();

            blld_USUARIO_REC_PASS oRecuperacion = new blld_USUARIO_REC_PASS(lista_USUARIO_CORREO.First().VID_NOMBRE
                                   , lista_USUARIO_CORREO.First().VID_FECHA
                                   , lista_USUARIO_CORREO.First().VID_HOMOCLAVE
                                   , N_CODIGO.ToString()
                                   , DateTime.Now);


            foreach (USUARIO_CORREO o in lista_USUARIO_CORREO)
            {
                url = String.Concat
                (
                  clsSistema.URL_SISTEMA,
                  "Formas/Recuperacion.aspx?ein="
                  , Base64_Encode(o.VID_NOMBRE)
                  , "&zwei="
                  , Base64_Encode(o.VID_FECHA)
                  , "&drei="
                  , Base64_Encode(o.VID_HOMOCLAVE)
                  , "&mailto="
                  , o.V_CORREO
                  , "&vier="
                  , blld_USUARIO_REC_PASS.encriptarCodigo(o.VID_NOMBRE, o.VID_FECHA, o.VID_HOMOCLAVE, N_CODIGO.ToString())
             );
                EnviarCorreo(
            o.V_CORREO
             , "DeclaraINAI - Recuperación de Contraseña"
               , String.Concat(File.ReadAllText(clsSistema.RUTA_RECUPERACION_PASS)
                                             .Replace("{vNombre}", oUsuario.V_NOMBRE)
                                            .Replace("{vUrl}", url)
                                             )
             );
            }

        }


        //        public string EnviarCorreoRecuperacion()
        //        {
        //            bll_USUARIO o = new bll_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

        //            String url = String.Concat
        //                (
        //                clsSistema.URL_SISTEMA,
        //                 "Formas/Recuperacion.aspx?ein="
        //                  , Base64_Encode(VID_NOMBRE)
        //                  , "&zwei="
        //                  , Base64_Encode(VID_FECHA)
        //                  , "&drei="
        //                  , Base64_Encode(VID_HOMOCLAVE)
        //                  , "&mailto="
        //                  , this.V_CORREO
        //                         ( , "&vier="
        //                          , blld_USUARIO_REC_PASS.encriptarCodigo(o.VID_NOMBRE, o.VID_FECHA, o.VID_HOMOCLAVE, this.N_CODIGO.ToString))
        //                );

        //            EnviarCorreo(
        //                      V_CORREO
        //                      , "Solicitud de activación de correo electrónico"
        //                      , String.Concat(File.ReadAllText(clsSistema.RUTA_RECUPERACION_PASS)
        //                                                 .Replace("{vNombre}", o.V_NOMBRE)
        //                                                .Replace("{vUrl}", url)
        //                                                 .Replace("{vCode}", Convert.ToString(this.V_CORREO))
        //)
        //                );
        //            return url;
        //        }


        //public static void SolicitudRecuperacionClave(String RFCs)
        //{
        //    dald_USUARIO datos_USUARIO;
        //    String url = String.Empty;
        //    String VID_NOMBRE = String.Empty;
        //    String VID_FECHA = String.Empty;
        //    String VID_HOMOCLAVE = String.Empty;

        //    blld__l_USUARIO_CORREO oCorreo = new blld__l_USUARIO_CORREO();

        //    try
        //    {
        //        VID_NOMBRE = RFCs.Substring(0, 4);
        //        VID_FECHA = RFCs.Substring(4, 6);
        //        VID_HOMOCLAVE = RFCs.Substring(10, 3);
        //        datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

        //        oCorreo.VID_NOMBRE = new Declara.StringFilter(VID_NOMBRE);
        //        oCorreo.VID_FECHA = new Declara.StringFilter(VID_FECHA);
        //        oCorreo.VID_HOMOCLAVE = new Declara.StringFilter(VID_HOMOCLAVE);
        //        oCorreo.L_CONFIRMADO = true;
        //        oCorreo.select();
        //    }
        //    catch
        //    {

        //    }
        //    try
        //    {
        //        blld_USUARIO_REC_PASS oRUsuario = new blld_USUARIO_REC_PASS(oCorreo.lista_USUARIO_CORREO[0].VID_NOMBRE,
        //            oCorreo.lista_USUARIO_CORREO[0].VID_FECHA,
        //            oCorreo.lista_USUARIO_CORREO[0].VID_HOMOCLAVE,
        //            oCorreo.lista_USUARIO_CORREO[0].V_CORREO, F_Fecha);
        //        oRUsuario.EnviaSoicitudRecuperacionClave(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, oCorreo.lista_USUARIO_CORREO);
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void EnviaSoicitudRecuperacionClave(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, List<USUARIO_CORREO> lista_USUARIO_CORREO)
        //{
        //    String url = String.Empty;
        //    dald_USUARIO oUsuario = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
        //    String V_NOMBRE = oUsuario.V_NOMBRE;

        //    foreach (USUARIO_CORREO o in lista_USUARIO_CORREO)
        //    {
        //        blld__l_USUARIO oUser = new blld__l_USUARIO();
        //        oUser.VID_NOMBRE = new StringFilter(o.VID_NOMBRE);
        //        oUser.VID_FECHA = new StringFilter(o.VID_FECHA);
        //        oUser.VID_HOMOCLAVE = new StringFilter(o.VID_HOMOCLAVE);
        //        oUser.select();
        //        url = String.Concat
        //           (
        //            clsSistema.URL_SISTEMA,
        //            "Formas/Recuperacion.aspx?ein="
        //             , Base64_Encode(o.VID_NOMBRE)
        //             , "&zwei="
        //             , Base64_Encode(o.VID_FECHA)
        //             , "&drei="
        //             , Base64_Encode(o.VID_HOMOCLAVE)
        //             , "&mailto="
        //             , o.V_CORREO
        //        );

        //        try
        //        {
        //            EnviarCorreo(
        //        o.V_CORREO
        //         , "DeclaraIne | Solicitud de Recuperación de Contrasena"
        //           , String.Concat(File.ReadAllText(clsSistema.RUTA_RECUPERACION_PASS)
        //                                         .Replace("{vNombre}", V_NOMBRE)
        //                                        .Replace("{vUrl}", url)
        //                                         .Replace("{vCode}", Convert.ToString(N_CODIGO_tmp)))
        //         );
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        internal static string encriptarCodigo(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CODIGO)
        {
            String strOverride = "P4Tr1Ci4";
            String strEncodedUserAux = String.Empty;
            System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(V_CODIGO, strOverride, VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sb.ToString().ToLower()));
        }

        #endregion

    }
}
