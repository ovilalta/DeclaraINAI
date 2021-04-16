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
    public partial class blld_CAT_SEGUNDO_NIVEL : bll_CAT_SEGUNDO_NIVEL
    {

     #region *** Atributos ***


        private Lista<blld_DECLARACION_CARGO> _DECLARACION_CARGOs;
        public Lista<blld_DECLARACION_CARGO> DECLARACION_CARGOs
        {
          get
          {
              if(_DECLARACION_CARGOs == null)
              {
                  _DECLARACION_CARGOs = new Lista<blld_DECLARACION_CARGO>();
                  Reload_DECLARACION_CARGOs();
              }
              return _DECLARACION_CARGOs;
          }
        }

        #region * CAT_PRIMER_NIVEL *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo P R I M E R_ N I V E L es requerido ")]
        [DisplayName("P R I M E R_ N I V E L")]
        public String V_PRIMER_NIVEL => datos_CAT_SEGUNDO_NIVEL.V_PRIMER_NIVEL;



        #endregion * CAT_PRIMER_NIVEL *



     #endregion


     #region *** Constructores ***

        private blld_CAT_SEGUNDO_NIVEL()
        : base()
        {
            _DECLARACION_CARGOs = null;
        }

        public blld_CAT_SEGUNDO_NIVEL(MODELDeclara_V2.CAT_SEGUNDO_NIVEL CAT_SEGUNDO_NIVEL)
        : base(CAT_SEGUNDO_NIVEL)
        {
        }

        public  blld_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL)
        : base(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL)
        {
        }

        //public blld_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN)
        //: base(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***

        private void _Reload_DECLARACION_CARGOs()
        {
            _DECLARACION_CARGOs = new Lista<blld_DECLARACION_CARGO>();
            foreach (MODELDeclara_V2.DECLARACION_CARGO o in datos_CAT_SEGUNDO_NIVEL._DECLARACION_CARGOs)
            {
                _DECLARACION_CARGOs.Add(new blld_DECLARACION_CARGO(o));
            }
        }

        private void _Add_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, DateTime F_INICIO)
        {
            blld_DECLARACION_CARGO oDECLARACION_CARGO = new blld_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL);
            if (oDECLARACION_CARGO.lEsNuevoRegistro.Value) DECLARACION_CARGOs.Add(oDECLARACION_CARGO);
            _DECLARACION_CARGOs[FindIndex_DECLARACION_CARGOs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)] = oDECLARACION_CARGO;
        }

        public Int32 FindIndex_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            return  DECLARACION_CARGOs.FindIndex(p =>
                               p.VID_NOMBRE == VID_NOMBRE && 
                               p.VID_FECHA == VID_FECHA && 
                               p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
                               p.NID_DECLARACION == NID_DECLARACION
                                                   );
        }



     #endregion

    }
}
