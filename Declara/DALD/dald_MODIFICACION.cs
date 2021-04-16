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
    internal partial class dald_MODIFICACION : dal_MODIFICACION
    {

     #region *** Atributos ***

        internal List<MODIFICACION_INVERSION> _MODIFICACION_INVERSIONs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_INVERSION
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_TARJETA> _MODIFICACION_TARJETAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_TARJETA
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_ADEUDO> _MODIFICACION_ADEUDOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_ADEUDO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_VEHICULO> _MODIFICACION_VEHICULOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_VEHICULO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_INMUEBLE> _MODIFICACION_INMUEBLEs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_INMUEBLE
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_MUEBLE> _MODIFICACION_MUEBLEs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_MUEBLE
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_GASTO> _MODIFICACION_GASTOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_GASTO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_BAJA> _MODIFICACION_BAJAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_BAJA
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_INGRESOS> _MODIFICACION_INGRESOSs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_INGRESOS
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION()
        : base() { }

        internal dald_MODIFICACION(MODIFICACION MODIFICACION)
        : base(MODIFICACION) { }

        internal dald_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

        public dald_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, System.Nullable<Boolean> L_PRESENTO_DEC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, L_PRESENTO_DEC, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
