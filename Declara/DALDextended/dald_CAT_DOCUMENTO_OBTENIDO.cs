using System;
using System.Linq;
using MODELDeclara;
using Declara.Exceptions;
using Declara.DAL;

namespace Declara.DALD
{
    internal partial class dald_CAT_DOCUMENTO_OBTENIDO : dal_CAT_DOCUMENTO_OBTENIDO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_DOCUMENTO_OBTENIDO()
        {
            MODELDeclara.cnxDECLARA dbInt = new MODELDeclara.cnxDECLARA();
            try
            {
                var query = ((from   p in dbInt.CAT_DOCUMENTO_OBTENIDO
                              select p.NID_DOCUMENTO_OBTENIDO).Max());
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
