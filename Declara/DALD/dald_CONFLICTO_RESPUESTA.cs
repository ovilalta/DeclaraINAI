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
    internal partial class dald_CONFLICTO_RESPUESTA : dal_CONFLICTO_RESPUESTA
    {

     #region *** Atributos ***

        #region * CAT_CONFLICTO_PREGUNTA *

        dald_CAT_CONFLICTO_PREGUNTA _oCAT_CONFLICTO_PREGUNTA;
        dald_CAT_CONFLICTO_PREGUNTA oCAT_CONFLICTO_PREGUNTA
        {
            get
            {
                if(_oCAT_CONFLICTO_PREGUNTA == null) _oCAT_CONFLICTO_PREGUNTA= new dald_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA);
                return _oCAT_CONFLICTO_PREGUNTA;
            }
        }

        internal String V_RUBRO => oCAT_CONFLICTO_PREGUNTA.V_RUBRO;

        internal String C_INICIO => oCAT_CONFLICTO_PREGUNTA.C_INICIO;

        internal String C_FIN => oCAT_CONFLICTO_PREGUNTA.C_FIN;

        internal void Reload_CAT_CONFLICTO_PREGUNTA() => _oCAT_CONFLICTO_PREGUNTA = null;


        #endregion * CAT_CONFLICTO_PREGUNTA *



     #endregion


     #region *** Constructores ***

        internal dald_CONFLICTO_RESPUESTA()
        : base() { }

        internal dald_CONFLICTO_RESPUESTA(CONFLICTO_RESPUESTA CONFLICTO_RESPUESTA)
        : base(CONFLICTO_RESPUESTA) { }

        internal dald_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA) { }

        public dald_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA, String V_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA, V_RESPUESTA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
