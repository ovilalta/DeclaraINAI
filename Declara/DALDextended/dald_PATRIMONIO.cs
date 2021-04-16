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
    internal partial class dald_PATRIMONIO : dal_PATRIMONIO
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.PATRIMONIO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p.NID_PATRIMONIO).Max());
                return query + 1;
            }
            catch
            {
                return 1;
            }
        }


        internal static int nNuevo_NID_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                List<System.Nullable<Int32>> nPatrimonio = new List<System.Nullable<Int32>>();
                System.Nullable<Int32> query;

                try
                {
                    query = ((from p in db.PATRIMONIO
                              where p.VID_NOMBRE == VID_NOMBRE &&
                                    p.VID_FECHA == VID_FECHA &&
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }

                try
                {
                    query = ((from qALTA_INMUEBLE in db.ALTA_INMUEBLE
                              where
                                qALTA_INMUEBLE.VID_NOMBRE == VID_NOMBRE &&
                                qALTA_INMUEBLE.VID_FECHA == VID_FECHA &&
                                 qALTA_INMUEBLE.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                 qALTA_INMUEBLE.NID_DECLARACION == NID_DECLARACION
                              select qALTA_INMUEBLE.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }
                try
                {
                    query = ((from qALTA_MUEBLE in db.ALTA_MUEBLE
                              where
                               qALTA_MUEBLE.VID_NOMBRE == VID_NOMBRE &&
                               qALTA_MUEBLE.VID_FECHA == VID_FECHA &&
                                qALTA_MUEBLE.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                qALTA_MUEBLE.NID_DECLARACION == NID_DECLARACION
                              select qALTA_MUEBLE.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }
                try
                {
                    query = ((from qALTA_VEHICULO in db.ALTA_VEHICULO
                              where
                               qALTA_VEHICULO.VID_NOMBRE == VID_NOMBRE &&
                               qALTA_VEHICULO.VID_FECHA == VID_FECHA &&
                                qALTA_VEHICULO.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                qALTA_VEHICULO.NID_DECLARACION == NID_DECLARACION
                              select qALTA_VEHICULO.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }
                try
                {
                    query = ((from qALTA_ADEUDO in db.ALTA_ADEUDO
                              where
                               qALTA_ADEUDO.VID_NOMBRE == VID_NOMBRE &&
                               qALTA_ADEUDO.VID_FECHA == VID_FECHA &&
                                qALTA_ADEUDO.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                qALTA_ADEUDO.NID_DECLARACION == NID_DECLARACION
                              select qALTA_ADEUDO.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }
                try
                {
                    query = ((from qALTA_INVERSION in db.ALTA_INVERSION
                              where
                               qALTA_INVERSION.VID_NOMBRE == VID_NOMBRE &&
                               qALTA_INVERSION.VID_FECHA == VID_FECHA &&
                                qALTA_INVERSION.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                qALTA_INVERSION.NID_DECLARACION == NID_DECLARACION
                              select qALTA_INVERSION.NID_PATRIMONIO).Max());
                    if (query.HasValue) nPatrimonio.Add(query);
                }
                catch
                {

                }

                try
                {
                    List<String> pre = ((from qMODIFICACION_TAJETAS in db.MODIFICACION_TARJETA
                                         where
                                          qMODIFICACION_TAJETAS.VID_NOMBRE == VID_NOMBRE &&
                                          qMODIFICACION_TAJETAS.VID_FECHA == VID_FECHA &&
                                           qMODIFICACION_TAJETAS.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                           qMODIFICACION_TAJETAS.NID_DECLARACION == NID_DECLARACION
                                         select qMODIFICACION_TAJETAS.E_NUMERO_ASOCIACION).ToList());
                    List<Int32> entero = new List<int>();
                    foreach (String str in pre)
                        entero.Add(Convert.ToInt32(str));
                    if (entero.Any())
                        nPatrimonio.Add(entero.Max());
                }
                catch
                {

                }


                query = ((from p in nPatrimonio
                          select p).Max());

                return query.Value + 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }


        #endregion

    }
}
