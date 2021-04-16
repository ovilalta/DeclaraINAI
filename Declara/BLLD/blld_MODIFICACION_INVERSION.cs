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
    public partial class blld_MODIFICACION_INVERSION : bll_MODIFICACION_INVERSION
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_INVERSION_TITU> _MODIFICACION_INVERSION_TITUs;
        public Lista<blld_MODIFICACION_INVERSION_TITU> MODIFICACION_INVERSION_TITUs
        {
          get
          {
              if(_MODIFICACION_INVERSION_TITUs == null)
              {
                  _MODIFICACION_INVERSION_TITUs = new Lista<blld_MODIFICACION_INVERSION_TITU>();
                  Reload_MODIFICACION_INVERSION_TITUs();
              }
              return _MODIFICACION_INVERSION_TITUs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_INVERSION()
        : base()
        {
            _MODIFICACION_INVERSION_TITUs = null;
        }

        public blld_MODIFICACION_INVERSION(MODELDeclara_V2.MODIFICACION_INVERSION MODIFICACION_INVERSION)
        : base(MODIFICACION_INVERSION)
        {
        }

        public  blld_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        public blld_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_SALDO_ANTERIOR, Decimal M_SALDO_ACTUAL, Boolean L_CANCELADA, Boolean L_MODIFICADA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_SALDO_ANTERIOR, M_SALDO_ACTUAL, L_CANCELADA, L_MODIFICADA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_INVERSION_TITUs()
        {
            _MODIFICACION_INVERSION_TITUs = new Lista<blld_MODIFICACION_INVERSION_TITU>();
            foreach (MODELDeclara_V2.MODIFICACION_INVERSION_TITU o in datos_MODIFICACION_INVERSION._MODIFICACION_INVERSION_TITUs)
            {
                _MODIFICACION_INVERSION_TITUs.Add(new blld_MODIFICACION_INVERSION_TITU(o));
            }
        }

        private void _Add_MODIFICACION_INVERSION_TITUs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_INVERSION_TITU oMODIFICACION_INVERSION_TITU = new blld_MODIFICACION_INVERSION_TITU(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_INVERSION_TITU.lEsNuevoRegistro.Value) MODIFICACION_INVERSION_TITUs.Add(oMODIFICACION_INVERSION_TITU);
                _MODIFICACION_INVERSION_TITUs[FindIndex_MODIFICACION_INVERSION_TITUs(NID_DEPENDIENTE)] = oMODIFICACION_INVERSION_TITU;
        }

        public Int32 FindIndex_MODIFICACION_INVERSION_TITUs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_INVERSION_TITUs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
