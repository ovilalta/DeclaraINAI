using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_DESGLOSE_INGRESO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_DESGLOSE_INGRESO datos_CAT_DESGLOSE_INGRESO { get; set; }
        public List<Declara_V2.MODELextended.CAT_DESGLOSE_INGRESO> lista_CAT_DESGLOSE_INGRESO => datos_CAT_DESGLOSE_INGRESO.lista_CAT_DESGLOSE_INGRESOs;
        protected List<MODELDeclara_V2.CAT_DESGLOSE_INGRESO> base_CAT_DESGLOSE_INGRESOs => datos_CAT_DESGLOSE_INGRESO.base_CAT_DESGLOSE_INGRESOs;

        public IntegerFilter NID_INGRESO_SUPERIOR
        {
            get => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR;
            set => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR = value;
        }
        public ListFilter<Int32> NID_INGRESO_SUPERIORs
        {
            get => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIORs;
            set => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIORs = value;
        }

        public IntegerFilter NID_INGRESO
        {
            get => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO;
            set => datos_CAT_DESGLOSE_INGRESO.NID_INGRESO = value;
        }
        public ListFilter<Int32> NID_INGRESOs
        {
            get => datos_CAT_DESGLOSE_INGRESO.NID_INGRESOs;
            set => datos_CAT_DESGLOSE_INGRESO.NID_INGRESOs = value;
        }

        public StringFilter V_INGRESO
        {
            get => datos_CAT_DESGLOSE_INGRESO.V_INGRESO;
            set => datos_CAT_DESGLOSE_INGRESO.V_INGRESO = value;
        }
        public ListFilter<String> V_INGRESOs
        {
            get => datos_CAT_DESGLOSE_INGRESO.V_INGRESOs;
            set => datos_CAT_DESGLOSE_INGRESO.V_INGRESOs = value;
        }

        public System.Nullable<Boolean> L_VIGENTE
        {
            get => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE;
            set => datos_CAT_DESGLOSE_INGRESO.L_VIGENTE = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_DESGLOSE_INGRESO.OrderByCriterios;
            set => datos_CAT_DESGLOSE_INGRESO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_DESGLOSE_INGRESO() => datos_CAT_DESGLOSE_INGRESO = new dald__l_CAT_DESGLOSE_INGRESO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_DESGLOSE_INGRESO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_DESGLOSE_INGRESO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_DESGLOSE_INGRESO.single_select();
        }

        #endregion

    }
}
