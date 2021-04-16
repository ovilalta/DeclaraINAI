using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_BIEN_ENAJENADO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_BIEN_ENAJENADO datos_CAT_BIEN_ENAJENADO { get; set; }
        public List<Declara_V2.MODELextended.CAT_BIEN_ENAJENADO> lista_CAT_BIEN_ENAJENADO => datos_CAT_BIEN_ENAJENADO.lista_CAT_BIEN_ENAJENADOs;
        protected List<MODELDeclara_V2.CAT_BIEN_ENAJENADO> base_CAT_BIEN_ENAJENADOs => datos_CAT_BIEN_ENAJENADO.base_CAT_BIEN_ENAJENADOs;

        public IntegerFilter NID_BIEN_ENAJENADO
        {
            get => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO;
            set => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO = value;
        }
        public ListFilter<Int32> NID_BIEN_ENAJENADOs
        {
            get => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADOs;
            set => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADOs = value;
        }

        public StringFilter V_BIEN_ENAJENADO
        {
            get => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO;
            set => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO = value;
        }
        public ListFilter<String> V_BIEN_ENAJENADOs
        {
            get => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADOs;
            set => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_BIEN_ENAJENADO.OrderByCriterios;
            set => datos_CAT_BIEN_ENAJENADO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_BIEN_ENAJENADO() => datos_CAT_BIEN_ENAJENADO = new dald__l_CAT_BIEN_ENAJENADO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_BIEN_ENAJENADO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_BIEN_ENAJENADO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_BIEN_ENAJENADO.single_select();
        }

        #endregion

    }
}
