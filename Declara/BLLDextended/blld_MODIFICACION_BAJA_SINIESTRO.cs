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
    public partial class blld_MODIFICACION_BAJA_SINIESTRO : bll_MODIFICACION_BAJA_SINIESTRO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO; }
        //        }


        //        public Boolean L_POLIZA
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA; }
        //          set { datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA = value; }
        //        }


        //        public Decimal M_RECUPERADO
        //        {
        //          get { return datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO; }
        //          set { datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Boolean L_POLIZA, Decimal M_RECUPERADO)
      : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, L_POLIZA, M_RECUPERADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting)
        {
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
