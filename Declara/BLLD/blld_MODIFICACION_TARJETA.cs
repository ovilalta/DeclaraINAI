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
    public partial class blld_MODIFICACION_TARJETA : bll_MODIFICACION_TARJETA
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_TARJETA_TITU> _MODIFICACION_TARJETA_TITUs;
        public Lista<blld_MODIFICACION_TARJETA_TITU> MODIFICACION_TARJETA_TITUs
        {
          get
          {
              if(_MODIFICACION_TARJETA_TITUs == null)
              {
                  _MODIFICACION_TARJETA_TITUs = new Lista<blld_MODIFICACION_TARJETA_TITU>();
                  Reload_MODIFICACION_TARJETA_TITUs();
              }
              return _MODIFICACION_TARJETA_TITUs;
          }
        }

        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N S T I T U C I O N es requerido ")]
        [DisplayName("I N S T I T U C I O N")]
        public String V_INSTITUCION => datos_MODIFICACION_TARJETA.V_INSTITUCION;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_MODIFICACION_TARJETA.L_ACTIVO;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_TARJETA()
        : base()
        {
            _MODIFICACION_TARJETA_TITUs = null;
        }

        public blld_MODIFICACION_TARJETA(MODELDeclara_V2.MODIFICACION_TARJETA MODIFICACION_TARJETA)
        : base(MODIFICACION_TARJETA)
        {
        }

        public  blld_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO)
        {
        }

        //public blld_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_SALDO, String E_NUMERO_ASOCIACION, Boolean L_ACTIVA)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_SALDO, E_NUMERO_ASOCIACION, L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_TARJETA_TITUs()
        {
            _MODIFICACION_TARJETA_TITUs = new Lista<blld_MODIFICACION_TARJETA_TITU>();
            foreach (MODELDeclara_V2.MODIFICACION_TARJETA_TITU o in datos_MODIFICACION_TARJETA._MODIFICACION_TARJETA_TITUs)
            {
                _MODIFICACION_TARJETA_TITUs.Add(new blld_MODIFICACION_TARJETA_TITU(o));
            }
        }

        private void _Add_MODIFICACION_TARJETA_TITUs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_MODIFICACION_TARJETA_TITU oMODIFICACION_TARJETA_TITU = new blld_MODIFICACION_TARJETA_TITU(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO.StartsWith("|") ? E_NUMERO: Encripta(E_NUMERO), NID_DEPENDIENTE, L_DIF);
                if (oMODIFICACION_TARJETA_TITU.lEsNuevoRegistro.Value) MODIFICACION_TARJETA_TITUs.Add(oMODIFICACION_TARJETA_TITU);
                _MODIFICACION_TARJETA_TITUs[FindIndex_MODIFICACION_TARJETA_TITUs(NID_DEPENDIENTE)] = oMODIFICACION_TARJETA_TITU;
        }

        public Int32 FindIndex_MODIFICACION_TARJETA_TITUs(Int32 NID_DEPENDIENTE)
        {
            return  MODIFICACION_TARJETA_TITUs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
