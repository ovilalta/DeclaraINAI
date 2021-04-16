using System;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_MUEBLE_COPROPIETARIO : dal_ALTA_MUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from   p in dbInt.ALTA_MUEBLE_COPROPIETARIO
                              where  p.VID_NOMBRE == VID_NOMBRE && 
                                    p.VID_FECHA == VID_FECHA && 
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
                                    p.NID_DECLARACION == NID_DECLARACION && 
                                    p.NID_MUEBLE == NID_MUEBLE
                              select p.NID_COPROPIETARIO).Max());
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
