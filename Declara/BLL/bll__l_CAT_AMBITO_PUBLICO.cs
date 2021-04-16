using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_AMBITO_PUBLICO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_AMBITO_PUBLICO datos_CAT_AMBITO_PUBLICO { get; set; }
        public List<Declara_V2.MODELextended.CAT_AMBITO_PUBLICO> lista_CAT_AMBITO_PUBLICO => datos_CAT_AMBITO_PUBLICO.lista_CAT_AMBITO_PUBLICOs;
        protected List<MODELDeclara_V2.CAT_AMBITO_PUBLICO> base_CAT_AMBITO_PUBLICOs => datos_CAT_AMBITO_PUBLICO.base_CAT_AMBITO_PUBLICOs;

        public IntegerFilter NID_AMBITO_PUBLICO
        {
            get => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO;
            set => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO = value;
        }
        public ListFilter<Int32> NID_AMBITO_PUBLICOs
        {
            get => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICOs;
            set => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICOs = value;
        }

        public StringFilter V_AMBITO_PUBLICO
        {
            get => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;
            set => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO = value;
        }
        public ListFilter<String> V_AMBITO_PUBLICOs
        {
            get => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICOs;
            set => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_AMBITO_PUBLICO.OrderByCriterios;
            set => datos_CAT_AMBITO_PUBLICO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_AMBITO_PUBLICO() => datos_CAT_AMBITO_PUBLICO = new dald__l_CAT_AMBITO_PUBLICO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_AMBITO_PUBLICO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_AMBITO_PUBLICO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_AMBITO_PUBLICO.single_select();
        }

        #endregion

    }
}
