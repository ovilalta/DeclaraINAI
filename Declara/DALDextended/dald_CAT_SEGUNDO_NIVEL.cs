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
    internal partial class dald_CAT_SEGUNDO_NIVEL : dal_CAT_SEGUNDO_NIVEL
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_VID_PRIMER_NIVEL(String VID_PRIMER_NIVEL)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.CAT_SEGUNDO_NIVEL
                              where
                                   p.VID_PRIMER_NIVEL == VID_PRIMER_NIVEL

                              select p.VID_SEGUNDO_NIVEL).Max());
                return Convert.ToInt32(query) + 1;
            }
            catch
            {
                return 1;
            }
        }
        #endregion

    }
}
