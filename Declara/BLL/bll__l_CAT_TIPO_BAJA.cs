using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_BAJA : _bllSistema
    {

        internal dald__l_CAT_TIPO_BAJA datos_CAT_TIPO_BAJA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_BAJA> lista_CAT_TIPO_BAJA => datos_CAT_TIPO_BAJA.lista_CAT_TIPO_BAJAs;

        protected List<MODELDeclara_V2.CAT_TIPO_BAJA>  base_CAT_TIPO_BAJAs => datos_CAT_TIPO_BAJA.base_CAT_TIPO_BAJAs;

        public IntegerFilter NID_TIPO_BAJA
        {
          get => datos_CAT_TIPO_BAJA.NID_TIPO_BAJA;
          set => datos_CAT_TIPO_BAJA.NID_TIPO_BAJA = value;
        }
        public ListFilter<Int32> NID_TIPO_BAJAs
        {
          get => datos_CAT_TIPO_BAJA.NID_TIPO_BAJAs;
          set => datos_CAT_TIPO_BAJA.NID_TIPO_BAJAs = value;
        }

        public StringFilter V_TIPO_BAJA
        {
          get => datos_CAT_TIPO_BAJA.V_TIPO_BAJA;
          set => datos_CAT_TIPO_BAJA.V_TIPO_BAJA = value;
        }
        public ListFilter<String> V_TIPO_BAJAs
        {
          get => datos_CAT_TIPO_BAJA.V_TIPO_BAJAs;
          set => datos_CAT_TIPO_BAJA.V_TIPO_BAJAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_BAJA.OrderByCriterios; 
            set => datos_CAT_TIPO_BAJA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_BAJA() => datos_CAT_TIPO_BAJA = new dald__l_CAT_TIPO_BAJA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_BAJA.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_BAJA.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_BAJA.single_select();
        }

     #endregion

    }
}
