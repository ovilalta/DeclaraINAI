using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_SUBTIPO_INVERSION : MODELDeclara_V2.CAT_SUBTIPO_INVERSION
    {

     #region *** Atributos extendidos ***

        public String V_TIPO_INVERSION { get; set; }


        public enum Properties
        {
            NID_TIPO_INVERSION,
            NID_SUBTIPO_INVERSION,
            V_SUBTIPO_INVERSION,
            V_TIPO_INVERSION,
        }

     #endregion

    }
}
