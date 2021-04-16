using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class USUARIO_REC_PASS : MODELDeclara_V2.USUARIO_REC_PASS
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            V_CORREO,
            N_USOS,
            F_SOLICITUD,
        }

     #endregion

    }
}
