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
    internal partial class dald_PATRIMONIO_DEPENDIENTES : dal_PATRIMONIO_DEPENDIENTES
    {

     #region *** Atributos ***

        #region * CAT_TIPO_DEPENDIENTES *

        dald_CAT_TIPO_DEPENDIENTES _oCAT_TIPO_DEPENDIENTES;
        dald_CAT_TIPO_DEPENDIENTES oCAT_TIPO_DEPENDIENTES
        {
            get
            {
                if(_oCAT_TIPO_DEPENDIENTES == null) _oCAT_TIPO_DEPENDIENTES= new dald_CAT_TIPO_DEPENDIENTES(NID_TIPO_DEPENDIENTE);
                return _oCAT_TIPO_DEPENDIENTES;
            }
        }

        internal String V_TIPO_DEPENDIENTE => oCAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE;

        internal void Reload_CAT_TIPO_DEPENDIENTES() => _oCAT_TIPO_DEPENDIENTES = null;


        #endregion * CAT_TIPO_DEPENDIENTES *



     #endregion


     #region *** Constructores ***

        internal dald_PATRIMONIO_DEPENDIENTES()
        : base() { }

        internal dald_PATRIMONIO_DEPENDIENTES(PATRIMONIO_DEPENDIENTES PATRIMONIO_DEPENDIENTES)
        : base(PATRIMONIO_DEPENDIENTES) { }

        internal dald_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE) { }

        public dald_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String V_DOMICILIO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, V_DOMICILIO, L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
