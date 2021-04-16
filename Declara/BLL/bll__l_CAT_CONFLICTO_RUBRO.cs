using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_CONFLICTO_RUBRO : _bllSistema
    {

        internal dald__l_CAT_CONFLICTO_RUBRO datos_CAT_CONFLICTO_RUBRO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_CONFLICTO_RUBRO> lista_CAT_CONFLICTO_RUBRO => datos_CAT_CONFLICTO_RUBRO.lista_CAT_CONFLICTO_RUBROs;

        protected List<MODELDeclara_V2.CAT_CONFLICTO_RUBRO>  base_CAT_CONFLICTO_RUBROs => datos_CAT_CONFLICTO_RUBRO.base_CAT_CONFLICTO_RUBROs;

        public IntegerFilter NID_RUBRO
        {
          get => datos_CAT_CONFLICTO_RUBRO.NID_RUBRO;
          set => datos_CAT_CONFLICTO_RUBRO.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
          get => datos_CAT_CONFLICTO_RUBRO.NID_RUBROs;
          set => datos_CAT_CONFLICTO_RUBRO.NID_RUBROs = value;
        }

        public StringFilter V_RUBRO
        {
          get => datos_CAT_CONFLICTO_RUBRO.V_RUBRO;
          set => datos_CAT_CONFLICTO_RUBRO.V_RUBRO = value;
        }
        public ListFilter<String> V_RUBROs
        {
          get => datos_CAT_CONFLICTO_RUBRO.V_RUBROs;
          set => datos_CAT_CONFLICTO_RUBRO.V_RUBROs = value;
        }

        public StringFilter C_INICIO
        {
          get => datos_CAT_CONFLICTO_RUBRO.C_INICIO;
          set => datos_CAT_CONFLICTO_RUBRO.C_INICIO = value;
        }
        public ListFilter<String> C_INICIOs
        {
          get => datos_CAT_CONFLICTO_RUBRO.C_INICIOs;
          set => datos_CAT_CONFLICTO_RUBRO.C_INICIOs = value;
        }

        public StringFilter C_FIN
        {
          get => datos_CAT_CONFLICTO_RUBRO.C_FIN;
          set => datos_CAT_CONFLICTO_RUBRO.C_FIN = value;
        }
        public ListFilter<String> C_FINs
        {
          get => datos_CAT_CONFLICTO_RUBRO.C_FINs;
          set => datos_CAT_CONFLICTO_RUBRO.C_FINs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_CONFLICTO_RUBRO.OrderByCriterios; 
            set => datos_CAT_CONFLICTO_RUBRO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_CONFLICTO_RUBRO() => datos_CAT_CONFLICTO_RUBRO = new dald__l_CAT_CONFLICTO_RUBRO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_CONFLICTO_RUBRO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_CONFLICTO_RUBRO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_CONFLICTO_RUBRO.single_select();
        }

     #endregion

    }
}
