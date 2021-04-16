using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_PAIS : MODELDeclara_V2.CAT_PAIS
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            NID_PAIS,
            V_PAIS,
            V_NACIONALIDAD_M,
            V_NACIONALIDAD_F,
        }

     #endregion

    }
}
