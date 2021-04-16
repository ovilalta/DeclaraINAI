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
    internal partial class dald_H_PATRIMONIO_VEHICULO : dal_H_PATRIMONIO_VEHICULO
    {

     #region *** Atributos ***

        #region * CAT_USO_VEHICULO *

        dald_CAT_USO_VEHICULO _oCAT_USO_VEHICULO;
        dald_CAT_USO_VEHICULO oCAT_USO_VEHICULO
        {
            get
            {
                if(_oCAT_USO_VEHICULO == null) _oCAT_USO_VEHICULO= new dald_CAT_USO_VEHICULO(NID_USO);
                return _oCAT_USO_VEHICULO;
            }
        }

        internal String V_USO => oCAT_USO_VEHICULO.V_USO;

        internal void Reload_CAT_USO_VEHICULO() => _oCAT_USO_VEHICULO = null;


        #endregion * CAT_USO_VEHICULO *


        #region * CAT_MARCA_VEHICULO *

        dald_CAT_MARCA_VEHICULO _oCAT_MARCA_VEHICULO;
        dald_CAT_MARCA_VEHICULO oCAT_MARCA_VEHICULO
        {
            get
            {
                if(_oCAT_MARCA_VEHICULO == null) _oCAT_MARCA_VEHICULO= new dald_CAT_MARCA_VEHICULO(NID_MARCA);
                return _oCAT_MARCA_VEHICULO;
            }
        }

        internal String V_MARCA => oCAT_MARCA_VEHICULO.V_MARCA;

        internal void Reload_CAT_MARCA_VEHICULO() => _oCAT_MARCA_VEHICULO = null;


        #endregion * CAT_MARCA_VEHICULO *



     #endregion


     #region *** Constructores ***

        internal dald_H_PATRIMONIO_VEHICULO()
        : base() { }

        internal dald_H_PATRIMONIO_VEHICULO(H_PATRIMONIO_VEHICULO H_PATRIMONIO_VEHICULO)
        : base(H_PATRIMONIO_VEHICULO) { }

        internal dald_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO) { }

        public dald_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
