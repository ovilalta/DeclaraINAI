using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DALD
{
    internal partial class dald_USUARIO : dal_USUARIO
    {

     #region *** Atributos ***

        internal List<CONFLICTO> _CONFLICTOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<PATRIMONIO> _PATRIMONIOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.PATRIMONIO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<USUARIO_DOMICILIO> _USUARIO_DOMICILIOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.USUARIO_DOMICILIO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<USUARIO_CORREO> _USUARIO_CORREOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.USUARIO_CORREO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<DECLARACION> _DECLARACIONs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.DECLARACION
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<USUARIO_SESION> _USUARIO_SESIONs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.USUARIO_SESION
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        internal List<USUARIO_REC_PASS> _USUARIO_REC_PASSs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.USUARIO_REC_PASS
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE
                              select p).ToList();
            }
        }

        public bool NVO_INGRESO { get; internal set; }

        public bool OBL_DECLARACION { get; internal set; }
        #endregion


        #region *** Constructores ***

        internal dald_USUARIO()
        : base() { }

        internal dald_USUARIO(USUARIO USUARIO)
        : base(USUARIO) { }

        internal dald_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE) { }

        public dald_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_PASSWORD, V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, lOpcionesRegistroExistente)  { }

        public dald_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, Boolean NVO_INGRESO, Boolean OBL_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_PASSWORD, V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, NVO_INGRESO, OBL_DECLARACION, lOpcionesRegistroExistente)  { }
        

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
