using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_ADEUDO : MODELDeclara_V2.MODIFICACION_ADEUDO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            M_PAGOS,
            M_SALDOS,
            L_CANCELADO,
            L_MODIFICADO,
        }

     #endregion

    }
}
