using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_BAJA_VENTA : MODELDeclara_V2.MODIFICACION_BAJA_VENTA
    {

     #region *** Atributos extendidos ***

        public Int32 NID_TIPO_BAJA { get; set; }
        public DateTime F_BAJA { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            NID_TIPO_VENTA,
            M_IMPORTE_VENTA,
            NID_TIPO_BAJA,
            F_BAJA,
        }

     #endregion

    }
}
