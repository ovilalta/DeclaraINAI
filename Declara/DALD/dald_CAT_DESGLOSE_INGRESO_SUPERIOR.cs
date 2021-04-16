using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_DESGLOSE_INGRESO_SUPERIOR : dal_CAT_DESGLOSE_INGRESO_SUPERIOR
    {

        #region *** Propiedades ***
        internal List<CAT_DESGLOSE_INGRESO> _CAT_DESGLOSE_INGRESOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.CAT_DESGLOSE_INGRESO).Load();
                return registro.CAT_DESGLOSE_INGRESO.ToList();
            }
        }
        internal Int32 CAT_DESGLOSE_INGRESO_Count() => db.Entry(registro).Collection(b => b.CAT_DESGLOSE_INGRESO).Query().Count();
        internal void CAT_DESGLOSE_INGRESO_Clear() => db.Entry(registro).Collection(p => p.CAT_DESGLOSE_INGRESO).CurrentValue.Clear();

        #endregion


        #region *** Constructores ***
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR() : base() { }
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR(CAT_DESGLOSE_INGRESO_SUPERIOR CAT_DESGLOSE_INGRESO_SUPERIOR) : base(CAT_DESGLOSE_INGRESO_SUPERIOR) { }
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR)
        : base(NID_INGRESO_SUPERIOR) { }
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO_SUPERIOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_INGRESO_SUPERIOR, V_INGRESO_SUPERIOR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
