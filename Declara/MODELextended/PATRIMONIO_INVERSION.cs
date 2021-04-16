using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO_INVERSION : MODELDeclara_V2.PATRIMONIO_INVERSION
    {

     #region *** Atributos extendidos ***

        public Int32 NID_TIPO { get; set; }
        public Decimal M_VALOR { get; set; }
        public Int32 NID_DEC_INCOR { get; set; }
        public DateTime F_INCORPORACION { get; set; }
        public Int32 NID_DEC_ULT_MOD { get; set; }
        public DateTime F_MODIFICACION { get; set; }
        public Boolean L_ACTIVO { get; set; }
        public DateTime F_REGISTRO { get; set; }
        public String V_ENTIDAD_FEDERATIVA { get; set; }
        public String V_SUBTIPO_INVERSION { get; set; }
        public String V_INSTITUCION { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_TIPO_INVERSION,
            NID_SUBTIPO_INVERSION,
            NID_INSTITUCION,
            E_CUENTA,
            V_CUENTA_CORTO,
            V_OTRO,
            M_SALDO,
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            V_LUGAR,
            NID_TIPO,
            M_VALOR,
            NID_DEC_INCOR,
            F_INCORPORACION,
            NID_DEC_ULT_MOD,
            F_MODIFICACION,
            L_ACTIVO,
            F_REGISTRO,
            V_ENTIDAD_FEDERATIVA,
            V_SUBTIPO_INVERSION,
            V_INSTITUCION,
        }

     #endregion

    }
}
