using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_DEPENDIENTES_PUBLICO : dal_DECLARACION_DEPENDIENTES_PUBLICO
    {

        #region *** Propiedades ***
        #region * CAT_AMBITO_SECTOR *
        private dald_CAT_AMBITO_SECTOR _oCAT_AMBITO_SECTOR { get; set; }
        internal dald_CAT_AMBITO_SECTOR oCAT_AMBITO_SECTOR
        {
            get
            {
                if (_oCAT_AMBITO_SECTOR == null) _oCAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(NID_AMBITO_SECTOR);
                return _oCAT_AMBITO_SECTOR;
            }
        }
        internal void Reload_CAT_AMBITO_SECTOR() => _oCAT_AMBITO_SECTOR = null;

        #endregion * CAT_AMBITO_SECTOR *


        #region * CAT_NIVEL_GOBIERNO *
        private dald_CAT_NIVEL_GOBIERNO _oCAT_NIVEL_GOBIERNO { get; set; }
        internal dald_CAT_NIVEL_GOBIERNO oCAT_NIVEL_GOBIERNO
        {
            get
            {
                if (_oCAT_NIVEL_GOBIERNO == null) _oCAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(NID_NIVEL_GOBIERNO);
                return _oCAT_NIVEL_GOBIERNO;
            }
        }
        internal void Reload_CAT_NIVEL_GOBIERNO() => _oCAT_NIVEL_GOBIERNO = null;

        #endregion * CAT_NIVEL_GOBIERNO *


        #region * CAT_AMBITO_PUBLICO *
        private dald_CAT_AMBITO_PUBLICO _oCAT_AMBITO_PUBLICO { get; set; }
        internal dald_CAT_AMBITO_PUBLICO oCAT_AMBITO_PUBLICO
        {
            get
            {
                if (_oCAT_AMBITO_PUBLICO == null) _oCAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(NID_AMBITO_PUBLICO);
                return _oCAT_AMBITO_PUBLICO;
            }
        }
        internal void Reload_CAT_AMBITO_PUBLICO() => _oCAT_AMBITO_PUBLICO = null;

        #endregion * CAT_AMBITO_PUBLICO *


        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_DEPENDIENTES_PUBLICO() : base() { }
        internal dald_DECLARACION_DEPENDIENTES_PUBLICO(DECLARACION_DEPENDIENTES_PUBLICO DECLARACION_DEPENDIENTES_PUBLICO) : base(DECLARACION_DEPENDIENTES_PUBLICO) { }
        internal dald_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE) { }
        internal dald_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, V_NOMBRE_ENTE, V_AREA_ADSCRIPCION, V_CARGO, V_FUNCION_PRINCIPAL, M_SALARIO_MENSUAL, F_INGRESO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
