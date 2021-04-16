using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION : MODELDeclara_V2.DECLARACION
    {

     #region *** Atributos extendidos ***

        public String V_ESTADO_TESTADO { get; set; }
        public String V_TIPO_DECLARACION { get; set; }
        public String V_ESTADO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            C_EJERCICIO,
            NID_TIPO_DECLARACION,
            NID_ESTADO,
            E_OBSERVACIONES,
            E_OBSERVACIONES_MARCADO,
            V_OBSERVACIONES_TESTADO,
            NID_ESTADO_TESTADO,
            L_AUTORIZA_PUBLICAR,
            F_REGISTRO,
            F_ENVIO,
            L_CONFLICTO,
            V_ESTADO_TESTADO,
            V_TIPO_DECLARACION,
            V_ESTADO,
            V_HASH,
        }

     #endregion

    }
}
