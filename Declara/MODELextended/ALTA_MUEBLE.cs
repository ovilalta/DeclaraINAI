using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_MUEBLE : MODELDeclara_V2.ALTA_MUEBLE
    {

     #region *** Atributos extendidos ***

        public String V_TIPO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_MUEBLE,
            NID_TIPO,
            E_ESPECIFICACION,
            M_VALOR,
            NID_PATRIMONIO,
            L_CREDITO,
            V_TIPO,
            F_ADQUISICION,
            D_ESPECIFICACION
        }

     #endregion

    }
}
