using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_CODIGO_POSTAL : MODELDeclara_V2.CAT_CODIGO_POSTAL
    {

     #region *** Atributos extendidos ***

        public String V_MUNICIPIO { get; set; }


        public enum Properties
        {
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            CID_MUNICIPIO,
            CID_CODIGO_POSTAL,
            NID_COLONIA,
            V_COLONIA,
            V_MUNICIPIO,
        }

     #endregion

    }
}
