using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_INVERSION : MODELDeclara_V2.MODIFICACION_INVERSION
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            M_SALDO_ANTERIOR,
            M_SALDO_ACTUAL,
            L_CANCELADA,
            L_MODIFICADA,
        }

     #endregion

    }
}
