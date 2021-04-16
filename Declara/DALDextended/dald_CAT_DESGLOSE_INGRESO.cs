using System;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_DESGLOSE_INGRESO : dal_CAT_DESGLOSE_INGRESO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_INGRESO(Int32 NID_INGRESO_SUPERIOR)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from   p in dbInt.CAT_DESGLOSE_INGRESO
                              where  p.NID_INGRESO_SUPERIOR == NID_INGRESO_SUPERIOR
                              select p.NID_INGRESO).Max());
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
