using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA : dal_ALTA
    {

        #region *** Propiedades ***
        internal List<ALTA_INMUEBLE> _ALTA_INMUEBLEs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_INMUEBLE).Load();
                return registro.ALTA_INMUEBLE.ToList();
            }
        }
        internal Int32 ALTA_INMUEBLE_Count() => db.Entry(registro).Collection(b => b.ALTA_INMUEBLE).Query().Count();
        internal void ALTA_INMUEBLE_Clear() => db.Entry(registro).Collection(p => p.ALTA_INMUEBLE).CurrentValue.Clear();

        internal List<ALTA_INVERSION> _ALTA_INVERSIONs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_INVERSION).Load();
                return registro.ALTA_INVERSION.ToList();
            }
        }
        internal Int32 ALTA_INVERSION_Count() => db.Entry(registro).Collection(b => b.ALTA_INVERSION).Query().Count();
        internal void ALTA_INVERSION_Clear() => db.Entry(registro).Collection(p => p.ALTA_INVERSION).CurrentValue.Clear();

        internal List<ALTA_MUEBLE> _ALTA_MUEBLEs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_MUEBLE).Load();
                return registro.ALTA_MUEBLE.ToList();
            }
        }
        internal Int32 ALTA_MUEBLE_Count() => db.Entry(registro).Collection(b => b.ALTA_MUEBLE).Query().Count();
        internal void ALTA_MUEBLE_Clear() => db.Entry(registro).Collection(p => p.ALTA_MUEBLE).CurrentValue.Clear();

        internal List<ALTA_TARJETA> _ALTA_TARJETAs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_TARJETA).Load();
                return registro.ALTA_TARJETA.ToList();
            }
        }
        internal Int32 ALTA_TARJETA_Count() => db.Entry(registro).Collection(b => b.ALTA_TARJETA).Query().Count();
        internal void ALTA_TARJETA_Clear() => db.Entry(registro).Collection(p => p.ALTA_TARJETA).CurrentValue.Clear();

        internal List<ALTA_VEHICULO> _ALTA_VEHICULOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_VEHICULO).Load();
                return registro.ALTA_VEHICULO.ToList();
            }
        }
        internal Int32 ALTA_VEHICULO_Count() => db.Entry(registro).Collection(b => b.ALTA_VEHICULO).Query().Count();
        internal void ALTA_VEHICULO_Clear() => db.Entry(registro).Collection(p => p.ALTA_VEHICULO).CurrentValue.Clear();

        internal List<ALTA_ADEUDO> _ALTA_ADEUDOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.ALTA_ADEUDO).Load();
                return registro.ALTA_ADEUDO.ToList();
            }
        }
        internal Int32 ALTA_ADEUDO_Count() => db.Entry(registro).Collection(b => b.ALTA_ADEUDO).Query().Count();
        internal void ALTA_ADEUDO_Clear() => db.Entry(registro).Collection(p => p.ALTA_ADEUDO).CurrentValue.Clear();

        #endregion


        #region *** Constructores ***
        internal dald_ALTA() : base() { }
        internal dald_ALTA(ALTA ALTA) : base(ALTA) { }
        internal dald_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }
        internal dald_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
