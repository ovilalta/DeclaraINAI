using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class USUARIO_DOMICILIO : MODELDeclara_V2.USUARIO_DOMICILIO
    {

     #region *** Atributos extendidos ***

        public String V_MUNICIPIO { get; set; }
        public String V_TIPO_DOMICILIO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DOMICILIO,
            NID_PAIS,
            CID_ENTIDAD_FEDERATIVA,
            CID_MUNICIPIO,
            C_CODIGO_POSTAL,
            E_DIRECCION,
            NID_TIPO_DOMICILIO,
            L_ACTIVO,
            V_MUNICIPIO,
            V_TIPO_DOMICILIO,
        }

     #endregion

    }
}
