using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_FORMA_PAGO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_FORMA_PAGO datos_CAT_FORMA_PAGO { get; set; }
        public List<Declara_V2.MODELextended.CAT_FORMA_PAGO> lista_CAT_FORMA_PAGO => datos_CAT_FORMA_PAGO.lista_CAT_FORMA_PAGOs;
        protected List<MODELDeclara_V2.CAT_FORMA_PAGO> base_CAT_FORMA_PAGOs => datos_CAT_FORMA_PAGO.base_CAT_FORMA_PAGOs;

        public IntegerFilter NID_FORMA_PAGO
        {
            get => datos_CAT_FORMA_PAGO.NID_FORMA_PAGO;
            set => datos_CAT_FORMA_PAGO.NID_FORMA_PAGO = value;
        }
        public ListFilter<Int32> NID_FORMA_PAGOs
        {
            get => datos_CAT_FORMA_PAGO.NID_FORMA_PAGOs;
            set => datos_CAT_FORMA_PAGO.NID_FORMA_PAGOs = value;
        }

        public StringFilter V_FORMA_PAGO
        {
            get => datos_CAT_FORMA_PAGO.V_FORMA_PAGO;
            set => datos_CAT_FORMA_PAGO.V_FORMA_PAGO = value;
        }
        public ListFilter<String> V_FORMA_PAGOs
        {
            get => datos_CAT_FORMA_PAGO.V_FORMA_PAGOs;
            set => datos_CAT_FORMA_PAGO.V_FORMA_PAGOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_FORMA_PAGO.OrderByCriterios;
            set => datos_CAT_FORMA_PAGO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_FORMA_PAGO() => datos_CAT_FORMA_PAGO = new dald__l_CAT_FORMA_PAGO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_FORMA_PAGO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_FORMA_PAGO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_FORMA_PAGO.single_select();
        }

        #endregion

    }
}
