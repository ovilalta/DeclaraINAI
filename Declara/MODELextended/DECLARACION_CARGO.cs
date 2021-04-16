using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_CARGO : MODELDeclara_V2.DECLARACION_CARGO
    {

     #region *** Atributos extendidos ***

        public String VID_SEGUNDO_NIVEL { get; set; }
        public String V_SEGUNDO_NIVEL { get; set; }
        public Boolean L_ACTIVO { get; set; }

        public String _L_ACTIVO
        {
            get => Convert.ToInt16(L_ACTIVO).ToString();
            set => L_ACTIVO = Convert.ToBoolean(Convert.ToInt16(value));
        }
        public String VID_PUESTO { get; set; }
        public String VID_NIVEL { get; set; }
        public String V_PUESTO { get; set; }

        public String VID_PRIMER_NIVEL { get; set; }
        public String V_PRIMER_NIVEL { get; set; }

        public String C_EJERCICIO { get; set; }
        public Int32 NID_TIPO_DECLARACION { get; set; }
        public Int32 NID_ESTADO { get; set; }
        public String E_OBSERVACIONES { get; set; }
        public String E_OBSERVACIONES_MARCADO { get; set; }
        public String V_OBSERVACIONES_TESTADO { get; set; }
        public Int32 NID_ESTADO_TESTADO { get; set; }
        public Boolean L_AUTORIZA_PUBLICAR { get; set; }
        public DateTime F_REGISTRO { get; set; }
        public System.Nullable<DateTime> F_ENVIO { get; set; }
        public System.Nullable<Boolean> L_CONFLICTO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PUESTO,
            V_DENOMINACION,
            NID_PRIMER_NIVEL,
            NID_SEGUNDO_NIVEL,
            F_POSESION,
            F_INICIO,
            VID_SEGUNDO_NIVEL,
            V_SEGUNDO_NIVEL,
            L_ACTIVO,
            VID_PUESTO,
            VID_NIVEL,
            V_PUESTO,
            L_ACTIVO_CAT_PUESTO_CAT_PUESTO,
            VID_PRIMER_NIVEL,
            V_PRIMER_NIVEL,
            L_ACTIVO_CAT_PRIMER_NIVEL_CAT_PRIMER_NIVEL,
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
        }

     #endregion

    }
}
