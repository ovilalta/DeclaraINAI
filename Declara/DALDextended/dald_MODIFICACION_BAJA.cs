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
    internal partial class dald_MODIFICACION_BAJA : dal_MODIFICACION_BAJA
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***

        public dald_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA, Boolean L_POLIZA, Decimal M_VALOR, Int32 NID_TIPO_VENTA, String E_BENEFICIARIO)
   : base()
        {
            db.paMODIFICACION_BAJA(VID_NOMBRE,VID_FECHA,VID_HOMOCLAVE,NID_DECLARACION,NID_PATRIMONIO,NID_TIPO_BAJA,F_BAJA,L_POLIZA,M_VALOR,NID_TIPO_VENTA,E_BENEFICIARIO);
        }

        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.MODIFICACION_BAJA
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_PATRIMONIO).Max());
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
