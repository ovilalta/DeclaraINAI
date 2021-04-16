using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class USUARIO_CORREO : MODELDeclara_V2.USUARIO_CORREO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            V_CORREO,
            L_PRINCIPAL,
            L_ACTIVO,
            L_CONFIRMADO,
        }

     #endregion

    }
}
