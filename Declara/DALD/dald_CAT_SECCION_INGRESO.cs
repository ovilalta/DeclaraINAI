using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_SECCION_INGRESO : dal_CAT_SECCION_INGRESO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_SECCION_INGRESO() : base() { }
        internal dald_CAT_SECCION_INGRESO(CAT_SECCION_INGRESO CAT_SECCION_INGRESO) : base(CAT_SECCION_INGRESO) { }
        internal dald_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO)
        : base(NID_SECCION, NID_RUBRO) { }
        internal dald_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_SECCION, NID_RUBRO, V_RUBRO, L_VIGENTE, CID_TIPO, NID_RUBRO_SUMA, C_TITULAR, V_CATALOGO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
