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
    public partial class blld_MODIFICACION_VEHICULO_TITU : bll_MODIFICACION_VEHICULO_TITU
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.NID_DECLARACION; }
        //        }

        //        public Int32 NID_VEHICULO
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.NID_VEHICULO; }
        //        }

        //        public Int32 NID_DEPENDIENTE
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.NID_DEPENDIENTE; }
        //        }


        //        public Boolean L_DIF
        //        {
        //          get { return datos_MODIFICACION_VEHICULO_TITU.L_DIF; }
        //          set { datos_MODIFICACION_VEHICULO_TITU.L_DIF = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***
        public blld_MODIFICACION_VEHICULO_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF)
       : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting)
        {
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
