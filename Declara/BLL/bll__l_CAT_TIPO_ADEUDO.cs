using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_ADEUDO : _bllSistema
    {

        internal dald__l_CAT_TIPO_ADEUDO datos_CAT_TIPO_ADEUDO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_ADEUDO> lista_CAT_TIPO_ADEUDO => datos_CAT_TIPO_ADEUDO.lista_CAT_TIPO_ADEUDOs;

        protected List<MODELDeclara_V2.CAT_TIPO_ADEUDO>  base_CAT_TIPO_ADEUDOs => datos_CAT_TIPO_ADEUDO.base_CAT_TIPO_ADEUDOs;

        public IntegerFilter NID_TIPO_ADEUDO
        {
          get => datos_CAT_TIPO_ADEUDO.NID_TIPO_ADEUDO;
          set => datos_CAT_TIPO_ADEUDO.NID_TIPO_ADEUDO = value;
        }
        public ListFilter<Int32> NID_TIPO_ADEUDOs
        {
          get => datos_CAT_TIPO_ADEUDO.NID_TIPO_ADEUDOs;
          set => datos_CAT_TIPO_ADEUDO.NID_TIPO_ADEUDOs = value;
        }

        public StringFilter V_TIPO_ADEUDO
        {
          get => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDO;
          set => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDO = value;
        }
        public ListFilter<String> V_TIPO_ADEUDOs
        {
          get => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDOs;
          set => datos_CAT_TIPO_ADEUDO.V_TIPO_ADEUDOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
            get => datos_CAT_TIPO_ADEUDO.L_ACTIVO;
            set => datos_CAT_TIPO_ADEUDO.L_ACTIVO = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_ADEUDO.OrderByCriterios; 
            set => datos_CAT_TIPO_ADEUDO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_ADEUDO() => datos_CAT_TIPO_ADEUDO = new dald__l_CAT_TIPO_ADEUDO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_ADEUDO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_ADEUDO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_ADEUDO.single_select();
        }

     #endregion

    }
}
