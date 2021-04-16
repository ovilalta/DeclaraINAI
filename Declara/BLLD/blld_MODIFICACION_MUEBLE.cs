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
    public partial class blld_MODIFICACION_MUEBLE : bll_MODIFICACION_MUEBLE
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_MUEBLE_TITULAR> _MODIFICACION_MUEBLE_TITULARs;
        public Lista<blld_MODIFICACION_MUEBLE_TITULAR> MODIFICACION_MUEBLE_TITULARs
        {
          get
          {
              if(_MODIFICACION_MUEBLE_TITULARs == null)
              {
                  _MODIFICACION_MUEBLE_TITULARs = new Lista<blld_MODIFICACION_MUEBLE_TITULAR>();
                  Reload_MODIFICACION_MUEBLE_TITULARs();
              }
              return _MODIFICACION_MUEBLE_TITULARs;
          }
        }

        #region * CAT_TIPO_MUEBLE *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O es requerido ")]
        [DisplayName("T I P O")]
        public String V_TIPO => datos_MODIFICACION_MUEBLE.V_TIPO;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_MODIFICACION_MUEBLE.L_ACTIVO;

        #endregion * CAT_TIPO_MUEBLE *



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_MUEBLE()
        : base()
        {
            _MODIFICACION_MUEBLE_TITULARs = null;
        }

        public blld_MODIFICACION_MUEBLE(MODELDeclara_V2.MODIFICACION_MUEBLE MODIFICACION_MUEBLE)
        : base(MODIFICACION_MUEBLE)
        {
        }

        public  blld_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }

        public blld_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_MODIFICADO,DateTime F_ADQUISICION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR, L_MODIFICADO, F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_MUEBLE_TITULARs()
        {
            _MODIFICACION_MUEBLE_TITULARs = new Lista<blld_MODIFICACION_MUEBLE_TITULAR>();
            foreach (MODELDeclara_V2.MODIFICACION_MUEBLE_TITULAR o in datos_MODIFICACION_MUEBLE._MODIFICACION_MUEBLE_TITULARs)
            {
                _MODIFICACION_MUEBLE_TITULARs.Add(new blld_MODIFICACION_MUEBLE_TITULAR(o));
            }
        }

        private void _Add_MODIFICACION_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_MUEBLE_TITULAR oMODIFICACION_MUEBLE_TITULAR = new blld_MODIFICACION_MUEBLE_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_MUEBLE_TITULAR.lEsNuevoRegistro.Value) MODIFICACION_MUEBLE_TITULARs.Add(oMODIFICACION_MUEBLE_TITULAR);
                _MODIFICACION_MUEBLE_TITULARs[FindIndex_MODIFICACION_MUEBLE_TITULARs(NID_DEPENDIENTE)] = oMODIFICACION_MUEBLE_TITULAR;
        }

        public Int32 FindIndex_MODIFICACION_MUEBLE_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_MUEBLE_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
