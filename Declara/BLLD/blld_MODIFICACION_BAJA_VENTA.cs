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
    public partial class blld_MODIFICACION_BAJA_VENTA : bll_MODIFICACION_BAJA_VENTA
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_BAJA_VENTA()
        : base()
        {
        }

        public blld_MODIFICACION_BAJA_VENTA(MODELDeclara_V2.MODIFICACION_BAJA_VENTA MODIFICACION_BAJA_VENTA)
        : base(MODIFICACION_BAJA_VENTA)
        {
        }

        public  blld_MODIFICACION_BAJA_VENTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

    


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
