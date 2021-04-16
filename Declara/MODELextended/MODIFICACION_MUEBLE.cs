using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_MUEBLE : MODELDeclara_V2.MODIFICACION_MUEBLE
    {

     #region *** Atributos extendidos ***

        public String V_TIPO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            NID_TIPO,
            E_ESPECIFICACION,
            M_VALOR,
            V_TIPO,
            F_ADQUISICION,
        }

     #endregion

    }
}
