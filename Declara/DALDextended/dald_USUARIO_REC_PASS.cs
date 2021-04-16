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
    internal partial class dald_USUARIO_REC_PASS : dal_USUARIO_REC_PASS
    {
        //USUARIO_REC_PASS registro;

        #region *** Atributos (Extended) ***

        new internal String V_CORREO
        {
            get => registro.V_CORREO;
            set => registro.V_CORREO = value;
        }

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


    }

}