using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_INGRESOS : MODELDeclara_V2.MODIFICACION_INGRESOS
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_INGRESO,
            E_ESPECIFICAR,
            E_ESPECIFICAR_COMPLEMENTO,
            M_INGRESO,
        }

     #endregion

    }
}
