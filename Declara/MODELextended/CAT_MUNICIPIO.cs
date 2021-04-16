using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CAT_MUNICIPIO : MODELDeclara_V2.CAT_MUNICIPIO
    {

     #region *** Atributos extendidos ***

        public String V_ENTIDAD_FEDERATIVA { get; set; }


        public enum Properties
        {
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            CID_MUNICIPIO,
            V_MUNICIPIO,
            V_ENTIDAD_FEDERATIVA,
        }

     #endregion

    }
}
