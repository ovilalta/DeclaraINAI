using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_GASTO : MODELDeclara_V2.MODIFICACION_GASTO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_GASTO,
            V_GASTO,
            M_GASTO,
            L_AUTOGENERADO,
            NID_PATRIMONIO_ASC,
        }

     #endregion

    }
}
