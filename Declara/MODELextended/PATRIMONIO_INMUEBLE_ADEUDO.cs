using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO_INMUEBLE_ADEUDO : MODELDeclara_V2.PATRIMONIO_INMUEBLE_ADEUDO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_PATRIMONIO_ADEUDO,
            L_DIF,
        }

     #endregion

    }
}
