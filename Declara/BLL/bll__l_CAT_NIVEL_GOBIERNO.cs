using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_NIVEL_GOBIERNO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_NIVEL_GOBIERNO datos_CAT_NIVEL_GOBIERNO { get; set; }
        public List<Declara_V2.MODELextended.CAT_NIVEL_GOBIERNO> lista_CAT_NIVEL_GOBIERNO => datos_CAT_NIVEL_GOBIERNO.lista_CAT_NIVEL_GOBIERNOs;
        protected List<MODELDeclara_V2.CAT_NIVEL_GOBIERNO> base_CAT_NIVEL_GOBIERNOs => datos_CAT_NIVEL_GOBIERNO.base_CAT_NIVEL_GOBIERNOs;

        public IntegerFilter NID_NIVEL_GOBIERNO
        {
            get => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO;
            set => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO = value;
        }
        public ListFilter<Int32> NID_NIVEL_GOBIERNOs
        {
            get => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNOs;
            set => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNOs = value;
        }

        public StringFilter V_NIVEL_GOBIERNO
        {
            get => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
            set => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO = value;
        }
        public ListFilter<String> V_NIVEL_GOBIERNOs
        {
            get => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNOs;
            set => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_NIVEL_GOBIERNO.OrderByCriterios;
            set => datos_CAT_NIVEL_GOBIERNO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_NIVEL_GOBIERNO() => datos_CAT_NIVEL_GOBIERNO = new dald__l_CAT_NIVEL_GOBIERNO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_NIVEL_GOBIERNO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_NIVEL_GOBIERNO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_NIVEL_GOBIERNO.single_select();
        }

        #endregion

    }
}
