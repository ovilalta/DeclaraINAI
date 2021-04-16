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
    public partial class blld_MODIFICACION_BAJA_SINIESTRO : bll_MODIFICACION_BAJA_SINIESTRO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_BAJA_SINIESTRO()
        : base()
        {
        }

        public blld_MODIFICACION_BAJA_SINIESTRO(MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO MODIFICACION_BAJA_SINIESTRO)
        : base(MODIFICACION_BAJA_SINIESTRO)
        {
        }

        public  blld_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        //public blld_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Boolean L_POLIZA, Decimal M_RECUPERADO)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, L_POLIZA, M_RECUPERADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


        #endregion


        #region *** Metodos ***


        #endregion

    }
}
