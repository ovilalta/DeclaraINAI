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
    internal partial class dald_USUARIO_DOMICILIO : dal_USUARIO_DOMICILIO
    {

     #region *** Atributos (Extended) ***


     #endregion


     #region *** Constructores (Extended) ***


     #endregion


     #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.USUARIO_DOMICILIO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p.NID_DOMICILIO).Max());
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
