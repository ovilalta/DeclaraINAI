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
    internal partial class dald_CAT_CONFLICTO_PREGUNTA : dal_CAT_CONFLICTO_PREGUNTA
    {

     #region *** Atributos (Extended) ***


     #endregion


     #region *** Constructores (Extended) ***


     #endregion


     #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_PREGUNTA(Int32 NID_RUBRO)
        {
             MODELDeclara_V2.cnxDeclara db = new  MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.CAT_CONFLICTO_PREGUNTA
                              where
                                   p.NID_RUBRO == NID_RUBRO
                              select p.NID_PREGUNTA).Max());
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
