using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_DOM_LABORAL : bll_DECLARACION_DOM_LABORAL
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_DOM_LABORAL()
        : base()
        {
        }

        public blld_DECLARACION_DOM_LABORAL(MODELDeclara_V2.DECLARACION_DOM_LABORAL DECLARACION_DOM_LABORAL)
        : base(DECLARACION_DOM_LABORAL)
        {
        }

        public  blld_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }

        //public blld_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO,String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO,V_COLONIA, V_DOMICILIO, V_CORREO_LABORAL, V_TEL_LABORAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
