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
    public partial class blld_MODIFICACION_BAJA : bll_MODIFICACION_BAJA
    {

     #region *** Atributos ***


        private blld_MODIFICACION_DONACION _MODIFICACION_DONACION { get; set; }
        public blld_MODIFICACION_DONACION MODIFICACION_DONACION
        {
            get
            {
                if (_MODIFICACION_DONACION == null)
                    _MODIFICACION_DONACION = new blld_MODIFICACION_DONACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                return _MODIFICACION_DONACION;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_DECLARACION != value.NID_DECLARACION &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _MODIFICACION_DONACION = value;
                }
            }
        }

        private blld_MODIFICACION_BAJA_SINIESTRO _MODIFICACION_BAJA_SINIESTRO { get; set; }
        public blld_MODIFICACION_BAJA_SINIESTRO MODIFICACION_BAJA_SINIESTRO
        {
            get
            {
                if (_MODIFICACION_BAJA_SINIESTRO == null)
                    _MODIFICACION_BAJA_SINIESTRO = new blld_MODIFICACION_BAJA_SINIESTRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                return _MODIFICACION_BAJA_SINIESTRO;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_DECLARACION != value.NID_DECLARACION &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _MODIFICACION_BAJA_SINIESTRO = value;
                }
            }
        }

        private blld_MODIFICACION_BAJA_VENTA _MODIFICACION_BAJA_VENTA { get; set; }
        public blld_MODIFICACION_BAJA_VENTA MODIFICACION_BAJA_VENTA
        {
            get
            {
                if (_MODIFICACION_BAJA_VENTA == null)
                    _MODIFICACION_BAJA_VENTA = new blld_MODIFICACION_BAJA_VENTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                return _MODIFICACION_BAJA_VENTA;
            }
            set
            {
                if (
                    this.VID_NOMBRE != value.VID_NOMBRE &&
                    this.VID_FECHA != value.VID_FECHA &&
                    this.VID_HOMOCLAVE != value.VID_HOMOCLAVE &&
                    this.NID_DECLARACION != value.NID_DECLARACION &&
                    this.NID_PATRIMONIO != value.NID_PATRIMONIO
                    )
                    throw new Exception("Las llaves no corresponden");
                else
                {
                    _MODIFICACION_BAJA_VENTA = value;
                }
            }
        }

        #region * CAT_TIPO_BAJA *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_BAJA => datos_MODIFICACION_BAJA.V_TIPO_BAJA;

        #endregion * CAT_TIPO_BAJA *



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_BAJA()
        : base()
        {
            _MODIFICACION_DONACION = null;
            _MODIFICACION_BAJA_SINIESTRO = null;
            _MODIFICACION_BAJA_VENTA = null;
        }

        public blld_MODIFICACION_BAJA(MODELDeclara_V2.MODIFICACION_BAJA MODIFICACION_BAJA)
        : base(MODIFICACION_BAJA)
        {
        }

        public  blld_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO)
        {
        }



     #endregion


     #region *** Metodos ***

        private void _Add_MODIFICACION_DONACION(String E_ESPECIFICA,String E_BENIFICIARIO)
        {
            this._MODIFICACION_DONACION = new blld_MODIFICACION_DONACION (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, E_ESPECIFICA, E_BENIFICIARIO) ;
        }
        private void _Add_MODIFICACION_BAJA_SINIESTRO(Boolean L_POLIZA, Decimal M_RECUPERADO)
        {
            this._MODIFICACION_BAJA_SINIESTRO = new blld_MODIFICACION_BAJA_SINIESTRO (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, L_POLIZA, M_RECUPERADO) ;
        }
        private void _Add_MODIFICACION_BAJA_VENTA(Int32 NID_TIPO_VENTA, Decimal M_IMPORTE_VENTA, String E_BENIFICIARIO)
        {
            this._MODIFICACION_BAJA_VENTA = new blld_MODIFICACION_BAJA_VENTA (VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_VENTA, M_IMPORTE_VENTA, E_BENIFICIARIO) ;
        }

     #endregion

    }
}
