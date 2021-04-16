using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_PUESTO : MODELDeclara_V2.CAT_PUESTO
    {

        #region *** Atributos extendidos ***

        public string V_PUESTO_NIVEL => String.Concat(VID_NIVEL," - ",VID_PUESTO);

        public enum Properties
        {
            NID_PUESTO,
            VID_PUESTO,
            VID_NIVEL,
            V_PUESTO,
            L_ACTIVO,
            V_PUESTO_NIVEL,
        }

     #endregion

    }
}
