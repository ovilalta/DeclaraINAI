using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class USUARIO : MODELDeclara_V2.USUARIO
    {

        #region *** Atributos extendidos ***

       public String VID_RFC { get; set; }
        public String V_NOMBRE_COMPLETO_ESTILO1 { get; set; }
        public String V_NOMBRE_COMPLETO_ESTILO2 { get; set; }

        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            V_PASSWORD,
            V_NOMBRE,
            V_PRIMER_A,
            V_SEGUNDO_A,
            F_NACIMIENTO,
            V_ACUSE,
            L_ACTIVO,
            F_INGRESO_INSTITUTO,
            F_REGISTRO,
            VID_RFC,
            V_NOMBRE_COMPLETO_ESTILO1,
            V_NOMBRE_COMPLETO_ESTILO2,
        }

     #endregion

    }
}
