using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_APARTADO : MODELDeclara_V2.DECLARACION_APARTADO
    {

     #region *** Atributos extendidos ***

        public String V_APARTADO { get; set; }
        public System.Nullable<Int32> NID_APARTADO_SUPERIOR { get; set; }
        public System.Nullable<Int32> N_APARTADO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_APARTADO,
            L_ESTADO,
            V_APARTADO,
            NID_APARTADO_SUPERIOR,
            N_APARTADO,
        }

     #endregion

    }
}
