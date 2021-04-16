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
// Extended
    public partial class blld_CAT_TIPO_VEHICULO : bll_CAT_TIPO_VEHICULO
    {

     #region *** Atributos (Extended) ***

//        public Int32 NID_TIPO_VEHICULO
//        {
//          get { return datos_CAT_TIPO_VEHICULO.NID_TIPO_VEHICULO; }
//        }


//        public String V_TIPO_VEHICULO
//        {
//          get { return datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO; }
//          set { datos_CAT_TIPO_VEHICULO.V_TIPO_VEHICULO = value; }
//        }


     #endregion


     #region *** Constructores (Extended) ***

        public blld_CAT_TIPO_VEHICULO( String V_TIPO_VEHICULO)
        : base()
        {
            Int32 NID_TIPO_VEHICULO = dald_CAT_TIPO_VEHICULO.nNuevo_NID_TIPO_VEHICULO();
            datos_CAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO(NID_TIPO_VEHICULO, V_TIPO_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***


     #endregion

    }
}
