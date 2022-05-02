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
    public partial class blld_CAT_PUESTO : bll_CAT_PUESTO
    {

     #region *** Atributos ***


        //private Lista<blld_DECLARACION_CARGO> _DECLARACION_CARGOs;
        //public Lista<blld_DECLARACION_CARGO> DECLARACION_CARGOs
        //{
        //  get
        //  {
        //      if(_DECLARACION_CARGOs == null)
        //      {
        //          _DECLARACION_CARGOs = new Lista<blld_DECLARACION_CARGO>();
        //          Reload_DECLARACION_CARGOs();
        //      }
        //      return _DECLARACION_CARGOs;
        //  }
        //}


     #endregion


     #region *** Constructores ***

        private blld_CAT_PUESTO()
        : base()
        {
            //_DECLARACION_CARGOs = null;
        }

        public blld_CAT_PUESTO(MODELDeclara_V2.CAT_PUESTO CAT_PUESTO)
        : base(CAT_PUESTO)
        {
        }

        public  blld_CAT_PUESTO(Int32 NID_PUESTO)
        : base(NID_PUESTO)
        {
        }

        public blld_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO)
        : base(NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }

        public blld_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO, String NOMBRE_UA)
        : base(NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, NOMBRE_UA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***

        //private void _Reload_DECLARACION_CARGOs()
        //{
        //    _DECLARACION_CARGOs = new Lista<blld_DECLARACION_CARGO>();
        //    foreach (MODELDeclara_V2.DECLARACION_CARGO o in datos_CAT_PUESTO._DECLARACION_CARGOs)
        //    {
        //        _DECLARACION_CARGOs.Add(new blld_DECLARACION_CARGO(o));
        //    }
        //}

        //private void _Add_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String V_DENOMINACION, Int32 NID_PRIMER_NIVEL, Int32 NID_SEGUNDO_NIVEL, DateTime F_POSESION, DateTime F_INICIO)
        //{
        //        blld_DECLARACION_CARGO oDECLARACION_CARGO = new blld_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, NID_PRIMER_NIVEL, NID_SEGUNDO_NIVEL, F_POSESION, F_INICIO);
        //        if (oDECLARACION_CARGO.lEsNuevoRegistro.Value) DECLARACION_CARGOs.Add(oDECLARACION_CARGO);
        //        _DECLARACION_CARGOs[FindIndex_DECLARACION_CARGOs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)] = oDECLARACION_CARGO;
        //}

        //public Int32 FindIndex_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        //{
        //    return  DECLARACION_CARGOs.FindIndex(p =>
        //                       p.VID_NOMBRE == VID_NOMBRE && 
        //                       p.VID_FECHA == VID_FECHA && 
        //                       p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
        //                       p.NID_DECLARACION == NID_DECLARACION
        //                                           );
        //}



        #endregion

    }
}
