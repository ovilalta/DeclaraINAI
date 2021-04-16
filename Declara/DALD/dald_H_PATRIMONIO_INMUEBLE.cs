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
    internal partial class dald_H_PATRIMONIO_INMUEBLE : dal_H_PATRIMONIO_INMUEBLE
    {

     #region *** Atributos ***

        #region * CAT_TIPO_INMUEBLE *

        dald_CAT_TIPO_INMUEBLE _oCAT_TIPO_INMUEBLE;
        dald_CAT_TIPO_INMUEBLE oCAT_TIPO_INMUEBLE
        {
            get
            {
                if(_oCAT_TIPO_INMUEBLE == null) _oCAT_TIPO_INMUEBLE= new dald_CAT_TIPO_INMUEBLE(NID_TIPO);
                return _oCAT_TIPO_INMUEBLE;
            }
        }

        internal String V_TIPO => oCAT_TIPO_INMUEBLE.V_TIPO;

        internal void Reload_CAT_TIPO_INMUEBLE() => _oCAT_TIPO_INMUEBLE = null;


        #endregion * CAT_TIPO_INMUEBLE *


        #region * CAT_USO_INMUEBLE *

        dald_CAT_USO_INMUEBLE _oCAT_USO_INMUEBLE;
        dald_CAT_USO_INMUEBLE oCAT_USO_INMUEBLE
        {
            get
            {
                if(_oCAT_USO_INMUEBLE == null) _oCAT_USO_INMUEBLE= new dald_CAT_USO_INMUEBLE(NID_USO);
                return _oCAT_USO_INMUEBLE;
            }
        }

        internal String V_USO => oCAT_USO_INMUEBLE.V_USO;

        internal void Reload_CAT_USO_INMUEBLE() => _oCAT_USO_INMUEBLE = null;


        #endregion * CAT_USO_INMUEBLE *



     #endregion


     #region *** Constructores ***

        internal dald_H_PATRIMONIO_INMUEBLE()
        : base() { }

        internal dald_H_PATRIMONIO_INMUEBLE(H_PATRIMONIO_INMUEBLE H_PATRIMONIO_INMUEBLE)
        : base(H_PATRIMONIO_INMUEBLE) { }

        internal dald_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO) { }

        public dald_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
