using System;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_ESCOLARIDAD : MODELDeclara_V2.DECLARACION_ESCOLARIDAD
    {
        public String V_NIVEL_ESCOLARIDAD { get; set; }
        public String V_ESTADO_ESCOLARIDAD { get; set; }
        public String V_DOCUMENTO_OBTENIDO { get; set; }
        public String V_PAIS { get; set; }
        public String V_NACIONALIDAD_M { get; set; }
        public String V_NACIONALIDAD_F { get; set; }
        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_ESCOLARIDAD,
            NID_NIVEL_ESCOLARIDAD,
            V_INSTITUCION_EDUCATIVA,
            V_CARRERA,
            NID_ESTADO_ESCOLARIDAD,
            NID_DOCUMENTO_OBTENIDO,
            F_OBTENCION,
            NID_PAIS,
            E_OBSERVACIONES,
            E_OBSERVACIONES_MARCADO,
            V_OBSERVACIONES_TESTADO,
            NID_ESTADO_TESTADO,
            C_EJERCICIO,
            NID_TIPO_DECLARACION,
            NID_ESTADO,
            E_OBSERVACIONES_DECLARACION,
            E_OBSERVACIONES_MARCADO_DECLARACION,
            V_OBSERVACIONES_TESTADO_DECLARACION,
            NID_ESTADO_TESTADO_DECLARACION,
            L_AUTORIZA_PUBLICAR,
            F_REGISTRO,
            F_ENVIO,
            L_CONFLICTO,
            V_HASH,
            V_NIVEL_ESCOLARIDAD,
            V_ESTADO_ESCOLARIDAD,
            V_DOCUMENTO_OBTENIDO,
            V_PAIS,
            V_NACIONALIDAD_M,
            V_NACIONALIDAD_F,
        }

    }
}
