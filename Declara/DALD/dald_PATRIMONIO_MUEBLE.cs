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
    internal partial class dald_PATRIMONIO_MUEBLE : dal_PATRIMONIO_MUEBLE
    {

     #region *** Atributos ***

        #region * CAT_TIPO_MUEBLE *

        dald_CAT_TIPO_MUEBLE _oCAT_TIPO_MUEBLE;
        dald_CAT_TIPO_MUEBLE oCAT_TIPO_MUEBLE
        {
            get
            {
                if(_oCAT_TIPO_MUEBLE == null) _oCAT_TIPO_MUEBLE= new dald_CAT_TIPO_MUEBLE(NID_TIPO);
                return _oCAT_TIPO_MUEBLE;
            }
        }

        internal String V_TIPO => oCAT_TIPO_MUEBLE.V_TIPO;

        internal void Reload_CAT_TIPO_MUEBLE() => _oCAT_TIPO_MUEBLE = null;


        #endregion * CAT_TIPO_MUEBLE *



     #endregion


     #region *** Constructores ***

        internal dald_PATRIMONIO_MUEBLE()
        : base() { }

        internal dald_PATRIMONIO_MUEBLE(PATRIMONIO_MUEBLE PATRIMONIO_MUEBLE)
        : base(PATRIMONIO_MUEBLE) { }

        internal dald_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO) { }

        public dald_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR,DateTime F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR,F_ADQUISICION, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
