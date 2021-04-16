using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO_FLUJO : MODELDeclara_V2.PATRIMONIO_FLUJO
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            M_INGRESOS,
            M_EGRESOS,
        }

     #endregion

    }
}
