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
    internal partial class dald_CAT_ENTIDAD_FEDERATIVA : dal_CAT_ENTIDAD_FEDERATIVA
    {

     #region *** Atributos ***

        #region * CAT_PAIS *

        dald_CAT_PAIS _oCAT_PAIS;
        private string cID_ENTIDAD_FEDERATIVA;

        dald_CAT_PAIS oCAT_PAIS
        {
            get
            {
                if(_oCAT_PAIS == null) _oCAT_PAIS= new dald_CAT_PAIS(NID_PAIS);
                return _oCAT_PAIS;
            }
        }

        internal String V_PAIS => oCAT_PAIS.V_PAIS;

        internal String V_NACIONALIDAD_M => oCAT_PAIS.V_NACIONALIDAD_M;

        internal String V_NACIONALIDAD_F => oCAT_PAIS.V_NACIONALIDAD_F;

        internal void Reload_CAT_PAIS() => _oCAT_PAIS = null;


        #endregion * CAT_PAIS *



     #endregion


     #region *** Constructores ***

        internal dald_CAT_ENTIDAD_FEDERATIVA(int? nID_PAIS)
        : base() { }

        internal dald_CAT_ENTIDAD_FEDERATIVA(CAT_ENTIDAD_FEDERATIVA CAT_ENTIDAD_FEDERATIVA)
        : base(CAT_ENTIDAD_FEDERATIVA) { }

        internal dald_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA) { }

        public dald_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_ENTIDAD_FEDERATIVA, lOpcionesRegistroExistente)  { }

        public dald_CAT_ENTIDAD_FEDERATIVA(int? nID_PAIS, string cID_ENTIDAD_FEDERATIVA) : this(nID_PAIS)
        {
            this.cID_ENTIDAD_FEDERATIVA = cID_ENTIDAD_FEDERATIVA;
        }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
