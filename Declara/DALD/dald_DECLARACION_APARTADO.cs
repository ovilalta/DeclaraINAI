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
    internal partial class dald_DECLARACION_APARTADO : dal_DECLARACION_APARTADO
    {

     #region *** Atributos ***

        #region * CAT_APARTADO *

        dald_CAT_APARTADO _oCAT_APARTADO;
        dald_CAT_APARTADO oCAT_APARTADO
        {
            get
            {
                if(_oCAT_APARTADO == null) _oCAT_APARTADO= new dald_CAT_APARTADO(NID_APARTADO);
                return _oCAT_APARTADO;
            }
        }

        internal String V_APARTADO => oCAT_APARTADO.V_APARTADO;

        internal System.Nullable<Int32> NID_APARTADO_SUPERIOR => oCAT_APARTADO.NID_APARTADO_SUPERIOR;

        internal System.Nullable<Int32> N_APARTADO => oCAT_APARTADO.N_APARTADO;

        internal void Reload_CAT_APARTADO() => _oCAT_APARTADO = null;


        #endregion * CAT_APARTADO *



     #endregion


     #region *** Constructores ***

        internal dald_DECLARACION_APARTADO()
        : base() { }

        internal dald_DECLARACION_APARTADO(DECLARACION_APARTADO DECLARACION_APARTADO)
        : base(DECLARACION_APARTADO) { }

        internal dald_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO) { }

        public dald_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO, System.Nullable<Boolean> L_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO, L_ESTADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
