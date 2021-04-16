using System;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_COMODATO_VEHICULO : dal_ALTA_COMODATO_VEHICULO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***

        #endregion


        #region *** Metodos ***
        internal static int nNuevo_NID_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.ALTA_COMODATO
                              where p.VID_NOMBRE == VID_NOMBRE &&
                                    p.VID_FECHA == VID_FECHA &&
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                    p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_COMODATO).Max());
                return query ;
            }
            catch
            {
                return 1;
            }
            //try
            //{
            //    var query = ((from   p in dbInt.ALTA_COMODATO_VEHICULO
            //                  where  p.VID_NOMBRE == VID_NOMBRE && 
            //                        p.VID_FECHA == VID_FECHA && 
            //                        p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
            //                        p.NID_DECLARACION == NID_DECLARACION
            //                  select p.NID_COMODATO).Max());
            //    return query + 1;
            //}
            //catch
            //{
            //    return 1;
            //}
        }

        #endregion

    }
}
