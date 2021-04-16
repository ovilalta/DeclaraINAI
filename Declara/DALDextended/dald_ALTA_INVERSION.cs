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
    internal partial class dald_ALTA_INVERSION : dal_ALTA_INVERSION
    {

        #region *** Atributos (Extended) ***


        internal dald_CAT_PAIS _oPais;
        internal dald_CAT_ENTIDAD_FEDERATIVA _oEntidad;
        internal dald_CAT_PAIS oPais
        {
            get
            {
                if (_oPais == null)
                    _oPais = new dald_CAT_PAIS(NID_PAIS);
                return _oPais;
            }
        }
        internal dald_CAT_ENTIDAD_FEDERATIVA oEntidad
        {
            get
            {
                if (_oEntidad == null)
                    _oEntidad = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return _oEntidad;
            }
        }



        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.ALTA_INVERSION
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_INVERSION).Max());
               return query + 1;
            }
            catch
            {
                return 1;
            }
        }

        new public void delete()
        {
            db.paINVERSION_ELIMINA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION);
        }

        #endregion

    }
}
