using System;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_EXPERIENCIA_LABORAL : MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL
    {
        public String V_PAIS { get; set; }
        public String V_NACIONALIDAD_M { get; set; }
        public String V_NACIONALIDAD_F { get; set; }
        public String V_ESTADO_TESTADO { get; set; }
        public String V_AMBITO_SECTOR { get; set; }
        public String V_NIVEL_GOBIERNO { get; set; }
        public String V_AMBITO_PUBLICO { get; set; }
        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_EXPERIENCIA_LABORAL,
            NID_AMBITO_SECTOR,
            NID_NIVEL_GOBIERNO,
            NID_AMBITO_PUBLICO,
            V_NOMBRE,
            V_RFC,
            V_AREA_ADSCRIPCION,
            V_PUESTO,
            V_FUNCION_PRINCIPAL,
            NID_SECTOR,
            F_INGRESO,
            F_EGRESO,
            NID_PAIS,
            E_OBSERVACIONES,
            E_OBSERVACIONES_MARCADO,
            V_OBSERVACIONES_TESTADO,
            NID_ESTADO_TESTADO,
            V_PAIS,
            V_NACIONALIDAD_M,
            V_NACIONALIDAD_F,
            V_ESTADO_TESTADO,
            V_SECTOR,
            V_AMBITO_SECTOR,
            V_NIVEL_GOBIERNO,
            V_AMBITO_PUBLICO,
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
        }

    }
}
