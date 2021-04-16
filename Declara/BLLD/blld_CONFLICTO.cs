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
    public partial class blld_CONFLICTO : bll_CONFLICTO
    {

     #region *** Atributos ***


        private Lista<blld_CONFLICTO_RUBRO> _CONFLICTO_RUBROs;
        public Lista<blld_CONFLICTO_RUBRO> CONFLICTO_RUBROs
        {
          get
          {
              if(_CONFLICTO_RUBROs == null)
              {
                  _CONFLICTO_RUBROs = new Lista<blld_CONFLICTO_RUBRO>();
                  Reload_CONFLICTO_RUBROs();
              }
              return _CONFLICTO_RUBROs;
          }
        }

        #region * CAT_ESTADO_CONFLICTO *


        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo E S T A D O_ C O N F L I C T O es requerido ")]
        [DisplayName("E S T A D O_ C O N F L I C T O")]
        public String V_ESTADO_CONFLICTO => datos_CONFLICTO.V_ESTADO_CONFLICTO;



        #endregion * CAT_ESTADO_CONFLICTO *



        #endregion


        #region *** Constructores ***

        private blld_CONFLICTO()
        : base()
        {
            _CONFLICTO_RUBROs = null;
        }

        public blld_CONFLICTO(MODELDeclara_V2.CONFLICTO CONFLICTO)
        : base(CONFLICTO)
        {
        }

        public  blld_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO)
        {
        }

        public blld_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, System.Nullable<Int32> NID_DEC_ASOS, Int32 NID_ESTADO_CONFLICTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_DEC_ASOS, NID_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_CONFLICTO_RUBROs()
        {
            _CONFLICTO_RUBROs = new Lista<blld_CONFLICTO_RUBRO>();
            foreach (MODELDeclara_V2.CONFLICTO_RUBRO o in datos_CONFLICTO._CONFLICTO_RUBROs)
            {
                _CONFLICTO_RUBROs.Add(new blld_CONFLICTO_RUBRO(o));
            }
        }

        private void _Add_CONFLICTO_RUBROs(Int32 NID_RUBRO, Boolean L_RESPUESTA)
        {
                blld_CONFLICTO_RUBRO oCONFLICTO_RUBRO = new blld_CONFLICTO_RUBRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, L_RESPUESTA);
                if (oCONFLICTO_RUBRO.lEsNuevoRegistro.Value) CONFLICTO_RUBROs.Add(oCONFLICTO_RUBRO);
                _CONFLICTO_RUBROs[FindIndex_CONFLICTO_RUBROs(NID_RUBRO)] = oCONFLICTO_RUBRO;
        }

        public Int32 FindIndex_CONFLICTO_RUBROs(Int32 NID_RUBRO)
        {
            return  CONFLICTO_RUBROs.FindIndex(p =>
                               p.NID_RUBRO == NID_RUBRO
                                                   );
        }



     #endregion

    }
}
