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
    internal partial class dald_CAT_PAIS : dal_CAT_PAIS
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_PAIS()
        : base() { }

        internal dald_CAT_PAIS(CAT_PAIS CAT_PAIS)
        : base(CAT_PAIS) { }

        internal dald_CAT_PAIS(Int32 NID_PAIS)
        : base(NID_PAIS) { }

        public dald_CAT_PAIS(Int32 NID_PAIS, String V_PAIS, String V_NACIONALIDAD_M, String V_NACIONALIDAD_F, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_PAIS, V_PAIS, V_NACIONALIDAD_M, V_NACIONALIDAD_F, lOpcionesRegistroExistente)  { }

        public dald_CAT_PAIS(int? nID_PAIS)
        {
        }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
