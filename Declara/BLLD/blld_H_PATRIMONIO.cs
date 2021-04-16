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
    public partial class blld_H_PATRIMONIO : bll_H_PATRIMONIO
    {

     #region *** Atributos ***


        private blld_H_PATRIMONIO_VEHICULO _H_PATRIMONIO_VEHICULO { get; set; }
        public blld_H_PATRIMONIO_VEHICULO H_PATRIMONIO_VEHICULO
        {
            get
            {
                if (_H_PATRIMONIO_VEHICULO == null)
                    _H_PATRIMONIO_VEHICULO = new blld_H_PATRIMONIO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                return _H_PATRIMONIO_VEHICULO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO &&
                    this.NID_HISTORICO != value.NID_HISTORICO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _H_PATRIMONIO_VEHICULO = value;
                }
            }
        }

        private blld_H_PATRIMONIO_ADEUDO _H_PATRIMONIO_ADEUDO { get; set; }
        public blld_H_PATRIMONIO_ADEUDO H_PATRIMONIO_ADEUDO
        {
            get
            {
                if (_H_PATRIMONIO_ADEUDO == null)
                    _H_PATRIMONIO_ADEUDO = new blld_H_PATRIMONIO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                return _H_PATRIMONIO_ADEUDO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO &&
                    this.NID_HISTORICO != value.NID_HISTORICO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _H_PATRIMONIO_ADEUDO = value;
                }
            }
        }

        private Lista<blld_H_PATRIMONIO_TITULAR> _H_PATRIMONIO_TITULARs;
        public Lista<blld_H_PATRIMONIO_TITULAR> H_PATRIMONIO_TITULARs
        {
          get
          {
              if(_H_PATRIMONIO_TITULARs == null)
              {
                  _H_PATRIMONIO_TITULARs = new Lista<blld_H_PATRIMONIO_TITULAR>();
                  Reload_H_PATRIMONIO_TITULARs();
              }
              return _H_PATRIMONIO_TITULARs;
          }
        }

        private blld_H_PATRIMONIO_MUEBLE _H_PATRIMONIO_MUEBLE { get; set; }
        public blld_H_PATRIMONIO_MUEBLE H_PATRIMONIO_MUEBLE
        {
            get
            {
                if (_H_PATRIMONIO_MUEBLE == null)
                    _H_PATRIMONIO_MUEBLE = new blld_H_PATRIMONIO_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                return _H_PATRIMONIO_MUEBLE;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO &&
                    this.NID_HISTORICO != value.NID_HISTORICO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _H_PATRIMONIO_MUEBLE = value;
                }
            }
        }

        private blld_H_PATRIMONIO_INMUEBLE _H_PATRIMONIO_INMUEBLE { get; set; }
        public blld_H_PATRIMONIO_INMUEBLE H_PATRIMONIO_INMUEBLE
        {
            get
            {
                if (_H_PATRIMONIO_INMUEBLE == null)
                    _H_PATRIMONIO_INMUEBLE = new blld_H_PATRIMONIO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                return _H_PATRIMONIO_INMUEBLE;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO &&
                    this.NID_HISTORICO != value.NID_HISTORICO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _H_PATRIMONIO_INMUEBLE = value;
                }
            }
        }

        private blld_H_PATRIMONIO_INVERSION _H_PATRIMONIO_INVERSION { get; set; }
        public blld_H_PATRIMONIO_INVERSION H_PATRIMONIO_INVERSION
        {
            get
            {
                if (_H_PATRIMONIO_INVERSION == null)
                    _H_PATRIMONIO_INVERSION = new blld_H_PATRIMONIO_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                return _H_PATRIMONIO_INVERSION;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO &&
                    this.NID_HISTORICO != value.NID_HISTORICO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _H_PATRIMONIO_INVERSION = value;
                }
            }
        }

        #region * CAT_TIPO_PATRIMONIO *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO => datos_H_PATRIMONIO.V_TIPO;


        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 C_NATURALEZA => datos_H_PATRIMONIO.C_NATURALEZA;

        #endregion * CAT_TIPO_PATRIMONIO *



     #endregion


     #region *** Constructores ***

        private blld_H_PATRIMONIO()
        : base()
        {
            _H_PATRIMONIO_VEHICULO = null;
            _H_PATRIMONIO_ADEUDO = null;
            _H_PATRIMONIO_TITULARs = null;
            _H_PATRIMONIO_MUEBLE = null;
            _H_PATRIMONIO_INMUEBLE = null;
            _H_PATRIMONIO_INVERSION = null;
        }

        public blld_H_PATRIMONIO(MODELDeclara_V2.H_PATRIMONIO H_PATRIMONIO)
        : base(H_PATRIMONIO)
        {
        }

        public  blld_H_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO)
        {
        }

        public blld_H_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Add_H_PATRIMONIO_VEHICULO(Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO)
        {
            this._H_PATRIMONIO_VEHICULO = new blld_H_PATRIMONIO_VEHICULO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO) ;
        }
        private void _Add_H_PATRIMONIO_ADEUDO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_INSTITUCION, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA)
        {
            this._H_PATRIMONIO_ADEUDO = new blld_H_PATRIMONIO_ADEUDO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_INSTITUCION, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA) ;
        }
        private void _Reload_H_PATRIMONIO_TITULARs()
        {
            _H_PATRIMONIO_TITULARs = new Lista<blld_H_PATRIMONIO_TITULAR>();
            foreach (MODELDeclara_V2.H_PATRIMONIO_TITULAR o in datos_H_PATRIMONIO._H_PATRIMONIO_TITULARs)
            {
                _H_PATRIMONIO_TITULARs.Add(new blld_H_PATRIMONIO_TITULAR(o));
            }
        }

        private void _Add_H_PATRIMONIO_TITULARs(Int32 NID_DEPENDIENTE, Boolean L_DIF)
        {
                blld_H_PATRIMONIO_TITULAR oH_PATRIMONIO_TITULAR = new blld_H_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO, L_DIF);
                if (oH_PATRIMONIO_TITULAR.lEsNuevoRegistro.Value) H_PATRIMONIO_TITULARs.Add(oH_PATRIMONIO_TITULAR);
                _H_PATRIMONIO_TITULARs[FindIndex_H_PATRIMONIO_TITULARs(NID_DEPENDIENTE)] = oH_PATRIMONIO_TITULAR;
        }

        public Int32 FindIndex_H_PATRIMONIO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            return  H_PATRIMONIO_TITULARs.FindIndex(p =>
                               p.NID_DEPENDIENTE == NID_DEPENDIENTE
                                                   );
        }


        private void _Add_H_PATRIMONIO_MUEBLE(Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR)
        {
            this._H_PATRIMONIO_MUEBLE = new blld_H_PATRIMONIO_MUEBLE (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, E_ESPECIFICACION, M_VALOR) ;
        }
        private void _Add_H_PATRIMONIO_INMUEBLE(Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        {
            this._H_PATRIMONIO_INMUEBLE = new blld_H_PATRIMONIO_INMUEBLE (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE) ;
        }
        private void _Add_H_PATRIMONIO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR)
        {
            this._H_PATRIMONIO_INVERSION = new blld_H_PATRIMONIO_INVERSION (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR) ;
        }

     #endregion

    }
}
