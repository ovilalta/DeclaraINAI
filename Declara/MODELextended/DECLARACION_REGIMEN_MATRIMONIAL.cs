using System;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_REGIMEN_MATRIMONIAL : MODELDeclara_V2.DECLARACION_REGIMEN_MATRIMONIAL
    {
        public String V_REGIMEN_MATRIMONIAL { get; set; }
        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_REGIMEN_MATRIMONIAL,
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
            V_HASH,
            V_REGIMEN_MATRIMONIAL,
        }

    }
}
