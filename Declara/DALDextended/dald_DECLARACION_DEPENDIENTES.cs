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
    internal partial class dald_DECLARACION_DEPENDIENTES : dal_DECLARACION_DEPENDIENTES
    {

        #region *** Atributos (Extended) ***


        new public Int32 NID_TIPO_DEPENDIENTE
        {
            get => base.NID_TIPO_DEPENDIENTE;
            set
            {
                _oCAT_TIPO_DEPENDIENTES = null;
                base.NID_TIPO_DEPENDIENTE = value;
            }
        }

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_DEPENDIENTE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.DECLARACION_DEPENDIENTES
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_DEPENDIENTE).Max());
               return query + 1;
            }
            catch
            {
                return 1;
            }
        }

        new public void delete()
        {
            db.paDEPENDIENTE_ELIMINA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);
        }

        #endregion

    }
}
