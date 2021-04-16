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
    internal partial class dald_CAT_INST_FINANCIERA : dal_CAT_INST_FINANCIERA
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_INST_FINANCIERA()
        : base() { }

        internal dald_CAT_INST_FINANCIERA(CAT_INST_FINANCIERA CAT_INST_FINANCIERA)
        : base(CAT_INST_FINANCIERA) { }

        internal dald_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION)
        : base(NID_INSTITUCION) { }

        public dald_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION, String V_INSTITUCION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_INSTITUCION, V_INSTITUCION,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
