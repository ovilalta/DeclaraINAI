using System;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_DEPENDIENTES_PRIVADO : MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO
    {
        public String V_SECTOR { get; set; }
        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_DEPENDIENTE,
            V_NOMBRE,
            V_CARGO,
            V_RFC,
            F_INGRESO,
            NID_SECTOR,
            M_SALARIO_MENSUAL,
            L_PROVEEDOR,
            NID_TIPO_DEPENDIENTE,
            E_NOMBRE,
            E_PRIMER_A,
            E_SEGUNDO_A,
            F_NACIMIENTO,
            E_RFC,
            L_DEPENDE_ECO,
            E_DOMICILIO,
            L_ACTIVO,
            L_CIUDADANO_EXTRANJERO,
            E_CURP,
            E_OBSERVACIONES,
            E_OBSERVACIONES_MARCADO,
            V_OBSERVACIONES_TESTADO,
            NID_ESTADO_TESTADO,
            L_MISMO_DOMICILIO_DECLARANTE,
            V_SECTOR,
        }

    }
}
