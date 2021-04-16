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
    public partial class blld_USUARIO_REC_PASS : bll_USUARIO_REC_PASS
    {

        #region *** Atributos ***



        #endregion


        #region *** Constructores ***


        private blld_USUARIO_REC_PASS()
        : base()
        {
        }

        public blld_USUARIO_REC_PASS(MODELDeclara_V2.USUARIO_REC_PASS USUARIO_REC_PASS)
        : base(USUARIO_REC_PASS)
        {
        }

        public blld_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO)
        {
        }

        public blld_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, N_USOS, F_SOLICITUD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***


        #endregion

    }
}
