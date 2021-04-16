using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_SEGUNDO_NIVEL : MODELDeclara_V2.CAT_SEGUNDO_NIVEL
    {

     #region *** Atributos extendidos ***

        public String V_PRIMER_NIVEL { get; set; }


        public enum Properties
        {
            VID_PRIMER_NIVEL,
            VID_SEGUNDO_NIVEL,
            V_SEGUNDO_NIVEL,
            C_INICIO,
            C_FIN,
            V_PRIMER_NIVEL,
        }

     #endregion

    }
}
