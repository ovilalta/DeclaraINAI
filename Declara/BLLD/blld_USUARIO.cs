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
    public partial class blld_USUARIO : bll_USUARIO
    {

     #region *** Atributos ***


        private Lista<blld_CONFLICTO> _CONFLICTOs;
        public Lista<blld_CONFLICTO> CONFLICTOs
        {
          get
          {
              if(_CONFLICTOs == null)
              {
                  _CONFLICTOs = new Lista<blld_CONFLICTO>();
                  Reload_CONFLICTOs();
              }
              return _CONFLICTOs;
          }
        }

        private Lista<blld_PATRIMONIO> _PATRIMONIOs;
        public Lista<blld_PATRIMONIO> PATRIMONIOs
        {
          get
          {
              if(_PATRIMONIOs == null)
              {
                  _PATRIMONIOs = new Lista<blld_PATRIMONIO>();
                  Reload_PATRIMONIOs();
              }
              return _PATRIMONIOs;
          }
        }

        private Lista<blld_USUARIO_DOMICILIO> _USUARIO_DOMICILIOs;
        public Lista<blld_USUARIO_DOMICILIO> USUARIO_DOMICILIOs
        {
          get
          {
              if(_USUARIO_DOMICILIOs == null)
              {
                  _USUARIO_DOMICILIOs = new Lista<blld_USUARIO_DOMICILIO>();
                  Reload_USUARIO_DOMICILIOs();
              }
              return _USUARIO_DOMICILIOs;
          }
        }

        

        private Lista<blld_USUARIO_CORREO> _USUARIO_CORREOs;
        public Lista<blld_USUARIO_CORREO> USUARIO_CORREOs
        {
          get
          {
              if(_USUARIO_CORREOs == null)
              {
                  _USUARIO_CORREOs = new Lista<blld_USUARIO_CORREO>();
                  Reload_USUARIO_CORREOs();
              }
                if (_USUARIO_CORREOs.Count == 1 && _USUARIO_CORREOs.Where(p => p.L_PRINCIPAL).Count() == 0)
                {
                    _USUARIO_CORREOs[0].L_PRINCIPAL = true;
                    _USUARIO_CORREOs[0].update();
                }
              return _USUARIO_CORREOs;
          }
        }

        private Lista<blld_DECLARACION> _DECLARACIONs;
        public Lista<blld_DECLARACION> DECLARACIONs
        {
          get
          {
              if(_DECLARACIONs == null)
              {
                  _DECLARACIONs = new Lista<blld_DECLARACION>();
                  Reload_DECLARACIONs();
              }
              return _DECLARACIONs;
          }
        }

        private Lista<blld_USUARIO_SESION> _USUARIO_SESIONs;
        public Lista<blld_USUARIO_SESION> USUARIO_SESIONs
        {
          get
          {
              if(_USUARIO_SESIONs == null)
              {
                  _USUARIO_SESIONs = new Lista<blld_USUARIO_SESION>();
                  Reload_USUARIO_SESIONs();
              }
              return _USUARIO_SESIONs;
          }
        }

        private Lista<blld_USUARIO_REC_PASS> _USUARIO_REC_PASSs;
        public Lista<blld_USUARIO_REC_PASS> USUARIO_REC_PASSs
        {
          get
          {
              if(_USUARIO_REC_PASSs == null)
              {
                  _USUARIO_REC_PASSs = new Lista<blld_USUARIO_REC_PASS>();
                  Reload_USUARIO_REC_PASSs();
              }
              return _USUARIO_REC_PASSs;
          }
        }


        #endregion


        #region *** Constructores ***

        private blld_USUARIO()
        : base()
        {
            _CONFLICTOs = null;
            _PATRIMONIOs = null;
            _USUARIO_DOMICILIOs = null;
            _USUARIO_CORREOs = null;
            _DECLARACIONs = null;
            _USUARIO_SESIONs = null;
            _USUARIO_REC_PASSs = null;
        }

        public blld_USUARIO(MODELDeclara_V2.USUARIO USUARIO)
        : base(USUARIO)
        {
        }

        public  blld_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE)
        {
        }

        public blld_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_PASSWORD, V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }

        public blld_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, Boolean NVO_INGRESO, Boolean OBL_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_PASSWORD, V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, NVO_INGRESO, OBL_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***

        private void _Reload_CONFLICTOs()
        {
            _CONFLICTOs = new Lista<blld_CONFLICTO>();
            foreach (MODELDeclara_V2.CONFLICTO o in datos_USUARIO._CONFLICTOs)
            {
                _CONFLICTOs.Add(new blld_CONFLICTO(o));
            }
        }

        private void _Add_CONFLICTOs(Int32 NID_CONFLICTO, Int32 NID_DEC_ASOS)
        {
                blld_CONFLICTO oCONFLICTO = new blld_CONFLICTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_DEC_ASOS);
                if (oCONFLICTO.lEsNuevoRegistro.Value) CONFLICTOs.Add(oCONFLICTO);
                _CONFLICTOs[FindIndex_CONFLICTOs(NID_CONFLICTO)] = oCONFLICTO;
        }

        public Int32 FindIndex_CONFLICTOs(Int32 NID_CONFLICTO)
        {
            return  CONFLICTOs.FindIndex(p =>
                               p.NID_CONFLICTO == NID_CONFLICTO
                                                   );
        }


        private void _Reload_PATRIMONIOs()
        {
            _PATRIMONIOs = new Lista<blld_PATRIMONIO>();
            foreach (MODELDeclara_V2.PATRIMONIO o in datos_USUARIO._PATRIMONIOs)
            {
                _PATRIMONIOs.Add(new blld_PATRIMONIO(o));
            }
        }

        private void _Add_PATRIMONIOs(Int32 NID_PATRIMONIO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, DateTime F_REGISTRO)
        {
                blld_PATRIMONIO oPATRIMONIO = new blld_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO);
                if (oPATRIMONIO.lEsNuevoRegistro.Value) PATRIMONIOs.Add(oPATRIMONIO);
                _PATRIMONIOs[FindIndex_PATRIMONIOs(NID_PATRIMONIO)] = oPATRIMONIO;
        }

        public Int32 FindIndex_PATRIMONIOs(Int32 NID_PATRIMONIO)
        {
            return  PATRIMONIOs.FindIndex(p =>
                               p.NID_PATRIMONIO == NID_PATRIMONIO
                                                   );
        }


        private void _Reload_USUARIO_DOMICILIOs()
        {
            _USUARIO_DOMICILIOs = new Lista<blld_USUARIO_DOMICILIO>();
            foreach (MODELDeclara_V2.USUARIO_DOMICILIO o in datos_USUARIO._USUARIO_DOMICILIOs)
            {
                _USUARIO_DOMICILIOs.Add(new blld_USUARIO_DOMICILIO(o));
            }
        }

        private void _Add_USUARIO_DOMICILIOs(Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO)
        {
                blld_USUARIO_DOMICILIO oUSUARIO_DOMICILIO = new blld_USUARIO_DOMICILIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO);
                if (oUSUARIO_DOMICILIO.lEsNuevoRegistro.Value) USUARIO_DOMICILIOs.Add(oUSUARIO_DOMICILIO);
                _USUARIO_DOMICILIOs[FindIndex_USUARIO_DOMICILIOs(NID_DOMICILIO)] = oUSUARIO_DOMICILIO;
        }

        public Int32 FindIndex_USUARIO_DOMICILIOs(Int32 NID_DOMICILIO)
        {
            return  USUARIO_DOMICILIOs.FindIndex(p =>
                               p.NID_DOMICILIO == NID_DOMICILIO
                                                   );
        }


     
        private void _Reload_USUARIO_CORREOs()
        {
            _USUARIO_CORREOs = new Lista<blld_USUARIO_CORREO>();
            foreach (MODELDeclara_V2.USUARIO_CORREO o in datos_USUARIO._USUARIO_CORREOs)
            {
                _USUARIO_CORREOs.Add(new blld_USUARIO_CORREO(o));
            }
        }

        private void _Add_USUARIO_CORREOs(String V_CORREO, Boolean lEnviaConfirmacion)
        {
                blld_USUARIO_CORREO oUSUARIO_CORREO = new blld_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, true, lEnviaConfirmacion);
                if (oUSUARIO_CORREO.lEsNuevoRegistro.Value) USUARIO_CORREOs.Add(oUSUARIO_CORREO);
                _USUARIO_CORREOs[FindIndex_USUARIO_CORREOs(V_CORREO)] = oUSUARIO_CORREO;
        }

        private void _Add_USUARIO_CORREOs(String V_CORREO, Boolean lEnviaConfirmacion, bool confirmado)
        {
            blld_USUARIO_CORREO oUSUARIO_CORREO = new blld_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, true, lEnviaConfirmacion, confirmado);
            if (oUSUARIO_CORREO.lEsNuevoRegistro.Value) USUARIO_CORREOs.Add(oUSUARIO_CORREO);
            _USUARIO_CORREOs[FindIndex_USUARIO_CORREOs(V_CORREO)] = oUSUARIO_CORREO;
        }

        public Int32 FindIndex_USUARIO_CORREOs(String V_CORREO)
        {
            return  USUARIO_CORREOs.FindIndex(p =>
                               p.V_CORREO == V_CORREO
                                                   );
        }


        private void _Reload_DECLARACIONs()
        {
            _DECLARACIONs = new Lista<blld_DECLARACION>();
            foreach (MODELDeclara_V2.DECLARACION o in datos_USUARIO._DECLARACIONs)
            {
                _DECLARACIONs.Add(new blld_DECLARACION(o));
            }
        }

        //private void _Add_DECLARACIONs(Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, DateTime F_REGISTRO, DateTime F_ENVIO, Boolean L_CONFLICTO)
        //{
        //        blld_DECLARACION oDECLARACION = new blld_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO);
        //        if (oDECLARACION.lEsNuevoRegistro.Value) DECLARACIONs.Add(oDECLARACION);
        //        _DECLARACIONs[FindIndex_DECLARACIONs(NID_DECLARACION)] = oDECLARACION;
        //}

        public Int32 FindIndex_DECLARACIONs(Int32 NID_DECLARACION)
        {
            return  DECLARACIONs.FindIndex(p =>
                               p.NID_DECLARACION == NID_DECLARACION
                                                   );
        }


        private void _Reload_USUARIO_SESIONs()
        {
            _USUARIO_SESIONs = new Lista<blld_USUARIO_SESION>();
            foreach (MODELDeclara_V2.USUARIO_SESION o in datos_USUARIO._USUARIO_SESIONs)
            {
                _USUARIO_SESIONs.Add(new blld_USUARIO_SESION(o));
            }
        }

        private void _Add_USUARIO_SESIONs(Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN)
        {
                blld_USUARIO_SESION oUSUARIO_SESION = new blld_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN);
                if (oUSUARIO_SESION.lEsNuevoRegistro.Value) USUARIO_SESIONs.Add(oUSUARIO_SESION);
                _USUARIO_SESIONs[FindIndex_USUARIO_SESIONs(NID_SESION)] = oUSUARIO_SESION;
        }

        public Int32 FindIndex_USUARIO_SESIONs(Int32 NID_SESION)
        {
            return  USUARIO_SESIONs.FindIndex(p =>
                               p.NID_SESION == NID_SESION
                                                   );
        }


        private void _Reload_USUARIO_REC_PASSs()
        {
            _USUARIO_REC_PASSs = new Lista<blld_USUARIO_REC_PASS>();
            foreach (MODELDeclara_V2.USUARIO_REC_PASS o in datos_USUARIO._USUARIO_REC_PASSs)
            {
                _USUARIO_REC_PASSs.Add(new blld_USUARIO_REC_PASS(o));
            }
        }

        private void _Add_USUARIO_REC_PASSs(String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD)
        {
                blld_USUARIO_REC_PASS oUSUARIO_REC_PASS = new blld_USUARIO_REC_PASS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, N_USOS, F_SOLICITUD);
                if (oUSUARIO_REC_PASS.lEsNuevoRegistro.Value) USUARIO_REC_PASSs.Add(oUSUARIO_REC_PASS);
                _USUARIO_REC_PASSs[FindIndex_USUARIO_REC_PASSs(V_CORREO)] = oUSUARIO_REC_PASS;
        }

        public Int32 FindIndex_USUARIO_REC_PASSs(String V_CORREO)
        {
            return  USUARIO_REC_PASSs.FindIndex(p =>
                               p.V_CORREO == V_CORREO
                                                   );
        }



     #endregion

    }
}
