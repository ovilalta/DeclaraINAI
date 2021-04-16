using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_TIPO_INMUEBLE : MODELDeclara_V2.CAT_TIPO_INMUEBLE
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            NID_TIPO,
            V_TIPO,
            L_ACTIVO,
        }

     #endregion

    }
}
