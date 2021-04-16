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
    public partial class blld_CONFLICTO_RUBRO : bll_CONFLICTO_RUBRO
    {

     #region *** Atributos ***


        private Lista<blld_CONFLICTO_ENCABEZADO> _CONFLICTO_ENCABEZADOs;
        public Lista<blld_CONFLICTO_ENCABEZADO> CONFLICTO_ENCABEZADOs
        {
          get
          {
              if(_CONFLICTO_ENCABEZADOs == null)
              {
                  _CONFLICTO_ENCABEZADOs = new Lista<blld_CONFLICTO_ENCABEZADO>();
                  Reload_CONFLICTO_ENCABEZADOs();
              }
              return _CONFLICTO_ENCABEZADOs;
          }
        }

        #region * CAT_CONFLICTO_RUBRO *


        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo R U B R O es requerido ")]
        [DisplayName("R U B R O")]
        public String V_RUBRO => datos_CONFLICTO_RUBRO.V_RUBRO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO => datos_CONFLICTO_RUBRO.C_INICIO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN => datos_CONFLICTO_RUBRO.C_FIN;

        #endregion * CAT_CONFLICTO_RUBRO *



     #endregion


     #region *** Constructores ***

        private blld_CONFLICTO_RUBRO()
        : base()
        {
            _CONFLICTO_ENCABEZADOs = null;
        }

        public blld_CONFLICTO_RUBRO(MODELDeclara_V2.CONFLICTO_RUBRO CONFLICTO_RUBRO)
        : base(CONFLICTO_RUBRO)
        {
        }

        public  blld_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO)
        {
        }

        public blld_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, System.Nullable<Boolean> L_RESPUESTA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, L_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_CONFLICTO_ENCABEZADOs()
        {
            _CONFLICTO_ENCABEZADOs = new Lista<blld_CONFLICTO_ENCABEZADO>();
            foreach (MODELDeclara_V2.CONFLICTO_ENCABEZADO o in datos_CONFLICTO_RUBRO._CONFLICTO_ENCABEZADOs)
            {
                _CONFLICTO_ENCABEZADOs.Add(new blld_CONFLICTO_ENCABEZADO(o));
            }
        }

        private void _Add_CONFLICTO_ENCABEZADOs()
        {
                blld_CONFLICTO_ENCABEZADO oCONFLICTO_ENCABEZADO = new blld_CONFLICTO_ENCABEZADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO);
                //CONFLICTO_ENCABEZADOs[FindIndex_CONFLICTO_ENCABEZADOs(NID_ENCABEZADO)] = oCONFLICTO_ENCABEZADO;
        }

        public Int32 FindIndex_CONFLICTO_ENCABEZADOs(Int32 NID_ENCABEZADO)
        {
            return  CONFLICTO_ENCABEZADOs.FindIndex(p =>
                               p.NID_ENCABEZADO == NID_ENCABEZADO
                                                   );
        }



     #endregion

    }
}
