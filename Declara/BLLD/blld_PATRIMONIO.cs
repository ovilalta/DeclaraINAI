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
    public partial class blld_PATRIMONIO : bll_PATRIMONIO
    {

     #region *** Atributos ***


        private blld_PATRIMONIO_INMUEBLE _PATRIMONIO_INMUEBLE { get; set; }
        public blld_PATRIMONIO_INMUEBLE PATRIMONIO_INMUEBLE
        {
            get
            {
                if (_PATRIMONIO_INMUEBLE == null)
                    _PATRIMONIO_INMUEBLE = new blld_PATRIMONIO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO_INMUEBLE;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _PATRIMONIO_INMUEBLE = value;
                }
            }
        }

        private blld_PATRIMONIO_INVERSION _PATRIMONIO_INVERSION { get; set; }
        public blld_PATRIMONIO_INVERSION PATRIMONIO_INVERSION
        {
            get
            {
                if (_PATRIMONIO_INVERSION == null)
                    _PATRIMONIO_INVERSION = new blld_PATRIMONIO_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO_INVERSION;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _PATRIMONIO_INVERSION = value;
                }
            }
        }

        private blld_PATRIMONIO_MUEBLE _PATRIMONIO_MUEBLE { get; set; }
        public blld_PATRIMONIO_MUEBLE PATRIMONIO_MUEBLE
        {
            get
            {
                if (_PATRIMONIO_MUEBLE == null)
                    _PATRIMONIO_MUEBLE = new blld_PATRIMONIO_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO_MUEBLE;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _PATRIMONIO_MUEBLE = value;
                }
            }
        }

        private blld_PATRIMONIO_VEHICULO _PATRIMONIO_VEHICULO { get; set; }
        public blld_PATRIMONIO_VEHICULO PATRIMONIO_VEHICULO
        {
            get
            {
                if (_PATRIMONIO_VEHICULO == null)
                    _PATRIMONIO_VEHICULO = new blld_PATRIMONIO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO_VEHICULO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _PATRIMONIO_VEHICULO = value;
                }
            }
        }

        private blld_PATRIMONIO_ADEUDO _PATRIMONIO_ADEUDO { get; set; }
        public blld_PATRIMONIO_ADEUDO PATRIMONIO_ADEUDO
        {
            get
            {
                if (_PATRIMONIO_ADEUDO == null)
                    _PATRIMONIO_ADEUDO = new blld_PATRIMONIO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);
                return _PATRIMONIO_ADEUDO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _PATRIMONIO_ADEUDO = value;
                }
            }
        }

        private Lista<blld_H_PATRIMONIO> _H_PATRIMONIOs;
        public Lista<blld_H_PATRIMONIO> H_PATRIMONIOs
        {
          get
          {
              if(_H_PATRIMONIOs == null)
              {
                  _H_PATRIMONIOs = new Lista<blld_H_PATRIMONIO>();
                  Reload_H_PATRIMONIOs();
              }
              return _H_PATRIMONIOs;
          }
        }

        private Lista<blld_PATRIMONIO_TITULAR> _PATRIMONIO_TITULARs;
        public Lista<blld_PATRIMONIO_TITULAR> PATRIMONIO_TITULARs
        {
          get
          {
              if(_PATRIMONIO_TITULARs == null)
              {
                  _PATRIMONIO_TITULARs = new Lista<blld_PATRIMONIO_TITULAR>();
                  Reload_PATRIMONIO_TITULARs();
              }
              return _PATRIMONIO_TITULARs;
          }
        }

        #region * CAT_TIPO_PATRIMONIO *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO => datos_PATRIMONIO.V_TIPO;


        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 C_NATURALEZA => datos_PATRIMONIO.C_NATURALEZA;

        #endregion * CAT_TIPO_PATRIMONIO *



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO()
        : base()
        {
            _PATRIMONIO_INMUEBLE = null;
            _PATRIMONIO_INVERSION = null;
            _PATRIMONIO_MUEBLE = null;
            _PATRIMONIO_VEHICULO = null;
            _PATRIMONIO_ADEUDO = null;
            _H_PATRIMONIOs = null;
            _PATRIMONIO_TITULARs = null;
        }

        public blld_PATRIMONIO(MODELDeclara_V2.PATRIMONIO PATRIMONIO)
        : base(PATRIMONIO)
        {
        }

        public  blld_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO)
        {
        }

        public blld_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Add_PATRIMONIO_INMUEBLE(Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        {
            this._PATRIMONIO_INMUEBLE = new blld_PATRIMONIO_INMUEBLE (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE) ;
        }
        private void _Add_PATRIMONIO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR)
        {
            this._PATRIMONIO_INVERSION = new blld_PATRIMONIO_INVERSION (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR) ;
        }
        //private void _Add_PATRIMONIO_MUEBLE(Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR)
        //{
        //    this._PATRIMONIO_MUEBLE = new blld_PATRIMONIO_MUEBLE (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR) ;
        //}
        private void _Add_PATRIMONIO_VEHICULO(Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO)
        {
            this._PATRIMONIO_VEHICULO = new blld_PATRIMONIO_VEHICULO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO) ;
        }
        private void _Add_PATRIMONIO_ADEUDO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA,String V_LUGAR, Int32 NID_INSTITUCION,String V_OTRA, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA)
        {
            this._PATRIMONIO_ADEUDO = new blld_PATRIMONIO_ADEUDO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA,V_LUGAR, NID_INSTITUCION,V_OTRA, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA) ;
        }
        private void _Reload_H_PATRIMONIOs()
        {
            _H_PATRIMONIOs = new Lista<blld_H_PATRIMONIO>();
            foreach (MODELDeclara_V2.H_PATRIMONIO o in datos_PATRIMONIO._H_PATRIMONIOs)
            {
                _H_PATRIMONIOs.Add(new blld_H_PATRIMONIO(o));
            }
        }

        private void _Add_H_PATRIMONIOs(Int32 NID_HISTORICO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, DateTime F_REGISTRO)
        {
                blld_H_PATRIMONIO oH_PATRIMONIO = new blld_H_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO);
                if (oH_PATRIMONIO.lEsNuevoRegistro.Value) H_PATRIMONIOs.Add(oH_PATRIMONIO);
                _H_PATRIMONIOs[FindIndex_H_PATRIMONIOs(NID_HISTORICO)] = oH_PATRIMONIO;
        }

        public Int32 FindIndex_H_PATRIMONIOs(Int32 NID_HISTORICO)
        {
            return  H_PATRIMONIOs.FindIndex(p =>
                               p.NID_HISTORICO == NID_HISTORICO
                                                   );
        }


        private void _Reload_PATRIMONIO_TITULARs()
        {
            _PATRIMONIO_TITULARs = new Lista<blld_PATRIMONIO_TITULAR>();
            foreach (MODELDeclara_V2.PATRIMONIO_TITULAR o in datos_PATRIMONIO._PATRIMONIO_TITULARs)
            {
                _PATRIMONIO_TITULARs.Add(new blld_PATRIMONIO_TITULAR(o));
            }
        }

        private void _Add_PATRIMONIO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_PATRIMONIO_TITULAR oPATRIMONIO_TITULAR = new blld_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF);
                if (oPATRIMONIO_TITULAR.lEsNuevoRegistro.Value) PATRIMONIO_TITULARs.Add(oPATRIMONIO_TITULAR);
                _PATRIMONIO_TITULARs[FindIndex_PATRIMONIO_TITULARs(NID_DEPENDIENTE)] = oPATRIMONIO_TITULAR;
        }

        public Int32 FindIndex_PATRIMONIO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  PATRIMONIO_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }



     #endregion

    }
}
