using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_INVERSION_TITULAR : MODELDeclara_V2.ALTA_INVERSION_TITULAR
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_INVERSION,
            NID_DEPENDIENTE,
            L_DIF,
        }

     #endregion

    }
}
