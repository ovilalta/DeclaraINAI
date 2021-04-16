using System;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_ESTADO_ESCOLARIDAD : dal_CAT_ESTADO_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_ESTADO_ESCOLARIDAD()
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from   p in dbInt.CAT_ESTADO_ESCOLARIDAD
                              select p.NID_ESTADO_ESCOLARIDAD).Max());
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
