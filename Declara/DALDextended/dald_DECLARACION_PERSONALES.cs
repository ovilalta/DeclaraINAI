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
    internal partial class dald_DECLARACION_PERSONALES : dal_DECLARACION_PERSONALES
    {

        #region *** Atributos (Extended) ***

        internal dald_CAT_PAIS oPais;
        internal dald_CAT_ENTIDAD_FEDERATIVA oEntidad;
        internal dald_CAT_PAIS oNacionalidad;
        internal String V_PAIS_NACIMIENTO
        {
            get
            {
                if (oPais == null)
                    oPais = new dald_CAT_PAIS(NID_PAIS);
                return oPais.V_PAIS;
            }
        }
        internal String V_ENTIDAD_NACIMIENTO
        {
            get
            {
                if (oEntidad == null)
                    oEntidad = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return oEntidad.V_ENTIDAD_FEDERATIVA;
            }
        }
        internal String V_NACIONALIDAD(System.Nullable<Char> C_GENERO)
        {
            if (oNacionalidad == null)
                oNacionalidad = new dald_CAT_PAIS(NID_NACIONALIDAD);
            if (C_GENERO.HasValue)
                switch (C_GENERO)
                {
                    case 'M':
                        return oNacionalidad.V_NACIONALIDAD_M;
                    case 'F':
                        return oNacionalidad.V_NACIONALIDAD_F;
                    default:
                        return oNacionalidad.V_NACIONALIDAD_M;
                }
            else
                return oNacionalidad.V_NACIONALIDAD_M;
        }

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
