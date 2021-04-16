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
    internal partial class dald_MODIFICACION_BAJA_SINIESTRO : dal_MODIFICACION_BAJA_SINIESTRO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_BAJA_SINIESTRO()
        : base() { }

        internal dald_MODIFICACION_BAJA_SINIESTRO(MODIFICACION_BAJA_SINIESTRO MODIFICACION_BAJA_SINIESTRO)
        : base(MODIFICACION_BAJA_SINIESTRO) { }

        internal dald_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Boolean L_POLIZA, Decimal M_RECUPERADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, L_POLIZA, M_RECUPERADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
