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
    public partial class blld_MODIFICACION : bll_MODIFICACION
    {

     #region *** Atributos ***


        private Lista<blld_MODIFICACION_INVERSION> _MODIFICACION_INVERSIONs;
        public Lista<blld_MODIFICACION_INVERSION> MODIFICACION_INVERSIONs
        {
          get
          {
              if(_MODIFICACION_INVERSIONs == null)
              {
                  _MODIFICACION_INVERSIONs = new Lista<blld_MODIFICACION_INVERSION>();
                  Reload_MODIFICACION_INVERSIONs();
              }
              return _MODIFICACION_INVERSIONs;
          }
        }

        private Lista<blld_MODIFICACION_TARJETA> _MODIFICACION_TARJETAs;
        public Lista<blld_MODIFICACION_TARJETA> MODIFICACION_TARJETAs
        {
          get
          {
              if(_MODIFICACION_TARJETAs == null)
              {
                  _MODIFICACION_TARJETAs = new Lista<blld_MODIFICACION_TARJETA>();
                  Reload_MODIFICACION_TARJETAs();
              }
              return _MODIFICACION_TARJETAs;
          }
        }

        private Lista<blld_MODIFICACION_ADEUDO> _MODIFICACION_ADEUDOs;
        public Lista<blld_MODIFICACION_ADEUDO> MODIFICACION_ADEUDOs
        {
          get
          {
              if(_MODIFICACION_ADEUDOs == null)
              {
                  _MODIFICACION_ADEUDOs = new Lista<blld_MODIFICACION_ADEUDO>();
                  Reload_MODIFICACION_ADEUDOs();
              }
              return _MODIFICACION_ADEUDOs;
          }
        }

        private Lista<blld_MODIFICACION_VEHICULO> _MODIFICACION_VEHICULOs;
        public Lista<blld_MODIFICACION_VEHICULO> MODIFICACION_VEHICULOs
        {
          get
          {
              if(_MODIFICACION_VEHICULOs == null)
              {
                  _MODIFICACION_VEHICULOs = new Lista<blld_MODIFICACION_VEHICULO>();
                  Reload_MODIFICACION_VEHICULOs();
              }
              return _MODIFICACION_VEHICULOs;
          }
        }

        private Lista<blld_MODIFICACION_INMUEBLE> _MODIFICACION_INMUEBLEs;
        public Lista<blld_MODIFICACION_INMUEBLE> MODIFICACION_INMUEBLEs
        {
          get
          {
              if(_MODIFICACION_INMUEBLEs == null)
              {
                  _MODIFICACION_INMUEBLEs = new Lista<blld_MODIFICACION_INMUEBLE>();
                  Reload_MODIFICACION_INMUEBLEs();
              }
              return _MODIFICACION_INMUEBLEs;
          }
        }

        private Lista<blld_MODIFICACION_MUEBLE> _MODIFICACION_MUEBLEs;
        public Lista<blld_MODIFICACION_MUEBLE> MODIFICACION_MUEBLEs
        {
          get
          {
              if(_MODIFICACION_MUEBLEs == null)
              {
                  _MODIFICACION_MUEBLEs = new Lista<blld_MODIFICACION_MUEBLE>();
                  Reload_MODIFICACION_MUEBLEs();
              }
              return _MODIFICACION_MUEBLEs;
          }
        }

        private Lista<blld_MODIFICACION_GASTO> _MODIFICACION_GASTOs;
        public Lista<blld_MODIFICACION_GASTO> MODIFICACION_GASTOs
        {
          get
          {
              if(_MODIFICACION_GASTOs == null)
              {
                  _MODIFICACION_GASTOs = new Lista<blld_MODIFICACION_GASTO>();
                  Reload_MODIFICACION_GASTOs();
              }
              return _MODIFICACION_GASTOs;
          }
        }

        private Lista<blld_MODIFICACION_BAJA> _MODIFICACION_BAJAs;
        public Lista<blld_MODIFICACION_BAJA> MODIFICACION_BAJAs
        {
          get
          {
              if(_MODIFICACION_BAJAs == null)
              {
                  _MODIFICACION_BAJAs = new Lista<blld_MODIFICACION_BAJA>();
                  Reload_MODIFICACION_BAJAs();
              }
              return _MODIFICACION_BAJAs;
          }
        }

        private Lista<blld_MODIFICACION_INGRESOS> _MODIFICACION_INGRESOSs;
        public Lista<blld_MODIFICACION_INGRESOS> MODIFICACION_INGRESOSs
        {
          get
          {
              if(_MODIFICACION_INGRESOSs == null)
              {
                  _MODIFICACION_INGRESOSs = new Lista<blld_MODIFICACION_INGRESOS>();
                  Reload_MODIFICACION_INGRESOSs();
              }
              return _MODIFICACION_INGRESOSs;
          }
        }




        #endregion


        #region *** Constructores ***

        private blld_MODIFICACION()
        : base()
        {
            _MODIFICACION_INVERSIONs = null;
            _MODIFICACION_TARJETAs = null;
            _MODIFICACION_ADEUDOs = null;
            _MODIFICACION_VEHICULOs = null;
            _MODIFICACION_INMUEBLEs = null;
            _MODIFICACION_MUEBLEs = null;
            _MODIFICACION_GASTOs = null;
            _MODIFICACION_BAJAs = null;
            _MODIFICACION_INGRESOSs = null;
        }

        public blld_MODIFICACION(MODELDeclara_V2.MODIFICACION MODIFICACION)
        : base(MODIFICACION)
        {
        }

        public  blld_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }

        public blld_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, System.Nullable<Boolean> L_PRESENTO_DEC)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, L_PRESENTO_DEC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_MODIFICACION_INVERSIONs()
        {
            _MODIFICACION_INVERSIONs = new Lista<blld_MODIFICACION_INVERSION>();
            foreach (MODELDeclara_V2.MODIFICACION_INVERSION o in datos_MODIFICACION._MODIFICACION_INVERSIONs)
            {
                _MODIFICACION_INVERSIONs.Add(new blld_MODIFICACION_INVERSION(o));
            }
        }

        //private void _Add_MODIFICACION_INVERSIONs(Int32 NID_PATRIMONIO, Decimal M_DEPOSITOS, Decimal M_RETIROS, Boolean L_CANCELADA)
        //{
        //        blld_MODIFICACION_INVERSION oMODIFICACION_INVERSION = new blld_MODIFICACION_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_DEPOSITOS, M_RETIROS, L_CANCELADA);
        //        if (oMODIFICACION_INVERSION.lEsNuevoRegistro.Value) MODIFICACION_INVERSIONs.Add(oMODIFICACION_INVERSION);
        //        _MODIFICACION_INVERSIONs[FindIndex_MODIFICACION_INVERSIONs(NID_PATRIMONIO)] = oMODIFICACION_INVERSION;
        //}

        public Int32 FindIndex_MODIFICACION_INVERSIONs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_INVERSIONs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_TARJETAs()
        {
            _MODIFICACION_TARJETAs = new Lista<blld_MODIFICACION_TARJETA>();
            foreach (MODELDeclara_V2.MODIFICACION_TARJETA o in datos_MODIFICACION._MODIFICACION_TARJETAs)
            {
                _MODIFICACION_TARJETAs.Add(new blld_MODIFICACION_TARJETA(o));
            }
        }

        private void _Add_MODIFICACION_TARJETAs(String E_NUMERO,Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_GASTOS, Boolean L_ACTIVA, List<Int32> ListDependientes)
        {
                blld_MODIFICACION_TARJETA oMODIFICACION_TARJETA = new blld_MODIFICACION_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO,NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_GASTOS, L_ACTIVA, ListDependientes);
                if (oMODIFICACION_TARJETA.lEsNuevoRegistro.Value) MODIFICACION_TARJETAs.Add(oMODIFICACION_TARJETA);
                _MODIFICACION_TARJETAs[FindIndex_MODIFICACION_TARJETAs(E_NUMERO)] = oMODIFICACION_TARJETA;
        }

        public Int32 FindIndex_MODIFICACION_TARJETAs(String E_NUMERO)
        {
            return  MODIFICACION_TARJETAs.FindIndex(p =>
                               p.E_NUMERO == E_NUMERO
                                                   );
        }


        private void _Reload_MODIFICACION_ADEUDOs()
        {
            _MODIFICACION_ADEUDOs = new Lista<blld_MODIFICACION_ADEUDO>();
            foreach (MODELDeclara_V2.MODIFICACION_ADEUDO o in datos_MODIFICACION._MODIFICACION_ADEUDOs)
            {
                _MODIFICACION_ADEUDOs.Add(new blld_MODIFICACION_ADEUDO(o));
            }
        }

        //private void _Add_MODIFICACION_ADEUDOs(Int32 NID_PATRIMONIO, Decimal M_DEPOSITOS, Boolean L_CANCELADO)
        //{
        //        blld_MODIFICACION_ADEUDO oMODIFICACION_ADEUDO = new blld_MODIFICACION_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_DEPOSITOS, L_CANCELADO);
        //        if (oMODIFICACION_ADEUDO.lEsNuevoRegistro.Value) MODIFICACION_ADEUDOs.Add(oMODIFICACION_ADEUDO);
        //        _MODIFICACION_ADEUDOs[FindIndex_MODIFICACION_ADEUDOs(NID_PATRIMONIO)] = oMODIFICACION_ADEUDO;
        //}

        public Int32 FindIndex_MODIFICACION_ADEUDOs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_ADEUDOs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_VEHICULOs()
        {
            _MODIFICACION_VEHICULOs = new Lista<blld_MODIFICACION_VEHICULO>();
            foreach (MODELDeclara_V2.MODIFICACION_VEHICULO o in datos_MODIFICACION._MODIFICACION_VEHICULOs)
            {
                _MODIFICACION_VEHICULOs.Add(new blld_MODIFICACION_VEHICULO(o));
            }
        }

        private void _Add_MODIFICACION_VEHICULOs(Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_TIPO_COMPRA, Int32 NID_USO, Decimal M_VALOR_VEHICULO)
        {
                //blld_MODIFICACION_VEHICULO oMODIFICACION_VEHICULO = new blld_MODIFICACION_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, false );
                //if (oMODIFICACION_VEHICULO.lEsNuevoRegistro.Value) MODIFICACION_VEHICULOs.Add(oMODIFICACION_VEHICULO);
                //_MODIFICACION_VEHICULOs[FindIndex_MODIFICACION_VEHICULOs(NID_VEHICULO)] = oMODIFICACION_VEHICULO;
        }

        public Int32 FindIndex_MODIFICACION_VEHICULOs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_VEHICULOs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_INMUEBLEs()
        {
            _MODIFICACION_INMUEBLEs = new Lista<blld_MODIFICACION_INMUEBLE>();
            foreach (MODELDeclara_V2.MODIFICACION_INMUEBLE o in datos_MODIFICACION._MODIFICACION_INMUEBLEs)
            {
                _MODIFICACION_INMUEBLEs.Add(new blld_MODIFICACION_INMUEBLE(o));
            }
        }

        private void _Add_MODIFICACION_INMUEBLEs(Int32 NID_INMUEBLE, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        {
                blld_MODIFICACION_INMUEBLE oMODIFICACION_INMUEBLE = new blld_MODIFICACION_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, false);
                if (oMODIFICACION_INMUEBLE.lEsNuevoRegistro.Value) MODIFICACION_INMUEBLEs.Add(oMODIFICACION_INMUEBLE);
                _MODIFICACION_INMUEBLEs[FindIndex_MODIFICACION_INMUEBLEs(NID_INMUEBLE)] = oMODIFICACION_INMUEBLE;
        }

        public Int32 FindIndex_MODIFICACION_INMUEBLEs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_INMUEBLEs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_MUEBLEs()
        {
            _MODIFICACION_MUEBLEs = new Lista<blld_MODIFICACION_MUEBLE>();
            foreach (MODELDeclara_V2.MODIFICACION_MUEBLE o in datos_MODIFICACION._MODIFICACION_MUEBLEs)
            {
                _MODIFICACION_MUEBLEs.Add(new blld_MODIFICACION_MUEBLE(o));
            }
        }

        //private void _Add_MODIFICACION_MUEBLEs(Int32 NID_MUEBLE, Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR)
        //{
        //        blld_MODIFICACION_MUEBLE oMODIFICACION_MUEBLE = new blld_MODIFICACION_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_TIPO, E_ESPECIFICACION, M_VALOR, false);
        //        if (oMODIFICACION_MUEBLE.lEsNuevoRegistro.Value) MODIFICACION_MUEBLEs.Add(oMODIFICACION_MUEBLE);
        //        _MODIFICACION_MUEBLEs[FindIndex_MODIFICACION_MUEBLEs(NID_MUEBLE)] = oMODIFICACION_MUEBLE;
        //}

        public Int32 FindIndex_MODIFICACION_MUEBLEs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_MUEBLEs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_GASTOs()
        {
            _MODIFICACION_GASTOs = new Lista<blld_MODIFICACION_GASTO>();
            foreach (MODELDeclara_V2.MODIFICACION_GASTO o in datos_MODIFICACION._MODIFICACION_GASTOs)
            {
                _MODIFICACION_GASTOs.Add(new blld_MODIFICACION_GASTO(o));
            }
        }

        private void _Add_MODIFICACION_GASTOs(Int32 NID_TIPO_GASTO, String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC)
        {
                blld_MODIFICACION_GASTO oMODIFICACION_GASTO = new blld_MODIFICACION_GASTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO_GASTO, V_GASTO, M_GASTO, L_AUTOGENERADO, NID_PATRIMONIO_ASC);
                 MODIFICACION_GASTOs.Add(oMODIFICACION_GASTO);
        }

        public Int32 FindIndex_MODIFICACION_GASTOs(Int32 NID_GASTO)
        {
            return  MODIFICACION_GASTOs.FindIndex(p =>
                               p.NID_GASTO == NID_GASTO
                                                   );
        }


        private void _Reload_MODIFICACION_BAJAs()
        {
            _MODIFICACION_BAJAs = new Lista<blld_MODIFICACION_BAJA>();
            foreach (MODELDeclara_V2.MODIFICACION_BAJA o in datos_MODIFICACION._MODIFICACION_BAJAs)
            {
                _MODIFICACION_BAJAs.Add(new blld_MODIFICACION_BAJA(o));
            }
        }

        private void _Add_MODIFICACION_BAJAs(Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA)
        {
                blld_MODIFICACION_BAJA oMODIFICACION_BAJA = new blld_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA);
                if (oMODIFICACION_BAJA.lEsNuevoRegistro.Value) MODIFICACION_BAJAs.Add(oMODIFICACION_BAJA);
                _MODIFICACION_BAJAs[FindIndex_MODIFICACION_BAJAs(NID_PATRIMONIO)] = oMODIFICACION_BAJA;
        }

        public Int32 FindIndex_MODIFICACION_BAJAs(Int32 NID_PATRIMONIO)
        {
            return  MODIFICACION_BAJAs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_MODIFICACION_INGRESOSs()
        {
            _MODIFICACION_INGRESOSs = new Lista<blld_MODIFICACION_INGRESOS>();
            foreach (MODELDeclara_V2.MODIFICACION_INGRESOS o in datos_MODIFICACION._MODIFICACION_INGRESOSs)
            {
                _MODIFICACION_INGRESOSs.Add(new blld_MODIFICACION_INGRESOS(o));
            }
        }

        private void _Add_MODIFICACION_INGRESOSs(Int32 NID_INGRESO, String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        {
                blld_MODIFICACION_INGRESOS oMODIFICACION_INGRESOS = new blld_MODIFICACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, E_ESPECIFICAR, E_ESPECIFICAR_COMPLEMENTO, M_INGRESO, C_TITULAR);
                if (oMODIFICACION_INGRESOS.lEsNuevoRegistro.Value) MODIFICACION_INGRESOSs.Add(oMODIFICACION_INGRESOS);
                _MODIFICACION_INGRESOSs[FindIndex_MODIFICACION_INGRESOSs(NID_INGRESO)] = oMODIFICACION_INGRESOS;
        }

        public Int32 FindIndex_MODIFICACION_INGRESOSs(Int32 NID_INGRESO)
        {
            return  MODIFICACION_INGRESOSs.FindIndex(p =>
                               p.NID_INGRESO == NID_INGRESO
                                                   );
        }



     #endregion

    }
}
