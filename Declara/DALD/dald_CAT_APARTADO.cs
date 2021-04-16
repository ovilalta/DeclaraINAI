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
    internal partial class dald_CAT_APARTADO : dal_CAT_APARTADO
    {

        #region *** Atributos ***

        internal List<DECLARACION_APARTADO> _DECLARACION_APARTADOs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.DECLARACION_APARTADO
                        where
                             p.NID_APARTADO == NID_APARTADO
                        select p).ToList();
            }
        }


        #endregion


        #region *** Constructores ***

        internal dald_CAT_APARTADO()
        : base() { }

        internal dald_CAT_APARTADO(CAT_APARTADO CAT_APARTADO)
        : base(CAT_APARTADO) { }

        internal dald_CAT_APARTADO(Int32 NID_APARTADO)
        : base(NID_APARTADO) { }

        //public dald_CAT_APARTADO(Int32 NID_APARTADO, String V_APARTADO, System.Nullable<Int32> NID_APARTADO_SUPERIOR, System.Nullable<Int32> N_APARTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        //: base(NID_APARTADO, V_APARTADO, NID_APARTADO_SUPERIOR, N_APARTADO, lOpcionesRegistroExistente)  { }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
