using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_TITULAR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_TITULAR datos_CAT_TITULAR { get; set; }
        public List<Declara_V2.MODELextended.CAT_TITULAR> lista_CAT_TITULAR => datos_CAT_TITULAR.lista_CAT_TITULARs;
        protected List<MODELDeclara_V2.CAT_TITULAR> base_CAT_TITULARs => datos_CAT_TITULAR.base_CAT_TITULARs;

        public IntegerFilter NID_TITULAR
        {
            get => datos_CAT_TITULAR.NID_TITULAR;
            set => datos_CAT_TITULAR.NID_TITULAR = value;
        }
        public ListFilter<Int32> NID_TITULARs
        {
            get => datos_CAT_TITULAR.NID_TITULARs;
            set => datos_CAT_TITULAR.NID_TITULARs = value;
        }

        public StringFilter V_TITULAR
        {
            get => datos_CAT_TITULAR.V_TITULAR;
            set => datos_CAT_TITULAR.V_TITULAR = value;
        }
        public ListFilter<String> V_TITULARs
        {
            get => datos_CAT_TITULAR.V_TITULARs;
            set => datos_CAT_TITULAR.V_TITULARs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TITULAR.OrderByCriterios;
            set => datos_CAT_TITULAR.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_TITULAR() => datos_CAT_TITULAR = new dald__l_CAT_TITULAR();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_TITULAR.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_TITULAR.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_TITULAR.single_select();
        }

        #endregion

    }
}
