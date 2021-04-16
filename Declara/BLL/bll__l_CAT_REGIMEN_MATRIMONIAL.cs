using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_REGIMEN_MATRIMONIAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_REGIMEN_MATRIMONIAL datos_CAT_REGIMEN_MATRIMONIAL { get; set; }
        public List<Declara_V2.MODELextended.CAT_REGIMEN_MATRIMONIAL> lista_CAT_REGIMEN_MATRIMONIAL => datos_CAT_REGIMEN_MATRIMONIAL.lista_CAT_REGIMEN_MATRIMONIALs;
        protected List<MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL> base_CAT_REGIMEN_MATRIMONIALs => datos_CAT_REGIMEN_MATRIMONIAL.base_CAT_REGIMEN_MATRIMONIALs;

        public IntegerFilter NID_REGIMEN_MATRIMONIAL
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
            set => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL = value;
        }
        public ListFilter<Int32> NID_REGIMEN_MATRIMONIALs
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIALs;
            set => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIALs = value;
        }

        public StringFilter V_REGIMEN_MATRIMONIAL
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL;
            set => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL = value;
        }
        public ListFilter<String> V_REGIMEN_MATRIMONIALs
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIALs;
            set => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIALs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.OrderByCriterios;
            set => datos_CAT_REGIMEN_MATRIMONIAL.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_REGIMEN_MATRIMONIAL() => datos_CAT_REGIMEN_MATRIMONIAL = new dald__l_CAT_REGIMEN_MATRIMONIAL();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.single_select();
        }

        #endregion

    }
}
