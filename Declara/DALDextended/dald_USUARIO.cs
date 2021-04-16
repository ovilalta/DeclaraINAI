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
    // Extended
    internal partial class dald_USUARIO : dal_USUARIO
    {

        #region *** Atributos (Extended) ***

        public char C_GENERO
        {
            get
            {
                try
                {
                    IEnumerable<DECLARACION_PERSONALES> o = (from p in db.DECLARACION_PERSONALES
                             where p.VID_NOMBRE == VID_NOMBRE &&
                             p.VID_FECHA == VID_FECHA &&
                             p.VID_HOMOCLAVE == VID_HOMOCLAVE
                             select p);

                    return Convert.ToChar(o.Last().C_GENERO);
                        }
                catch (Exception ex)
                {
                    return 'N';
                }
            }
        }
        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***
        internal void principal(String v_CORREO)
        {
            db.paUSUARIO_CORREO_PRINCIPAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, v_CORREO);
        }
        #endregion

    }
}
