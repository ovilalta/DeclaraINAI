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
    public partial class blld_CAT_PRIMER_NIVEL : bll_CAT_PRIMER_NIVEL
    {

        #region *** Atributos (Extended) ***

        //        public String VID_PRIMER_NIVEL
        //        {
        //          get { return datos_CAT_PRIMER_NIVEL.VID_PRIMER_NIVEL; }
        //        }


        //        public String V_PRIMER_NIVEL
        //        {
        //          get { return datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVEL; }
        //          set { datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVEL = value; }
        //        }


        //        public String C_INICIO
        //        {
        //          get { return datos_CAT_PRIMER_NIVEL.C_INICIO; }
        //          set { datos_CAT_PRIMER_NIVEL.C_INICIO = value; }
        //        }


        //        public String C_FIN
        //        {
        //          get { return datos_CAT_PRIMER_NIVEL.C_FIN; }
        //          set { datos_CAT_PRIMER_NIVEL.C_FIN = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***
        public blld_CAT_PRIMER_NIVEL(String VID_PRIMER_NIVEL, String V_PRIMER_NIVEL, String C_INICIO, String C_FIN)
        : base()
        {
            if (Convert.ToInt32(C_INICIO) > Convert.ToInt32(C_FIN)) throw new CustomException("Las Fechas son incorrectas");
            datos_CAT_PRIMER_NIVEL = new dald_CAT_PRIMER_NIVEL(VID_PRIMER_NIVEL, V_PRIMER_NIVEL, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_CAT_SEGUNDO_NIVELs()
        {
                _Reload_CAT_SEGUNDO_NIVELs();
        }

        public void Add_CAT_SEGUNDO_NIVELs(String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN)
        {
            try
            {
                _Add_CAT_SEGUNDO_NIVELs(VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }


     #endregion

    }
}
