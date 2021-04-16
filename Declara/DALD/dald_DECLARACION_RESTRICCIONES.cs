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
    internal partial class dald_DECLARACION_RESTRICCIONES : dal_DECLARACION_RESTRICCIONES
    {

     #region *** Atributos ***

        #region * CAT_RESTRICCIONES *

        dald_CAT_RESTRICCIONES _oCAT_RESTRICCIONES;
        dald_CAT_RESTRICCIONES oCAT_RESTRICCIONES
        {
            get
            {
                if(_oCAT_RESTRICCIONES == null) _oCAT_RESTRICCIONES= new dald_CAT_RESTRICCIONES(NID_RESTRICCION);
                return _oCAT_RESTRICCIONES;
            }
        }

        internal String V_RESTRICCION => oCAT_RESTRICCIONES.V_RESTRICCION;

        internal Boolean L_VIGENTE => oCAT_RESTRICCIONES.L_VIGENTE;

        internal void Reload_CAT_RESTRICCIONES() => _oCAT_RESTRICCIONES = null;


        #endregion * CAT_RESTRICCIONES *



     #endregion


     #region *** Constructores ***

        internal dald_DECLARACION_RESTRICCIONES()
        : base() { }

        internal dald_DECLARACION_RESTRICCIONES(DECLARACION_RESTRICCIONES DECLARACION_RESTRICCIONES)
        : base(DECLARACION_RESTRICCIONES) { }

        internal dald_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION) { }

        public dald_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION, Boolean L_RESPUESTA, Boolean L_AUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION, L_RESPUESTA, L_AUTO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
