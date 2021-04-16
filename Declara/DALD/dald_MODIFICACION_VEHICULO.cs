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
    internal partial class dald_MODIFICACION_VEHICULO : dal_MODIFICACION_VEHICULO
    {

     #region *** Atributos ***

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

        internal Boolean L_ACTIVO => oCAT_USO_VEHICULO.L_ACTIVO;

        internal void Reload_CAT_USO_VEHICULO() => _oCAT_USO_VEHICULO = null;


        #endregion * CAT_USO_VEHICULO *


        internal List<MODIFICACION_VEHICULO_ADEU> _MODIFICACION_VEHICULO_ADEUs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_VEHICULO_ADEU
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_VEHICULO_TITU> _MODIFICACION_VEHICULO_TITUs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_VEHICULO_TITU
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_VEHICULO()
        : base() { }

        internal dald_MODIFICACION_VEHICULO(MODIFICACION_VEHICULO MODIFICACION_VEHICULO)
        : base(MODIFICACION_VEHICULO) { }

        internal dald_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Boolean L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, L_MODIFICADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
