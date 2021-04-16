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


namespace Declara_V2.BLLD
{
// Extended
    public partial class blld_USUARIO_SESION : bll_USUARIO_SESION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_USUARIO_SESION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_USUARIO_SESION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_USUARIO_SESION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_SESION
        //        {
        //          get { return datos_USUARIO_SESION.NID_SESION; }
        //        }


        //        public String V_IP
        //        {
        //          get { return datos_USUARIO_SESION.V_IP; }
        //          set { datos_USUARIO_SESION.V_IP = value; }
        //        }


        //        public String V_MAQUINA_USUARIO
        //        {
        //          get { return datos_USUARIO_SESION.V_MAQUINA_USUARIO; }
        //          set { datos_USUARIO_SESION.V_MAQUINA_USUARIO = value; }
        //        }


        //        public DateTime F_INICIO
        //        {
        //          get { return datos_USUARIO_SESION.F_INICIO; }
        //          set { datos_USUARIO_SESION.F_INICIO = value; }
        //        }


        //        public DateTime F_FIN
        //        {
        //          get { return datos_USUARIO_SESION.F_FIN; }
        //          set { datos_USUARIO_SESION.F_FIN = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE,  String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN)
       : base()
        {
            Int32 NID_ULTIMA_SESION = dald_USUARIO_SESION.nUltimaSesion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            if (NID_ULTIMA_SESION > 0)
            {
                blld_USUARIO_SESION ultimaSesion = new blld_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_ULTIMA_SESION);
                if (ultimaSesion.V_IP.Trim() != V_IP.Trim())
                {
                    if (DateTime.Now < ultimaSesion.F_FIN)
                    {
                        throw new CustomException("Existe una sesión activa en otro dispositivo, cierre la sesión en el otro dispositivo haciendo click en el botón 'cerrar sesión' o espere 25 minutos");
                    }
                    else
                    {
                        Int32 NID_SESION = dald_USUARIO_SESION.nNuevaSesion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
                        datos_USUARIO_SESION = new dald_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
                    }
                }
                else
                {
                    datos_USUARIO_SESION = new dald_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_ULTIMA_SESION);
                    datos_USUARIO_SESION.F_FIN = F_FIN;
                    datos_USUARIO_SESION.update();
                }
            }
            else
            {
                Int32 NID_SESION = dald_USUARIO_SESION.nNuevaSesion(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
                datos_USUARIO_SESION = new dald_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            }

        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
