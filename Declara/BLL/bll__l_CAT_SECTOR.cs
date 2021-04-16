using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_SECTOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_SECTOR datos_CAT_SECTOR { get; set; }
        public List<Declara_V2.MODELextended.CAT_SECTOR> lista_CAT_SECTOR => datos_CAT_SECTOR.lista_CAT_SECTORs;
        protected List<MODELDeclara_V2.CAT_SECTOR> base_CAT_SECTORs => datos_CAT_SECTOR.base_CAT_SECTORs;

        public IntegerFilter NID_SECTOR
        {
            get => datos_CAT_SECTOR.NID_SECTOR;
            set => datos_CAT_SECTOR.NID_SECTOR = value;
        }
        public ListFilter<Int32> NID_SECTORs
        {
            get => datos_CAT_SECTOR.NID_SECTORs;
            set => datos_CAT_SECTOR.NID_SECTORs = value;
        }

        public StringFilter V_SECTOR
        {
            get => datos_CAT_SECTOR.V_SECTOR;
            set => datos_CAT_SECTOR.V_SECTOR = value;
        }
        public ListFilter<String> V_SECTORs
        {
            get => datos_CAT_SECTOR.V_SECTORs;
            set => datos_CAT_SECTOR.V_SECTORs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_SECTOR.OrderByCriterios;
            set => datos_CAT_SECTOR.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_SECTOR() => datos_CAT_SECTOR = new dald__l_CAT_SECTOR();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_SECTOR.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_SECTOR.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_SECTOR.single_select();
        }

        #endregion

    }
}
