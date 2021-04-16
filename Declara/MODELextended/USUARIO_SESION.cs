using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class USUARIO_SESION : MODELDeclara_V2.USUARIO_SESION
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_SESION,
            V_IP,
            V_MAQUINA_USUARIO,
            F_INICIO,
            F_FIN,
        }

     #endregion

    }
}
