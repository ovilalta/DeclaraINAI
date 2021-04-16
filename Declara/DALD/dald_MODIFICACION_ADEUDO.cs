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
    internal partial class dald_MODIFICACION_ADEUDO : dal_MODIFICACION_ADEUDO
    {

     #region *** Atributos ***

        internal List<MODIFICACION_ADEUDO_TITULAR> _MODIFICACION_ADEUDO_TITULARs
        {
            get
            {
              MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_ADEUDO_TITULAR
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_ADEUDO()
        : base() { }

        internal dald_MODIFICACION_ADEUDO(MODIFICACION_ADEUDO MODIFICACION_ADEUDO)
        : base(MODIFICACION_ADEUDO) { }

        internal dald_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_PAGOS, Decimal M_SALDOS, Boolean L_CANCELADO, Boolean L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_PAGOS, M_SALDOS, L_CANCELADO, L_MODIFICADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
