using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_TIPO_DEPENDIENTES : MODELDeclara_V2.CAT_TIPO_DEPENDIENTES
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            NID_TIPO_DEPENDIENTE,
            V_TIPO_DEPENDIENTE,
            L_PAREJA,
        }

     #endregion

    }
}
