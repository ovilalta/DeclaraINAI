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
using System.IO;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_USUARIO_CORREO : bll_USUARIO_CORREO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_USUARIO_CORREO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_USUARIO_CORREO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_USUARIO_CORREO.VID_HOMOCLAVE; }
        //        }

        //        public String V_CORREO
        //        {
        //          get { return datos_USUARIO_CORREO.V_CORREO; }
        //        }


        //        public Boolean L_PRINCIPAL
        //        {
        //          get { return datos_USUARIO_CORREO.L_PRINCIPAL; }
        //          set { datos_USUARIO_CORREO.L_PRINCIPAL = value; }
        //        }


        //        public Boolean L_ACTIVO
        //        {
        //          get { return datos_USUARIO_CORREO.L_ACTIVO; }
        //          set { datos_USUARIO_CORREO.L_ACTIVO = value; }
        //        }


        //        public Boolean L_CONFIRMADO
        //        {
        //          get { return datos_USUARIO_CORREO.L_CONFIRMADO; }
        //          set { datos_USUARIO_CORREO.L_CONFIRMADO = value; }
        //        }

        new public Boolean L_CONFIRMADO => datos_USUARIO_CORREO.L_CONFIRMADO;
        new public Boolean L_ACTIVO => datos_USUARIO_CORREO.L_ACTIVO;



        #endregion


        #region *** Constructores (Extended) ***

        public blld_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_DIF, Boolean lEnviaConfirmacion)
        {
            Boolean L_PRINCIPAL = dald_USUARIO_CORREO.EsPrincipal(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            Boolean L_ACTIVO = true;
            Boolean L_CONFIRMADO = false;
            Int32 N_CODIGO = blld_USUARIO_REC_PASS.Codigo;

            datos_USUARIO_CORREO = new dald_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, L_PRINCIPAL, L_ACTIVO, L_CONFIRMADO, N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            if ((!L_PRINCIPAL) && (lEnviaConfirmacion)) EnviarConfirmarCorreo();
        }

        public blld_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_DIF, Boolean lEnviaConfirmacion, Boolean confirmado)
        {
            Boolean L_PRINCIPAL = dald_USUARIO_CORREO.EsPrincipal(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            Boolean L_ACTIVO = true;
            Boolean L_CONFIRMADO = true;
            Int32 N_CODIGO = blld_USUARIO_REC_PASS.Codigo;

            datos_USUARIO_CORREO = new dald_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, L_PRINCIPAL, L_ACTIVO, L_CONFIRMADO, N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            if ((!L_PRINCIPAL) && (lEnviaConfirmacion)) EnviarConfirmarCorreo();
        }

        #endregion


        #region *** Metodos (Extended) ***

        public void Recodificar()
        {
            Clear();
            EnviarCorreoConfirmacionCuenta();
        }

        public Boolean EnviarCorreoConfirmacionCuenta()
        {
            bll_USUARIO o = new bll_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

            String url = String.Concat
                        (
                           clsSistema.URL_SISTEMA
                          , "/formas/Confirma.aspx?ein="
                          , Base64_Encode(VID_NOMBRE)
                          , "&zwei="
                          , Base64_Encode(VID_FECHA)
                          , "&drei="
                          , Base64_Encode(VID_HOMOCLAVE)
                          , "&mailto="
                          , this.V_CORREO
                          , "&vier="
                          , blld_USUARIO_REC_PASS.encriptarCodigo(o.VID_NOMBRE, o.VID_FECHA, o.VID_HOMOCLAVE, this.N_CODIGO.ToString())
                          , "&funf="
                          , Base64_Encode("ZEN")
                        );

            return EnviarCorreo(
                          V_CORREO
                          , "DeclaraINAI - Solicitud de Activación de Registro"
                          , String.Concat(File.ReadAllText(clsSistema.RUTA_CORREO_CONFIRMACION).Replace("{vNombre}", o.V_NOMBRE).Replace("{vUrl}", url))
                          );

        }

        internal void ReConfirmarCorreo(String V_CORREO)
        {
            Clear();
            EnviarConfirmarCorreo();
        }

        internal void Clear()
        {
            Int32 N_CODIGO = blld_USUARIO_REC_PASS.Codigo;
            datos_USUARIO_CORREO.N_CODIGO = N_CODIGO;
            update();
        }

        public String EnviarConfirmarCorreo()
        {
            bll_USUARIO o = new bll_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

            String url = String.Concat
                        (
                           clsSistema.URL_SISTEMA
                          , "/formas/Confirma.aspx?ein="
                          , Base64_Encode(VID_NOMBRE)
                          , "&zwei="
                          , Base64_Encode(VID_FECHA)
                          , "&drei="
                          , Base64_Encode(VID_HOMOCLAVE)
                          , "&mailto="
                          , this.V_CORREO
                          , "&vier="
                          , blld_USUARIO_REC_PASS.encriptarCodigo(o.VID_NOMBRE, o.VID_FECHA, o.VID_HOMOCLAVE, this.N_CODIGO.ToString())
                          , "&funf="
                          , Base64_Encode("ZWANZIG")
                        );

            EnviarCorreo(
                      V_CORREO
                      , "DeclaraINAI - Solicitud de activación de correo electrónico"
                      , String.Concat(File.ReadAllText(clsSistema.RUTA_ACTIVACION_CORREO)
                                                 .Replace("{vNombre}", o.V_NOMBRE)
                                                .Replace("{vUrl}", url)
                                               .Replace("{RFC}", String.Concat(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE))
                                                 )
                );
            return url;
        }

        public void Activar(String V_CODIGO)
        {
            if (!V_CODIGO.Equals(blld_USUARIO_REC_PASS.encriptarCodigo(this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.N_CODIGO.ToString())))
                throw new CustomException("El código de validación no es correcto");
            if (L_CONFIRMADO)
                throw new CustomException("El correo electrónico ya ha sido confirmado");
            datos_USUARIO_CORREO.L_CONFIRMADO = true;
            datos_USUARIO_CORREO.L_ACTIVO = true;
            update();
        }

        //public void ActivarAdmin()
        //{
        //    if (L_CONFIRMADO)
        //        throw new CustomException("El correo electrónico ya ha sido confirmado");
        //    datos_USUARIO_CORREO.L_CONFIRMADO = true;
        //    datos_USUARIO_CORREO.L_ACTIVO = true;
        //    update();
        //}

        public void DesActivar()
        {
            datos_USUARIO_CORREO.L_CONFIRMADO = false;
            datos_USUARIO_CORREO.L_ACTIVO = false;
            update();
        }


        #endregion

    }
}
