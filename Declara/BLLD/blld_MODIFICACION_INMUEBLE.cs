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
    public partial class blld_MODIFICACION_INMUEBLE : bll_MODIFICACION_INMUEBLE
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_INMUEBLE_ADEUDO> _MODIFICACION_INMUEBLE_ADEUDOs;
        public Lista<blld_MODIFICACION_INMUEBLE_ADEUDO> MODIFICACION_INMUEBLE_ADEUDOs
        {
          get
          {
              if(_MODIFICACION_INMUEBLE_ADEUDOs == null)
              {
                  _MODIFICACION_INMUEBLE_ADEUDOs = new Lista<blld_MODIFICACION_INMUEBLE_ADEUDO>();
                  Reload_MODIFICACION_INMUEBLE_ADEUDOs();
              }
              return _MODIFICACION_INMUEBLE_ADEUDOs;
          }
        }

        private Lista<blld_MODIFICACION_INMUEBLE_TITULA> _MODIFICACION_INMUEBLE_TITULAs;
        public Lista<blld_MODIFICACION_INMUEBLE_TITULA> MODIFICACION_INMUEBLE_TITULAs
        {
          get
          {
              if(_MODIFICACION_INMUEBLE_TITULAs == null)
              {
                  _MODIFICACION_INMUEBLE_TITULAs = new Lista<blld_MODIFICACION_INMUEBLE_TITULA>();
                  Reload_MODIFICACION_INMUEBLE_TITULAs();
              }
              return _MODIFICACION_INMUEBLE_TITULAs;
          }
        }

        #region * CAT_TIPO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O es requerido ")]
        [DisplayName("T I P O")]
        public String V_TIPO => datos_MODIFICACION_INMUEBLE.V_TIPO;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_MODIFICACION_INMUEBLE.L_ACTIVO;

        #endregion * CAT_TIPO_INMUEBLE *


        #region * CAT_USO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo U S O es requerido ")]
        [DisplayName("U S O")]
        public String V_USO => datos_MODIFICACION_INMUEBLE.V_USO;





        #endregion * CAT_USO_INMUEBLE *



        #endregion


        #region *** Constructores ***

        private blld_MODIFICACION_INMUEBLE()
        : base()
        {
            _MODIFICACION_INMUEBLE_ADEUDOs = null;
            _MODIFICACION_INMUEBLE_TITULAs = null;
        }

        public blld_MODIFICACION_INMUEBLE(MODELDeclara_V2.MODIFICACION_INMUEBLE MODIFICACION_INMUEBLE)
        : base(MODIFICACION_INMUEBLE)
        {
        }

        public  blld_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        public blld_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, System.Nullable<Boolean> L_MODIFICADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_INMUEBLE_ADEUDOs()
        {
            _MODIFICACION_INMUEBLE_ADEUDOs = new Lista<blld_MODIFICACION_INMUEBLE_ADEUDO>();
            foreach (MODELDeclara_V2.MODIFICACION_INMUEBLE_ADEUDO o in datos_MODIFICACION_INMUEBLE._MODIFICACION_INMUEBLE_ADEUDOs)
            {
                _MODIFICACION_INMUEBLE_ADEUDOs.Add(new blld_MODIFICACION_INMUEBLE_ADEUDO(o));
            }
        }

        private void _Add_MODIFICACION_INMUEBLE_ADEUDOs(Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF)
        {
                blld_MODIFICACION_INMUEBLE_ADEUDO oMODIFICACION_INMUEBLE_ADEUDO = new blld_MODIFICACION_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, L_DIF);
                if (oMODIFICACION_INMUEBLE_ADEUDO.lEsNuevoRegistro.Value) MODIFICACION_INMUEBLE_ADEUDOs.Add(oMODIFICACION_INMUEBLE_ADEUDO);
                _MODIFICACION_INMUEBLE_ADEUDOs[FindIndex_MODIFICACION_INMUEBLE_ADEUDOs(NID_PATRIMONIO_ADEUDO)] = oMODIFICACION_INMUEBLE_ADEUDO;
        }

        public Int32 FindIndex_MODIFICACION_INMUEBLE_ADEUDOs(Int32 NID_PATRIMONIO_ADEUDO)
        {
            return  MODIFICACION_INMUEBLE_ADEUDOs.FindIndex(p =>
                               p.NID_PATRIMONIO_ADEUDO == NID_PATRIMONIO_ADEUDO
                                                   );
        }


        private void _Reload_MODIFICACION_INMUEBLE_TITULAs()
        {
            _MODIFICACION_INMUEBLE_TITULAs = new Lista<blld_MODIFICACION_INMUEBLE_TITULA>();
            foreach (MODELDeclara_V2.MODIFICACION_INMUEBLE_TITULA o in datos_MODIFICACION_INMUEBLE._MODIFICACION_INMUEBLE_TITULAs)
            {
                _MODIFICACION_INMUEBLE_TITULAs.Add(new blld_MODIFICACION_INMUEBLE_TITULA(o));
            }
        }

        private void _Add_MODIFICACION_INMUEBLE_TITULAs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_INMUEBLE_TITULA oMODIFICACION_INMUEBLE_TITULA = new blld_MODIFICACION_INMUEBLE_TITULA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_INMUEBLE_TITULA.lEsNuevoRegistro.Value) MODIFICACION_INMUEBLE_TITULAs.Add(oMODIFICACION_INMUEBLE_TITULA);
                _MODIFICACION_INMUEBLE_TITULAs[FindIndex_MODIFICACION_INMUEBLE_TITULAs(NID_DEPENDIENTE)] = oMODIFICACION_INMUEBLE_TITULA;
        }

        public Int32 FindIndex_MODIFICACION_INMUEBLE_TITULAs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_INMUEBLE_TITULAs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
