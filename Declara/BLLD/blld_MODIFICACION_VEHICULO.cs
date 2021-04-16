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
    public partial class blld_MODIFICACION_VEHICULO : bll_MODIFICACION_VEHICULO
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_VEHICULO_ADEU> _MODIFICACION_VEHICULO_ADEUs;
        public Lista<blld_MODIFICACION_VEHICULO_ADEU> MODIFICACION_VEHICULO_ADEUs
        {
          get
          {
              if(_MODIFICACION_VEHICULO_ADEUs == null)
              {
                  _MODIFICACION_VEHICULO_ADEUs = new Lista<blld_MODIFICACION_VEHICULO_ADEU>();
                  Reload_MODIFICACION_VEHICULO_ADEUs();
              }
              return _MODIFICACION_VEHICULO_ADEUs;
          }
        }

        private Lista<blld_MODIFICACION_VEHICULO_TITU> _MODIFICACION_VEHICULO_TITUs;
        public Lista<blld_MODIFICACION_VEHICULO_TITU> MODIFICACION_VEHICULO_TITUs
        {
          get
          {
              if(_MODIFICACION_VEHICULO_TITUs == null)
              {
                  _MODIFICACION_VEHICULO_TITUs = new Lista<blld_MODIFICACION_VEHICULO_TITU>();
                  Reload_MODIFICACION_VEHICULO_TITUs();
              }
              return _MODIFICACION_VEHICULO_TITUs;
          }
        }

        #region * CAT_MARCA_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M A R C A es requerido ")]
        [DisplayName("M A R C A")]
        public String V_MARCA => datos_MODIFICACION_VEHICULO.V_MARCA;

        #endregion * CAT_MARCA_VEHICULO *


        #region * CAT_USO_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo U S O es requerido ")]
        [DisplayName("U S O")]
        public String V_USO => datos_MODIFICACION_VEHICULO.V_USO;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_MODIFICACION_VEHICULO.L_ACTIVO;

        #endregion * CAT_USO_VEHICULO *



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_VEHICULO()
        : base()
        {
            _MODIFICACION_VEHICULO_ADEUs = null;
            _MODIFICACION_VEHICULO_TITUs = null;
        }

        public blld_MODIFICACION_VEHICULO(MODELDeclara_V2.MODIFICACION_VEHICULO MODIFICACION_VEHICULO)
        : base(MODIFICACION_VEHICULO)
        {
        }

        public  blld_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        public blld_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Boolean L_MODIFICADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void Reload_MODIFICACION_VEHICULO_ADEUs()
        {
            _MODIFICACION_VEHICULO_ADEUs = new Lista<blld_MODIFICACION_VEHICULO_ADEU>();
            foreach (MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU o in datos_MODIFICACION_VEHICULO._MODIFICACION_VEHICULO_ADEUs)
            {
                _MODIFICACION_VEHICULO_ADEUs.Add(new blld_MODIFICACION_VEHICULO_ADEU(o));
            }
        }

        private void _Add_MODIFICACION_VEHICULO_ADEUs(Int32 NID_PATRIMONIO_ADEUDO)
        {
                blld_MODIFICACION_VEHICULO_ADEU oMODIFICACION_VEHICULO_ADEU = new blld_MODIFICACION_VEHICULO_ADEU(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO);
                if (oMODIFICACION_VEHICULO_ADEU.lEsNuevoRegistro.Value) MODIFICACION_VEHICULO_ADEUs.Add(oMODIFICACION_VEHICULO_ADEU);
                _MODIFICACION_VEHICULO_ADEUs[FindIndex_MODIFICACION_VEHICULO_ADEUs(NID_PATRIMONIO_ADEUDO)] = oMODIFICACION_VEHICULO_ADEU;
        }

        public Int32 FindIndex_MODIFICACION_VEHICULO_ADEUs(Int32 NID_PATRIMONIO_ADEUDO)
        {
            return  MODIFICACION_VEHICULO_ADEUs.FindIndex(p =>
                               p.NID_PATRIMONIO_ADEUDO == NID_PATRIMONIO_ADEUDO
                                                   );
        }


        private void _Reload_MODIFICACION_VEHICULO_TITUs()
        {
            _MODIFICACION_VEHICULO_TITUs = new Lista<blld_MODIFICACION_VEHICULO_TITU>();
            foreach (MODELDeclara_V2.MODIFICACION_VEHICULO_TITU o in datos_MODIFICACION_VEHICULO._MODIFICACION_VEHICULO_TITUs)
            {
                _MODIFICACION_VEHICULO_TITUs.Add(new blld_MODIFICACION_VEHICULO_TITU(o));
            }
        }

        private void _Add_MODIFICACION_VEHICULO_TITUs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_VEHICULO_TITU oMODIFICACION_VEHICULO_TITU = new blld_MODIFICACION_VEHICULO_TITU(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_VEHICULO_TITU.lEsNuevoRegistro.Value) MODIFICACION_VEHICULO_TITUs.Add(oMODIFICACION_VEHICULO_TITU);
                _MODIFICACION_VEHICULO_TITUs[FindIndex_MODIFICACION_VEHICULO_TITUs(NID_DEPENDIENTE)] = oMODIFICACION_VEHICULO_TITU;
        }

        public Int32 FindIndex_MODIFICACION_VEHICULO_TITUs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_VEHICULO_TITUs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
