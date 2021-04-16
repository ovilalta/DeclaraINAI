using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPS : _bllSistema
    {

        internal dald__l_CAT_TIPS datos_CAT_TIPS;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPS> lista_CAT_TIPS => datos_CAT_TIPS.lista_CAT_TIPSs;

        protected List<MODELDeclara_V2.CAT_TIPS>  base_CAT_TIPSs => datos_CAT_TIPS.base_CAT_TIPSs;

        public IntegerFilter NID_TIP
        {
          get => datos_CAT_TIPS.NID_TIP;
          set => datos_CAT_TIPS.NID_TIP = value;
        }
        public ListFilter<Int32> NID_TIPs
        {
          get => datos_CAT_TIPS.NID_TIPs;
          set => datos_CAT_TIPS.NID_TIPs = value;
        }

        public StringFilter V_TIP
        {
          get => datos_CAT_TIPS.V_TIP;
          set => datos_CAT_TIPS.V_TIP = value;
        }
        public ListFilter<String> V_TIPs
        {
          get => datos_CAT_TIPS.V_TIPs;
          set => datos_CAT_TIPS.V_TIPs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPS.OrderByCriterios; 
            set => datos_CAT_TIPS.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPS() => datos_CAT_TIPS = new dald__l_CAT_TIPS();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPS.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPS.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPS.single_select();
        }

     #endregion

    }
}
