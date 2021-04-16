using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_DEPENDIENTES_PRIVADO : dal_DECLARACION_DEPENDIENTES_PRIVADO
    {

        #region *** Propiedades ***
        #region * CAT_SECTOR *
        private dald_CAT_SECTOR _oCAT_SECTOR { get; set; }
        internal dald_CAT_SECTOR oCAT_SECTOR
        {
            get
            {
                if (_oCAT_SECTOR == null) _oCAT_SECTOR = new dald_CAT_SECTOR(NID_SECTOR);
                return _oCAT_SECTOR;
            }
        }
        internal void Reload_CAT_SECTOR() => _oCAT_SECTOR = null;

        #endregion * CAT_SECTOR *


        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_DEPENDIENTES_PRIVADO() : base() { }
        internal dald_DECLARACION_DEPENDIENTES_PRIVADO(DECLARACION_DEPENDIENTES_PRIVADO DECLARACION_DEPENDIENTES_PRIVADO) : base(DECLARACION_DEPENDIENTES_PRIVADO) { }
        internal dald_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE) { }
        internal dald_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, V_NOMBRE, V_CARGO, V_RFC, F_INGRESO, NID_SECTOR, M_SALARIO_MENSUAL, L_PROVEEDOR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
