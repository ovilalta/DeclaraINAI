using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_DEPENDIENTES : MODELDeclara_V2.DECLARACION_DEPENDIENTES
    {

     #region *** Atributos extendidos ***

        public String V_TIPO_DEPENDIENTE { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_DEPENDIENTE,
            NID_TIPO_DEPENDIENTE,
            E_NOMBRE,
            E_PRIMER_A,
            E_SEGUNDO_A,
            F_NACIMIENTO,
            E_RFC,
            L_DEPENDE_ECO,
            E_DOMICILIO,
            L_ACTIVO,
            V_TIPO_DEPENDIENTE,
            V_NOMBRE_COMPLETO,
            V_NOMBRE_COMPLETO_TIPO,
        }

        #endregion

    }
}
