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
    public partial class blld_ALTA_VEHICULO : bll_ALTA_VEHICULO
    {

     #region *** Atributos ***


        private blld_ALTA_VEHICULO_ADEUDO _ALTA_VEHICULO_ADEUDO { get; set; }
        public blld_ALTA_VEHICULO_ADEUDO ALTA_VEHICULO_ADEUDO
        {
            get
            {
                if (_ALTA_VEHICULO_ADEUDO == null)
                    _ALTA_VEHICULO_ADEUDO = new blld_ALTA_VEHICULO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);
                return _ALTA_VEHICULO_ADEUDO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_DECLARACION != value.NID_DECLARACION &&
                    this.NID_VEHICULO != value.NID_VEHICULO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _ALTA_VEHICULO_ADEUDO = value;
                }
            }
        }

        private Lista<blld_ALTA_VEHICULO_TITULAR> _ALTA_VEHICULO_TITULARs;
        public Lista<blld_ALTA_VEHICULO_TITULAR> ALTA_VEHICULO_TITULARs
        {
          get
          {
              if(_ALTA_VEHICULO_TITULARs == null)
              {
                  _ALTA_VEHICULO_TITULARs = new Lista<blld_ALTA_VEHICULO_TITULAR>();
                  Reload_ALTA_VEHICULO_TITULARs();
              }
              return _ALTA_VEHICULO_TITULARs;
          }
        }

        #region * CAT_MARCA_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M A R C A es requerido ")]
        [DisplayName("M A R C A")]
        public String V_MARCA => datos_ALTA_VEHICULO.V_MARCA;

        #endregion * CAT_MARCA_VEHICULO *



        #region * CAT_USO_VEHICULO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo U S O es requerido ")]
        [DisplayName("U S O")]
        public String V_USO => datos_ALTA_VEHICULO.V_USO;



        #endregion * CAT_USO_VEHICULO *



     #endregion


     #region *** Constructores ***

        private blld_ALTA_VEHICULO()
        : base()
        {
            _ALTA_VEHICULO_ADEUDO = null;
            _ALTA_VEHICULO_TITULARs = null;
        }

        public blld_ALTA_VEHICULO(MODELDeclara_V2.ALTA_VEHICULO ALTA_VEHICULO)
        : base(ALTA_VEHICULO)
        {
        }

        public  blld_ALTA_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO)
        {
        }

        public blld_ALTA_VEHICULO(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_VEHICULO
                                , Int32 NID_MARCA
                                , String C_MODELO
                                , String V_DESCRIPCION
                                , DateTime F_ADQUISICION
                                , Int32 NID_TIPO_COMPRA
                                , Int32 NID_USO
                                , Decimal M_VALOR_VEHICULO
                                , Int32 NID_PATRIMONIO
                                , Int32 NID_PAIS
                                , String CID_ENTIDAD_FEDERATIVA
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , String E_NUMERO_SERIE
                                , Int32 NID_FORMA_ADQUISICION
                                , Int32 NID_FORMA_PAGO
                                , String E_OBSERVACIONES
                                )
        : base(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_VEHICULO
                , NID_MARCA
                , C_MODELO
                , V_DESCRIPCION
                , F_ADQUISICION
                , NID_TIPO_COMPRA
                , NID_USO
                , M_VALOR_VEHICULO
                , NID_PATRIMONIO
                , NID_PAIS
                , CID_ENTIDAD_FEDERATIVA
                , CID_TIPO_PERSONA_TRANSMISOR
                , E_NOMBRE_TRANSMISOR
                , E_RFC_TRANSMISOR
                , NID_RELACION_TRANSMISOR
                , V_TIPO_MONEDA
                , E_NUMERO_SERIE
                , NID_FORMA_ADQUISICION
                , NID_FORMA_PAGO
                , E_OBSERVACIONES
                , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException
                )
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Add_ALTA_VEHICULO_ADEUDO(Int32 NID_ADEUDO)
        {
            this._ALTA_VEHICULO_ADEUDO = new blld_ALTA_VEHICULO_ADEUDO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_ADEUDO) ;
        }
        private void _Reload_ALTA_VEHICULO_TITULARs()
        {
            _ALTA_VEHICULO_TITULARs = new Lista<blld_ALTA_VEHICULO_TITULAR>();
            foreach (MODELDeclara_V2.ALTA_VEHICULO_TITULAR o in datos_ALTA_VEHICULO._ALTA_VEHICULO_TITULARs)
            {
                _ALTA_VEHICULO_TITULARs.Add(new blld_ALTA_VEHICULO_TITULAR(o));
            }
        }

        private void _Add_ALTA_VEHICULO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_ALTA_VEHICULO_TITULAR oALTA_VEHICULO_TITULAR = new blld_ALTA_VEHICULO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_DEPENDIENTE, L_DIF);
                if (oALTA_VEHICULO_TITULAR.lEsNuevoRegistro.Value) ALTA_VEHICULO_TITULARs.Add(oALTA_VEHICULO_TITULAR);
                _ALTA_VEHICULO_TITULARs[FindIndex_ALTA_VEHICULO_TITULARs(NID_DEPENDIENTE)] = oALTA_VEHICULO_TITULAR;
        }

        public Int32 FindIndex_ALTA_VEHICULO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  ALTA_VEHICULO_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
