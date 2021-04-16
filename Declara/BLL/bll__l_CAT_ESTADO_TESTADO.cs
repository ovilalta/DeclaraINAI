using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_ESTADO_TESTADO : _bllSistema
    {

        internal dald__l_CAT_ESTADO_TESTADO datos_CAT_ESTADO_TESTADO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_ESTADO_TESTADO> lista_CAT_ESTADO_TESTADO => datos_CAT_ESTADO_TESTADO.lista_CAT_ESTADO_TESTADOs;

        protected List<MODELDeclara_V2.CAT_ESTADO_TESTADO>  base_CAT_ESTADO_TESTADOs => datos_CAT_ESTADO_TESTADO.base_CAT_ESTADO_TESTADOs;

        public IntegerFilter NID_ESTADO_TESTADO
        {
          get => datos_CAT_ESTADO_TESTADO.NID_ESTADO_TESTADO;
          set => datos_CAT_ESTADO_TESTADO.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
          get => datos_CAT_ESTADO_TESTADO.NID_ESTADO_TESTADOs;
          set => datos_CAT_ESTADO_TESTADO.NID_ESTADO_TESTADOs = value;
        }

        public StringFilter V_ESTADO_TESTADO
        {
          get => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADO;
          set => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADO = value;
        }
        public ListFilter<String> V_ESTADO_TESTADOs
        {
          get => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADOs;
          set => datos_CAT_ESTADO_TESTADO.V_ESTADO_TESTADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ESTADO_TESTADO.OrderByCriterios; 
            set => datos_CAT_ESTADO_TESTADO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_ESTADO_TESTADO() => datos_CAT_ESTADO_TESTADO = new dald__l_CAT_ESTADO_TESTADO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_ESTADO_TESTADO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_ESTADO_TESTADO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_ESTADO_TESTADO.single_select();
        }

     #endregion

    }
}
