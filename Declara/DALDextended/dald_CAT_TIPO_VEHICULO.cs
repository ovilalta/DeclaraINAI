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
    internal partial class dald_CAT_TIPO_VEHICULO : dal_CAT_TIPO_VEHICULO
    {

     #region *** Atributos (Extended) ***


     #endregion


     #region *** Constructores (Extended) ***


     #endregion


     #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_TIPO_VEHICULO()
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.CAT_TIPO_VEHICULO
                              select p.NID_TIPO_VEHICULO).Max());
               return query + 1;
            }
            catch
            {
                return 1;
            }
        }

     #endregion

    }
}
