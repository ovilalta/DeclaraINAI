using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_AMBITO_SECTOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_AMBITO_SECTOR datos_CAT_AMBITO_SECTOR { get; set; }
        public List<Declara_V2.MODELextended.CAT_AMBITO_SECTOR> lista_CAT_AMBITO_SECTOR => datos_CAT_AMBITO_SECTOR.lista_CAT_AMBITO_SECTORs;
        protected List<MODELDeclara_V2.CAT_AMBITO_SECTOR> base_CAT_AMBITO_SECTORs => datos_CAT_AMBITO_SECTOR.base_CAT_AMBITO_SECTORs;

        public IntegerFilter NID_AMBITO_SECTOR
        {
            get => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTOR;
            set => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTOR = value;
        }
        public ListFilter<Int32> NID_AMBITO_SECTORs
        {
            get => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTORs;
            set => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTORs = value;
        }

        public StringFilter V_AMBITO_SECTOR
        {
            get => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR;
            set => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR = value;
        }
        public ListFilter<String> V_AMBITO_SECTORs
        {
            get => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTORs;
            set => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTORs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_AMBITO_SECTOR.OrderByCriterios;
            set => datos_CAT_AMBITO_SECTOR.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_AMBITO_SECTOR() => datos_CAT_AMBITO_SECTOR = new dald__l_CAT_AMBITO_SECTOR();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_AMBITO_SECTOR.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_AMBITO_SECTOR.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_AMBITO_SECTOR.single_select();
        }

        #endregion

    }
}
