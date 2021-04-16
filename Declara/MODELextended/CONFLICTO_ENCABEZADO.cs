using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CONFLICTO_ENCABEZADO : MODELDeclara_V2.CONFLICTO_ENCABEZADO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_CONFLICTO,
            NID_RUBRO,
            NID_ENCABEZADO,
            L_CONFLICTO,
        }

     #endregion

    }
}
