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
    internal partial class dald_DECLARACION_DOM_PARTICULAR : dal_DECLARACION_DOM_PARTICULAR
    {

        #region *** Atributos (Extended) ***

        internal dald_CAT_PAIS oPais;
        internal dald_CAT_ENTIDAD_FEDERATIVA oEntidad;
        internal dald_CAT_MUNICIPIO oMunicipio;
        internal string V_PAIS
        {
            get
            {
                if (oPais == null)
                    oPais = new dald_CAT_PAIS(NID_PAIS);
                return oPais.V_PAIS;
            }
        }
        //internal string V_ENTIDAD_FEDERATIVA
        //{
        //    get
        //    {
        //        if (oEntidad == null)
        //            oEntidad = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
        //        return oEntidad.V_ENTIDAD_FEDERATIVA;
        //    }
        //}
        //internal string V_MUNICIPIO
        //{
        //    get
        //    {
        //        if (oMunicipio == null)
        //            oMunicipio = new dald_CAT_MUNICIPIO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO);
        //        return oMunicipio.V_MUNICIPIO;
        //    }
        //}

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
