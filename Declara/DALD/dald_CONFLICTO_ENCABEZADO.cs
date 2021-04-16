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
    internal partial class dald_CONFLICTO_ENCABEZADO : dal_CONFLICTO_ENCABEZADO
    {

     #region *** Atributos ***

        internal List<CONFLICTO_RESPUESTA> _CONFLICTO_RESPUESTAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO_RESPUESTA
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_CONFLICTO == NID_CONFLICTO &&
                                   p.NID_RUBRO == NID_RUBRO &&
                                   p.NID_ENCABEZADO == NID_ENCABEZADO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CONFLICTO_ENCABEZADO()
        : base() { }

        internal dald_CONFLICTO_ENCABEZADO(CONFLICTO_ENCABEZADO CONFLICTO_ENCABEZADO)
        : base(CONFLICTO_ENCABEZADO) { }

        internal dald_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO) { }

        public dald_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, System.Nullable<Boolean> L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, L_CONFLICTO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
