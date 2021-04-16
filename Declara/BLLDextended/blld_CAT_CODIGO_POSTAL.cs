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
// Extended
    public partial class blld_CAT_CODIGO_POSTAL : bll_CAT_CODIGO_POSTAL
    {

        #region *** Atributos (Extended) ***

        //        public Int32 NID_PAIS
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.NID_PAIS; }
        //        }

        //        public String CID_ENTIDAD_FEDERATIVA
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA; }
        //        }

        //        public String CID_MUNICIPIO
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.CID_MUNICIPIO; }
        //        }

        //        public String CID_CODIGO_POSTAL
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.CID_CODIGO_POSTAL; }
        //        }

        //        public Int32 NID_COLONIA
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.NID_COLONIA; }
        //        }


        //        public String V_COLONIA
        //        {
        //          get { return datos_CAT_CODIGO_POSTAL.V_COLONIA; }
        //          set { datos_CAT_CODIGO_POSTAL.V_COLONIA = value; }
        //        }

         public List<MODELextended.CAT_CODIGO_POSTAL> ListaColonias { get; private set; }

        #endregion


        #region *** Constructores (Extended) ***

        public blld_CAT_CODIGO_POSTAL(String CID_CODIGO_POSTAL)
        {
            blld__l_CAT_CODIGO_POSTAL oBuscar = new blld__l_CAT_CODIGO_POSTAL();
            oBuscar.CID_CODIGO_POSTAL = new StringFilter(CID_CODIGO_POSTAL);
            oBuscar.select();
            if (oBuscar.lista_CAT_CODIGO_POSTAL.Count > 0)
            {
                datos_CAT_CODIGO_POSTAL = new dald_CAT_CODIGO_POSTAL(oBuscar.lista_CAT_CODIGO_POSTAL[0]);
                ListaColonias = oBuscar.lista_CAT_CODIGO_POSTAL;
            }
            else
            {
                throw new CustomException("No hay coincidencias para el codigo postal");
            }
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
