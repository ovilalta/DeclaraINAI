using System;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_FORMA_ADQUISICION : dal_CAT_FORMA_ADQUISICION
    {
        //sme
        public dald_CAT_FORMA_ADQUISICION(int? nID_FORMA_ADQUISICION)
        {
        }
        //sme
        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_FORMA_ADQUISICION()
        {
            
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from   p in dbInt.CAT_FORMA_ADQUISICION
                              select p.NID_FORMA_ADQUISICION).Max());
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
