using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_RELACION_TRANSMISOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_RELACION_TRANSMISOR datos_CAT_RELACION_TRANSMISOR { get; set; }
        public List<Declara_V2.MODELextended.CAT_RELACION_TRANSMISOR> lista_CAT_RELACION_TRANSMISOR => datos_CAT_RELACION_TRANSMISOR.lista_CAT_RELACION_TRANSMISORs;
        protected List<MODELDeclara_V2.CAT_RELACION_TRANSMISOR> base_CAT_RELACION_TRANSMISORs => datos_CAT_RELACION_TRANSMISOR.base_CAT_RELACION_TRANSMISORs;

        public IntegerFilter NID_RELACION_TRANSMISOR
        {
            get => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR;
            set => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR = value;
        }
        public ListFilter<Int32> NID_RELACION_TRANSMISORs
        {
            get => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISORs;
            set => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISORs = value;
        }

        public StringFilter V_RELACION_TRANSMISOR
        {
            get => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR;
            set => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR = value;
        }
        public ListFilter<String> V_RELACION_TRANSMISORs
        {
            get => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISORs;
            set => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISORs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_RELACION_TRANSMISOR.OrderByCriterios;
            set => datos_CAT_RELACION_TRANSMISOR.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_RELACION_TRANSMISOR() => datos_CAT_RELACION_TRANSMISOR = new dald__l_CAT_RELACION_TRANSMISOR();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_RELACION_TRANSMISOR.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_RELACION_TRANSMISOR.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_RELACION_TRANSMISOR.single_select();
        }

        #endregion

    }
}
