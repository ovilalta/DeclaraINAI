using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_ADEUDO : MODELDeclara_V2.ALTA_ADEUDO
    {

     #region *** Atributos extendidos ***

        public String V_ENTIDAD_FEDERATIVA { get; set; }
        public String V_TIPO_ADEUDO { get; set; }
        public String V_INSTITUCION { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_ADEUDO,
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            V_LUGAR,
            NID_INSTITUCION,
            V_OTRA,
            NID_TIPO_ADEUDO,
            M_ORIGINAL,
            M_SALDO,
            E_CUENTA,
            L_AUTOGENERADO,
            NID_PATRIMONIO,
            V_ENTIDAD_FEDERATIVA,
            V_TIPO_ADEUDO,
            V_INSTITUCION,
        }

        #endregion

    }
}
