using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_MODIFICACION_ADEUDO : bll_MODIFICACION_ADEUDO
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_ADEUDO_TITULAR> _MODIFICACION_ADEUDO_TITULARs;
        public Lista<blld_MODIFICACION_ADEUDO_TITULAR> MODIFICACION_ADEUDO_TITULARs
        {
          get
          {
              if(_MODIFICACION_ADEUDO_TITULARs == null)
              {
                  _MODIFICACION_ADEUDO_TITULARs = new Lista<blld_MODIFICACION_ADEUDO_TITULAR>();
                  Reload_MODIFICACION_ADEUDO_TITULARs();
              }
              return _MODIFICACION_ADEUDO_TITULARs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_ADEUDO()
        : base()
        {
            _MODIFICACION_ADEUDO_TITULARs = null;
        }

        public blld_MODIFICACION_ADEUDO(MODELDeclara_V2.MODIFICACION_ADEUDO MODIFICACION_ADEUDO)
        : base(MODIFICACION_ADEUDO)
        {
        }

        public  blld_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        public blld_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_PAGOS, Decimal M_SALDOS, Boolean L_CANCELADO, Boolean L_MODIFICADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_PAGOS, M_SALDOS, L_CANCELADO, L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_ADEUDO_TITULARs()
        {
            _MODIFICACION_ADEUDO_TITULARs = new Lista<blld_MODIFICACION_ADEUDO_TITULAR>();
            foreach (MODELDeclara_V2.MODIFICACION_ADEUDO_TITULAR o in datos_MODIFICACION_ADEUDO._MODIFICACION_ADEUDO_TITULARs)
            {
                _MODIFICACION_ADEUDO_TITULARs.Add(new blld_MODIFICACION_ADEUDO_TITULAR(o));
            }
        }

        private void _Add_MODIFICACION_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_ADEUDO_TITULAR oMODIFICACION_ADEUDO_TITULAR = new blld_MODIFICACION_ADEUDO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_ADEUDO_TITULAR.lEsNuevoRegistro.Value) MODIFICACION_ADEUDO_TITULARs.Add(oMODIFICACION_ADEUDO_TITULAR);
                _MODIFICACION_ADEUDO_TITULARs[FindIndex_MODIFICACION_ADEUDO_TITULARs(NID_DEPENDIENTE)] = oMODIFICACION_ADEUDO_TITULAR;
        }

        public Int32 FindIndex_MODIFICACION_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_ADEUDO_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
