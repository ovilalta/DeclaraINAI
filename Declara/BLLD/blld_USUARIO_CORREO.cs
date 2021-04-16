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
    public partial class blld_USUARIO_CORREO : bll_USUARIO_CORREO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_USUARIO_CORREO()
        : base()
        {
        }

        public blld_USUARIO_CORREO(MODELDeclara_V2.USUARIO_CORREO USUARIO_CORREO)
        : base(USUARIO_CORREO)
        {
        }

        public  blld_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO)
        {
        }

        public blld_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_PRINCIPAL, Boolean L_ACTIVO, Boolean L_CONFIRMADO, Int32 N_CODIGO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, L_PRINCIPAL, L_ACTIVO, L_CONFIRMADO, N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***


        #endregion

    }
}
