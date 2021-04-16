using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_INVERSION : MODELDeclara_V2.ALTA_INVERSION
    {

     #region *** Atributos extendidos ***

        public String V_ENTIDAD_FEDERATIVA { get; set; }
        public String V_SUBTIPO_INVERSION { get; set; }
        public String V_INSTITUCION { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_INVERSION,
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
            NID_PATRIMONIO,
            V_ENTIDAD_FEDERATIVA,
            V_SUBTIPO_INVERSION,
            V_INSTITUCION,
            F_APERTURA,
        }

     #endregion

    }
}
