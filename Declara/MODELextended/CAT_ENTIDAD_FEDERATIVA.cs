using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_ENTIDAD_FEDERATIVA : MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA
    {

     #region *** Atributos extendidos ***

        public String V_PAIS { get; set; }
        public String V_NACIONALIDAD_M { get; set; }
        public String V_NACIONALIDAD_F { get; set; }


        public enum Properties
        {
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            V_ENTIDAD_FEDERATIVA,
            V_PAIS,
            V_NACIONALIDAD_M,
            V_NACIONALIDAD_F,
        }

     #endregion

    }
}
