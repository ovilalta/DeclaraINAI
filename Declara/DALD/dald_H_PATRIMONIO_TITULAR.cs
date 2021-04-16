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
    internal partial class dald_H_PATRIMONIO_TITULAR : dal_H_PATRIMONIO_TITULAR
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_H_PATRIMONIO_TITULAR()
        : base() { }

        internal dald_H_PATRIMONIO_TITULAR(H_PATRIMONIO_TITULAR H_PATRIMONIO_TITULAR)
        : base(H_PATRIMONIO_TITULAR) { }

        internal dald_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO) { }

        public dald_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
