using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_DOM_LABORAL : MODELDeclara_V2.DECLARACION_DOM_LABORAL
    {

     #region *** Atributos extendidos ***

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
            C_CODIGO_POSTAL,
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            CID_MUNICIPIO,
            V_COLONIA,
            V_DOMICILIO,
            V_CORREO_LABORAL,
            V_TEL_LABORAL,
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
