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
    public partial class blld_PATRIMONIO_TARJETA : bll_PATRIMONIO_TARJETA
    {

     #region *** Atributos ***


        //private Lista<blld_PATRIMONIO_TARJETA_TITU> _PATRIMONIO_TARJETA_TITUs;
        //public Lista<blld_PATRIMONIO_TARJETA_TITU> PATRIMONIO_TARJETA_TITUs
        //{
        //  get
        //  {
        //      if(_PATRIMONIO_TARJETA_TITUs == null)
        //      {
        //          _PATRIMONIO_TARJETA_TITUs = new Lista<blld_PATRIMONIO_TARJETA_TITU>();
        //          Reload_PATRIMONIO_TARJETA_TITUs();
        //      }
        //      return _PATRIMONIO_TARJETA_TITUs;
        //  }
        //}

        #region * CAT_INST_FINANCIERA *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N S T I T U C I O N es requerido ")]
        [DisplayName("I N S T I T U C I O N")]
        public String V_INSTITUCION => datos_PATRIMONIO_TARJETA.V_INSTITUCION;


        [Required(ErrorMessage = "El campo A C T I V O es requerido ")]
        [DisplayName("A C T I V O")]
        public Boolean L_ACTIVO => datos_PATRIMONIO_TARJETA.L_ACTIVO;

        #endregion * CAT_INST_FINANCIERA *



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO_TARJETA()
        : base()
        {
            //_PATRIMONIO_TARJETA_TITUs = null;
        }

        //public blld_PATRIMONIO_TARJETA(MODELDeclara_V2.PATRIMONIO_TARJETA PATRIMONIO_TARJETA)
        //: base(PATRIMONIO_TARJETA)
        //{
        //}

        public  blld_PATRIMONIO_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO)
        {
        }

        public blld_PATRIMONIO_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_SALDO, Boolean L_ACTIVA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_SALDO, L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        //private void _Reload_PATRIMONIO_TARJETA_TITUs()
        //{
        //    _PATRIMONIO_TARJETA_TITUs = new Lista<blld_PATRIMONIO_TARJETA_TITU>();
        //    foreach (MODELDeclara_V2.PATRIMONIO_TARJETA_TITU o in datos_PATRIMONIO_TARJETA._PATRIMONIO_TARJETA_TITUs)
        //    {
        //        _PATRIMONIO_TARJETA_TITUs.Add(new blld_PATRIMONIO_TARJETA_TITU(o));
        //    }
        //}

        //private void _Add_PATRIMONIO_TARJETA_TITUs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        //{
        //        blld_PATRIMONIO_TARJETA_TITU oPATRIMONIO_TARJETA_TITU = new blld_PATRIMONIO_TARJETA_TITU(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_DEPENDIENTE, L_DIF);
        //        if (oPATRIMONIO_TARJETA_TITU.lEsNuevoRegistro.Value) PATRIMONIO_TARJETA_TITUs.Add(oPATRIMONIO_TARJETA_TITU);
        //        _PATRIMONIO_TARJETA_TITUs[FindIndex_PATRIMONIO_TARJETA_TITUs(NID_DEPENDIENTE)] = oPATRIMONIO_TARJETA_TITU;
        //}

        //public Int32 FindIndex_PATRIMONIO_TARJETA_TITUs(Int32 NID_DEPENDIENTE)
        //{
        //    return  PATRIMONIO_TARJETA_TITUs.FindIndex(p =>
        //                       p.NID_DEPENDIENTE == NID_DEPENDIENTE
        //                                           );
        //}



     #endregion

    }
}
