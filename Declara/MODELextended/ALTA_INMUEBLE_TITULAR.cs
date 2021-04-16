using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_INMUEBLE_TITULAR : MODELDeclara_V2.ALTA_INMUEBLE_TITULAR
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_INMUEBLE,
            NID_DEPENDIENTE,
            L_DIF,
        }

     #endregion

    }
}
