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
    public partial class blld_DECLARACION_DOM_PARTICULAR : bll_DECLARACION_DOM_PARTICULAR
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_DOM_PARTICULAR()
        : base()
        {
        }

        public blld_DECLARACION_DOM_PARTICULAR(MODELDeclara_V2.DECLARACION_DOM_PARTICULAR DECLARACION_DOM_PARTICULAR)
        : base(DECLARACION_DOM_PARTICULAR)
        {
        }

        public  blld_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }




     #endregion


     #region *** Metodos ***


     #endregion

    }
}
