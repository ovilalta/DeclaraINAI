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
    public partial class blld_CAT_PRIMER_NIVEL : bll_CAT_PRIMER_NIVEL
    {

     #region *** Atributos ***


        private Lista<blld_CAT_SEGUNDO_NIVEL> _CAT_SEGUNDO_NIVELs;
        public Lista<blld_CAT_SEGUNDO_NIVEL> CAT_SEGUNDO_NIVELs
        {
          get
          {
              if(_CAT_SEGUNDO_NIVELs == null)
              {
                  _CAT_SEGUNDO_NIVELs = new Lista<blld_CAT_SEGUNDO_NIVEL>();
                  Reload_CAT_SEGUNDO_NIVELs();
              }
              return _CAT_SEGUNDO_NIVELs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_CAT_PRIMER_NIVEL()
        : base()
        {
            _CAT_SEGUNDO_NIVELs = null;
        }

        public blld_CAT_PRIMER_NIVEL(MODELDeclara_V2.CAT_PRIMER_NIVEL CAT_PRIMER_NIVEL)
        : base(CAT_PRIMER_NIVEL)
        {
        }

        public  blld_CAT_PRIMER_NIVEL(String VID_PRIMER_NIVEL)
        : base(VID_PRIMER_NIVEL)
        {
        }

        //public blld_CAT_PRIMER_NIVEL(String VID_PRIMER_NIVEL, String V_PRIMER_NIVEL, String C_INICIO, String C_FIN)
        //: base(VID_PRIMER_NIVEL, V_PRIMER_NIVEL, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***

        private void _Reload_CAT_SEGUNDO_NIVELs()
        {
            _CAT_SEGUNDO_NIVELs = new Lista<blld_CAT_SEGUNDO_NIVEL>();
            foreach (MODELDeclara_V2.CAT_SEGUNDO_NIVEL o in datos_CAT_PRIMER_NIVEL._CAT_SEGUNDO_NIVELs)
            {
                _CAT_SEGUNDO_NIVELs.Add(new blld_CAT_SEGUNDO_NIVEL(o));
            }
        }

        private void _Add_CAT_SEGUNDO_NIVELs(String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN)
        {
                blld_CAT_SEGUNDO_NIVEL oCAT_SEGUNDO_NIVEL = new blld_CAT_SEGUNDO_NIVEL(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN);
                if (oCAT_SEGUNDO_NIVEL.lEsNuevoRegistro.Value) CAT_SEGUNDO_NIVELs.Add(oCAT_SEGUNDO_NIVEL);
                _CAT_SEGUNDO_NIVELs[FindIndex_CAT_SEGUNDO_NIVELs(VID_SEGUNDO_NIVEL)] = oCAT_SEGUNDO_NIVEL;
        }

        public Int32 FindIndex_CAT_SEGUNDO_NIVELs(String VID_SEGUNDO_NIVEL)
        {
            return  CAT_SEGUNDO_NIVELs.FindIndex(p =>
                               p.VID_SEGUNDO_NIVEL == VID_SEGUNDO_NIVEL
                                                   );
        }



     #endregion

    }
}
