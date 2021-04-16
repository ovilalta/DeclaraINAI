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
    public partial class blld_CAT_CONFLICTO_RUBRO : bll_CAT_CONFLICTO_RUBRO
    {

     #region *** Atributos ***


        private Lista<blld_CAT_CONFLICTO_PREGUNTA> _CAT_CONFLICTO_PREGUNTAs;
        public Lista<blld_CAT_CONFLICTO_PREGUNTA> CAT_CONFLICTO_PREGUNTAs
        {
          get
          {
              if(_CAT_CONFLICTO_PREGUNTAs == null)
              {
                  _CAT_CONFLICTO_PREGUNTAs = new Lista<blld_CAT_CONFLICTO_PREGUNTA>();
                  Reload_CAT_CONFLICTO_PREGUNTAs();
              }
              return _CAT_CONFLICTO_PREGUNTAs;
          }
        }

        private Lista<blld_CONFLICTO_RUBRO> _CONFLICTO_RUBROs;
        public Lista<blld_CONFLICTO_RUBRO> CONFLICTO_RUBROs
        {
          get
          {
              if(_CONFLICTO_RUBROs == null)
              {
                  _CONFLICTO_RUBROs = new Lista<blld_CONFLICTO_RUBRO>();
                  Reload_CONFLICTO_RUBROs();
              }
              return _CONFLICTO_RUBROs;
          }
        }


     #endregion


     #region *** Constructores ***

        private blld_CAT_CONFLICTO_RUBRO()
        : base()
        {
            _CAT_CONFLICTO_PREGUNTAs = null;
            _CONFLICTO_RUBROs = null;
        }

        public blld_CAT_CONFLICTO_RUBRO(MODELDeclara_V2.CAT_CONFLICTO_RUBRO CAT_CONFLICTO_RUBRO)
        : base(CAT_CONFLICTO_RUBRO)
        {
        }

        public  blld_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO)
        : base(NID_RUBRO)
        {
        }

        public blld_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO, String V_RUBRO, String C_INICIO, String C_FIN)
        : base(NID_RUBRO, V_RUBRO, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***

        private void _Reload_CAT_CONFLICTO_PREGUNTAs()
        {
            _CAT_CONFLICTO_PREGUNTAs = new Lista<blld_CAT_CONFLICTO_PREGUNTA>();
            foreach (MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA o in datos_CAT_CONFLICTO_RUBRO._CAT_CONFLICTO_PREGUNTAs)
            {
                _CAT_CONFLICTO_PREGUNTAs.Add(new blld_CAT_CONFLICTO_PREGUNTA(o));
            }
        }

        private void _Add_CAT_CONFLICTO_PREGUNTAs(Int32 NID_PREGUNTA, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN)
        {
                blld_CAT_CONFLICTO_PREGUNTA oCAT_CONFLICTO_PREGUNTA = new blld_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA, V_RUBRO,V_OPCIONES, C_INICIO, C_FIN);
                if (oCAT_CONFLICTO_PREGUNTA.lEsNuevoRegistro.Value) CAT_CONFLICTO_PREGUNTAs.Add(oCAT_CONFLICTO_PREGUNTA);
                _CAT_CONFLICTO_PREGUNTAs[FindIndex_CAT_CONFLICTO_PREGUNTAs(NID_PREGUNTA)] = oCAT_CONFLICTO_PREGUNTA;
        }

        public Int32 FindIndex_CAT_CONFLICTO_PREGUNTAs(Int32 NID_PREGUNTA)
        {
            return  CAT_CONFLICTO_PREGUNTAs.FindIndex(p =>
                               p.NID_PREGUNTA == NID_PREGUNTA
                                                   );
        }


        private void _Reload_CONFLICTO_RUBROs()
        {
            _CONFLICTO_RUBROs = new Lista<blld_CONFLICTO_RUBRO>();
            foreach (MODELDeclara_V2.CONFLICTO_RUBRO o in datos_CAT_CONFLICTO_RUBRO._CONFLICTO_RUBROs)
            {
                _CONFLICTO_RUBROs.Add(new blld_CONFLICTO_RUBRO(o));
            }
        }

        private void _Add_CONFLICTO_RUBROs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Boolean L_RESPUESTA)
        {
                blld_CONFLICTO_RUBRO oCONFLICTO_RUBRO = new blld_CONFLICTO_RUBRO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, L_RESPUESTA);
                if (oCONFLICTO_RUBRO.lEsNuevoRegistro.Value) CONFLICTO_RUBROs.Add(oCONFLICTO_RUBRO);
                _CONFLICTO_RUBROs[FindIndex_CONFLICTO_RUBROs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO)] = oCONFLICTO_RUBRO;
        }

        public Int32 FindIndex_CONFLICTO_RUBROs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO)
        {
            return  CONFLICTO_RUBROs.FindIndex(p =>
                               p.VID_NOMBRE == VID_NOMBRE && 
                               p.VID_FECHA == VID_FECHA && 
                               p.VID_HOMOCLAVE == VID_HOMOCLAVE && 
                               p.NID_CONFLICTO == NID_CONFLICTO
                                                   );
        }



     #endregion

    }
}
