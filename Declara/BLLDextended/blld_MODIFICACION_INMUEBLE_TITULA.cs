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
    public partial class blld_MODIFICACION_INMUEBLE_TITULA : bll_MODIFICACION_INMUEBLE_TITULA
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.NID_DECLARACION; }
        //        }

        //        public Int32 NID_INMUEBLE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.NID_INMUEBLE; }
        //        }

        //        public Int32 NID_DEPENDIENTE
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.NID_DEPENDIENTE; }
        //        }


        //        public Boolean L_DIF
        //        {
        //          get { return datos_MODIFICACION_INMUEBLE_TITULA.L_DIF; }
        //          set { datos_MODIFICACION_INMUEBLE_TITULA.L_DIF = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***


        public blld_MODIFICACION_INMUEBLE_TITULA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF)
      : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting)
        {
        }


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
