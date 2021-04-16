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
    public partial class blld_USUARIO_SESION : bll_USUARIO_SESION
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_USUARIO_SESION()
        : base()
        {
        }

        public blld_USUARIO_SESION(MODELDeclara_V2.USUARIO_SESION USUARIO_SESION)
        : base(USUARIO_SESION)
        {
        }

        public  blld_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION)
        {
        }

        public blld_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
