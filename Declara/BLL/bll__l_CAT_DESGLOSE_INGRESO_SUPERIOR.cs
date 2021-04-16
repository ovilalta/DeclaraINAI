using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_DESGLOSE_INGRESO_SUPERIOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_DESGLOSE_INGRESO_SUPERIOR datos_CAT_DESGLOSE_INGRESO_SUPERIOR { get; set; }
        public List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO_SUPERIOR> lista_CAT_DESGLOSE_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.lista_CAT_DESGLOSE_INGRESO_SUPERIORs;
        protected List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR> base_CAT_DESGLOSE_INGRESO_SUPERIORs => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.base_CAT_DESGLOSE_INGRESO_SUPERIORs;

        public IntegerFilter NID_INGRESO_SUPERIOR
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR = value;
        }
        public ListFilter<Int32> NID_INGRESO_SUPERIORs
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIORs;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIORs = value;
        }

        public StringFilter V_INGRESO_SUPERIOR
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR = value;
        }
        public ListFilter<String> V_INGRESO_SUPERIORs
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIORs;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIORs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.OrderByCriterios;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_DESGLOSE_INGRESO_SUPERIOR() => datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald__l_CAT_DESGLOSE_INGRESO_SUPERIOR();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.single_select();
        }

        #endregion

    }
}
