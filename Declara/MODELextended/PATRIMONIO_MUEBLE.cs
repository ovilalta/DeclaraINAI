using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO_MUEBLE : MODELDeclara_V2.PATRIMONIO_MUEBLE
    {

     #region *** Atributos extendidos ***

        public Int32 NID_DEC_INCOR { get; set; }
        public DateTime F_INCORPORACION { get; set; }
        public Int32 NID_DEC_ULT_MOD { get; set; }
        public DateTime F_MODIFICACION { get; set; }
        public Boolean L_ACTIVO { get; set; }
        public DateTime F_REGISTRO { get; set; }
        public String V_TIPO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_TIPO,
            E_ESPECIFICACION,
            M_VALOR,
            NID_DEC_INCOR,
            F_INCORPORACION,
            NID_DEC_ULT_MOD,
            F_MODIFICACION,
            L_ACTIVO,
            F_REGISTRO,
            V_TIPO,
            F_ADQUISICION,
        }

     #endregion

    }
}
