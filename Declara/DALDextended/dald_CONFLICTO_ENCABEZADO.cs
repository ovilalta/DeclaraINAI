using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DALD
{
    // Extended
    internal partial class dald_CONFLICTO_ENCABEZADO : dal_CONFLICTO_ENCABEZADO
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal void borra()
        {
            db.paCONFLICTO_BORRA_ENCABEZADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO,1,NID_ENCABEZADO);
        }
        #endregion

    }
}
