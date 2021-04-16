using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_CONFLICTO_PREGUNTA : MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            NID_RUBRO,
            NID_PREGUNTA,
            V_RUBRO,
            V_OPCIONES,
            C_INICIO,
            C_FIN
        }

     #endregion

    }
}
