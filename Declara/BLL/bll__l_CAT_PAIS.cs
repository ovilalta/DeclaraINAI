using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_PAIS : _bllSistema
    {

        internal dald__l_CAT_PAIS datos_CAT_PAIS;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_PAIS> lista_CAT_PAIS => datos_CAT_PAIS.lista_CAT_PAISs;

        protected List<MODELDeclara_V2.CAT_PAIS>  base_CAT_PAISs => datos_CAT_PAIS.base_CAT_PAISs;

        public IntegerFilter NID_PAIS
        {
          get => datos_CAT_PAIS.NID_PAIS;
          set => datos_CAT_PAIS.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
          get => datos_CAT_PAIS.NID_PAISs;
          set => datos_CAT_PAIS.NID_PAISs = value;
        }

        public StringFilter V_PAIS
        {
          get => datos_CAT_PAIS.V_PAIS;
          set => datos_CAT_PAIS.V_PAIS = value;
        }
        public ListFilter<String> V_PAISs
        {
          get => datos_CAT_PAIS.V_PAISs;
          set => datos_CAT_PAIS.V_PAISs = value;
        }

        public StringFilter V_NACIONALIDAD_M
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_M;
          set => datos_CAT_PAIS.V_NACIONALIDAD_M = value;
        }
        public ListFilter<String> V_NACIONALIDAD_Ms
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_Ms;
          set => datos_CAT_PAIS.V_NACIONALIDAD_Ms = value;
        }

        public StringFilter V_NACIONALIDAD_F
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_F;
          set => datos_CAT_PAIS.V_NACIONALIDAD_F = value;
        }
        public ListFilter<String> V_NACIONALIDAD_Fs
        {
          get => datos_CAT_PAIS.V_NACIONALIDAD_Fs;
          set => datos_CAT_PAIS.V_NACIONALIDAD_Fs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_PAIS.OrderByCriterios; 
            set => datos_CAT_PAIS.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_PAIS() => datos_CAT_PAIS = new dald__l_CAT_PAIS();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_PAIS.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_PAIS.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_PAIS.single_select();
        }

     #endregion

    }
}
