using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION : dal_DECLARACION
    {

        #region *** Propiedades ***
        #region * CAT_TIPO_DECLARACION *
        private dald_CAT_TIPO_DECLARACION _oCAT_TIPO_DECLARACION { get; set; }
        internal dald_CAT_TIPO_DECLARACION oCAT_TIPO_DECLARACION
        {
            get
            {
                if (_oCAT_TIPO_DECLARACION == null) _oCAT_TIPO_DECLARACION = new dald_CAT_TIPO_DECLARACION(NID_TIPO_DECLARACION);
                return _oCAT_TIPO_DECLARACION;
            }
        }
        internal void Reload_CAT_TIPO_DECLARACION() => _oCAT_TIPO_DECLARACION = null;

        #endregion * CAT_TIPO_DECLARACION *


        #region * CAT_ESTADO_DECLARACION *
        private dald_CAT_ESTADO_DECLARACION _oCAT_ESTADO_DECLARACION { get; set; }
        internal dald_CAT_ESTADO_DECLARACION oCAT_ESTADO_DECLARACION
        {
            get
            {
                if (_oCAT_ESTADO_DECLARACION == null) _oCAT_ESTADO_DECLARACION = new dald_CAT_ESTADO_DECLARACION(NID_ESTADO);
                return _oCAT_ESTADO_DECLARACION;
            }
        }
        internal void Reload_CAT_ESTADO_DECLARACION() => _oCAT_ESTADO_DECLARACION = null;

        #endregion * CAT_ESTADO_DECLARACION *


        #region * CAT_ESTADO_TESTADO *
        private dald_CAT_ESTADO_TESTADO _oCAT_ESTADO_TESTADO { get; set; }
        internal dald_CAT_ESTADO_TESTADO oCAT_ESTADO_TESTADO
        {
            get
            {
                if (_oCAT_ESTADO_TESTADO == null) _oCAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO(NID_ESTADO_TESTADO);
                return _oCAT_ESTADO_TESTADO;
            }
        }
        internal void Reload_CAT_ESTADO_TESTADO() => _oCAT_ESTADO_TESTADO = null;

        #endregion * CAT_ESTADO_TESTADO *


        internal List<DECLARACION_ESCOLARIDAD> _DECLARACION_ESCOLARIDADs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_ESCOLARIDAD).Load();
                return registro.DECLARACION_ESCOLARIDAD.ToList();
            }
        }
        internal Int32 DECLARACION_ESCOLARIDAD_Count() => db.Entry(registro).Collection(b => b.DECLARACION_ESCOLARIDAD).Query().Count();
        internal void DECLARACION_ESCOLARIDAD_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_ESCOLARIDAD).CurrentValue.Clear();

        internal List<DECLARACION_APARTADO> _DECLARACION_APARTADOs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_APARTADO).Load();
                return registro.DECLARACION_APARTADO.ToList();
            }
        }
        internal Int32 DECLARACION_APARTADO_Count() => db.Entry(registro).Collection(b => b.DECLARACION_APARTADO).Query().Count();
        internal void DECLARACION_APARTADO_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_APARTADO).CurrentValue.Clear();

        internal List<DECLARACION_DEPENDIENTES> _DECLARACION_DEPENDIENTESs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_DEPENDIENTES).Load();
                return registro.DECLARACION_DEPENDIENTES.ToList();
            }
        }
        internal Int32 DECLARACION_DEPENDIENTES_Count() => db.Entry(registro).Collection(b => b.DECLARACION_DEPENDIENTES).Query().Count();
        internal void DECLARACION_DEPENDIENTES_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_DEPENDIENTES).CurrentValue.Clear();

        internal List<DECLARACION_EGRESOS> _DECLARACION_EGRESOSs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_EGRESOS).Load();
                return registro.DECLARACION_EGRESOS.ToList();
            }
        }
        internal Int32 DECLARACION_EGRESOS_Count() => db.Entry(registro).Collection(b => b.DECLARACION_EGRESOS).Query().Count();
        internal void DECLARACION_EGRESOS_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_EGRESOS).CurrentValue.Clear();

        internal List<DECLARACION_INGRESOS> _DECLARACION_INGRESOSs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_INGRESOS).Load();
                return registro.DECLARACION_INGRESOS.ToList();
            }
        }
        internal Int32 DECLARACION_INGRESOS_Count() => db.Entry(registro).Collection(b => b.DECLARACION_INGRESOS).Query().Count();
        internal void DECLARACION_INGRESOS_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_INGRESOS).CurrentValue.Clear();

        internal List<DECLARACION_RESTRICCIONES> _DECLARACION_RESTRICCIONESs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_RESTRICCIONES).Load();
                return registro.DECLARACION_RESTRICCIONES.ToList();
            }
        }
        internal Int32 DECLARACION_RESTRICCIONES_Count() => db.Entry(registro).Collection(b => b.DECLARACION_RESTRICCIONES).Query().Count();
        internal void DECLARACION_RESTRICCIONES_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_RESTRICCIONES).CurrentValue.Clear();

        internal List<DECLARACION_EXPERIENCIA_LABORAL> _DECLARACION_EXPERIENCIA_LABORALs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_EXPERIENCIA_LABORAL).Load();
                return registro.DECLARACION_EXPERIENCIA_LABORAL.ToList();
            }
        }
        internal Int32 DECLARACION_EXPERIENCIA_LABORAL_Count() => db.Entry(registro).Collection(b => b.DECLARACION_EXPERIENCIA_LABORAL).Query().Count();
        internal void DECLARACION_EXPERIENCIA_LABORAL_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_EXPERIENCIA_LABORAL).CurrentValue.Clear();

        internal List<DECLARACION_REGIMEN_MATRIMONIAL> _DECLARACION_REGIMEN_MATRIMONIALs
        {
            get
            {
                db.Entry(registro).Collection(p => p.DECLARACION_REGIMEN_MATRIMONIAL).Load();
                return registro.DECLARACION_REGIMEN_MATRIMONIAL.ToList();
            }
        }
        internal Int32 DECLARACION_REGIMEN_MATRIMONIAL_Count() => db.Entry(registro).Collection(b => b.DECLARACION_REGIMEN_MATRIMONIAL).Query().Count();
        internal void DECLARACION_REGIMEN_MATRIMONIAL_Clear() => db.Entry(registro).Collection(p => p.DECLARACION_REGIMEN_MATRIMONIAL).CurrentValue.Clear();

        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION() : base() { }
        internal dald_DECLARACION(DECLARACION DECLARACION) : base(DECLARACION) { }
        internal dald_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }
        internal dald_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, System.Nullable<DateTime> F_ENVIO, System.Nullable<Boolean> L_CONFLICTO, String V_HASH, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, V_HASH, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
