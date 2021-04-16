using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_APARTADO : _bllSistema
    {

        internal dald__l_CAT_APARTADO datos_CAT_APARTADO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_APARTADO> lista_CAT_APARTADO => datos_CAT_APARTADO.lista_CAT_APARTADOs;

        protected List<MODELDeclara_V2.CAT_APARTADO>  base_CAT_APARTADOs => datos_CAT_APARTADO.base_CAT_APARTADOs;

        public IntegerFilter NID_APARTADO
        {
          get => datos_CAT_APARTADO.NID_APARTADO;
          set => datos_CAT_APARTADO.NID_APARTADO = value;
        }
        public ListFilter<Int32> NID_APARTADOs
        {
          get => datos_CAT_APARTADO.NID_APARTADOs;
          set => datos_CAT_APARTADO.NID_APARTADOs = value;
        }

        public StringFilter V_APARTADO
        {
          get => datos_CAT_APARTADO.V_APARTADO;
          set => datos_CAT_APARTADO.V_APARTADO = value;
        }
        public ListFilter<String> V_APARTADOs
        {
          get => datos_CAT_APARTADO.V_APARTADOs;
          set => datos_CAT_APARTADO.V_APARTADOs = value;
        }

        public IntegerFilter NID_APARTADO_SUPERIOR
        {
          get => datos_CAT_APARTADO.NID_APARTADO_SUPERIOR;
          set => datos_CAT_APARTADO.NID_APARTADO_SUPERIOR = value;
        }
        public ListFilter<Int32> NID_APARTADO_SUPERIORs
        {
          get => datos_CAT_APARTADO.NID_APARTADO_SUPERIORs;
          set => datos_CAT_APARTADO.NID_APARTADO_SUPERIORs = value;
        }

        public IntegerFilter N_APARTADO
        {
          get => datos_CAT_APARTADO.N_APARTADO;
          set => datos_CAT_APARTADO.N_APARTADO = value;
        }
        public ListFilter<Int32> N_APARTADOs
        {
          get => datos_CAT_APARTADO.N_APARTADOs;
          set => datos_CAT_APARTADO.N_APARTADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_APARTADO.OrderByCriterios; 
            set => datos_CAT_APARTADO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_APARTADO() => datos_CAT_APARTADO = new dald__l_CAT_APARTADO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_APARTADO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_APARTADO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_APARTADO.single_select();
        }

     #endregion

    }
}
