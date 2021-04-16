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
    internal partial class dald_ALTA_VEHICULO : dal_ALTA_VEHICULO
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


        internal void Reload_CAT_USO_VEHICULO() => _oCAT_USO_VEHICULO = null;


        #endregion * CAT_USO_VEHICULO *


        internal List<ALTA_VEHICULO_TITULAR> _ALTA_VEHICULO_TITULARs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_VEHICULO_TITULAR
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_VEHICULO == NID_VEHICULO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_ALTA_VEHICULO()
        : base() { }

        internal dald_ALTA_VEHICULO(ALTA_VEHICULO ALTA_VEHICULO)
        : base(ALTA_VEHICULO) { }

        internal dald_ALTA_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO) { }

        public dald_ALTA_VEHICULO(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_VEHICULO
                                , Int32 NID_MARCA
                                , String C_MODELO
                                , String V_DESCRIPCION
                                , DateTime F_ADQUISICION
                                , Int32 NID_TIPO_COMPRA
                                , Int32 NID_USO
                                , Decimal M_VALOR_VEHICULO
                                , Int32 NID_PATRIMONIO
                                , Int32 NID_PAIS
                                , String CID_ENTIDAD_FEDERATIVA
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , String E_NUMERO_SERIE
                                , Int32 NID_FORMA_ADQUISICION
                                , Int32 NID_FORMA_PAGO
                                , String E_OBSERVACIONES
                                , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                )
        : base(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_VEHICULO
                , NID_MARCA
                , C_MODELO
                , V_DESCRIPCION
                , F_ADQUISICION
                , NID_TIPO_COMPRA
                , NID_USO
                , M_VALOR_VEHICULO
                , NID_PATRIMONIO
                , NID_PAIS
                , CID_ENTIDAD_FEDERATIVA
                , CID_TIPO_PERSONA_TRANSMISOR
                , E_NOMBRE_TRANSMISOR
                , E_RFC_TRANSMISOR
                , NID_RELACION_TRANSMISOR
                , V_TIPO_MONEDA
                , E_NUMERO_SERIE
                , NID_FORMA_ADQUISICION
                , NID_FORMA_PAGO
                , E_OBSERVACIONES
                , lOpcionesRegistroExistente
                )  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
