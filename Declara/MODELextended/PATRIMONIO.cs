using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO : MODELDeclara_V2.PATRIMONIO
    {

     #region *** Atributos extendidos ***

        public String V_TIPO { get; set; }
        public Int32 C_NATURALEZA { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_TIPO,
            M_VALOR,
            NID_DEC_INCOR,
            F_INCORPORACION,
            NID_DEC_ULT_MOD,
            F_MODIFICACION,
            L_ACTIVO,
            F_REGISTRO,
            V_TIPO,
            C_NATURALEZA,
        }

     #endregion

    }
}
