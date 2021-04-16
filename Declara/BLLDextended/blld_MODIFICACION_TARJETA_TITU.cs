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
    public partial class blld_MODIFICACION_TARJETA_TITU : bll_MODIFICACION_TARJETA_TITU
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.NID_DECLARACION; }
        //        }

        //        public String E_NUMERO
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.E_NUMERO; }
        //        }

        //        public Int32 NID_DEPENDIENTE
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.NID_DEPENDIENTE; }
        //        }


        //        public Boolean L_DIF
        //        {
        //          get { return datos_MODIFICACION_TARJETA_TITU.L_DIF; }
        //          set { datos_MODIFICACION_TARJETA_TITU.L_DIF = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_TARJETA_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_DEPENDIENTE, Boolean L_DIF)
       : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting)
        {
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
