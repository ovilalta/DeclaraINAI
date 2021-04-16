using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_FORMA_ADQUISICION : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_FORMA_ADQUISICION datos_CAT_FORMA_ADQUISICION { get; set; }
        public List<Declara_V2.MODELextended.CAT_FORMA_ADQUISICION> lista_CAT_FORMA_ADQUISICION => datos_CAT_FORMA_ADQUISICION.lista_CAT_FORMA_ADQUISICIONs;
        protected List<MODELDeclara_V2.CAT_FORMA_ADQUISICION> base_CAT_FORMA_ADQUISICIONs => datos_CAT_FORMA_ADQUISICION.base_CAT_FORMA_ADQUISICIONs;

        public IntegerFilter NID_FORMA_ADQUISICION
        {
            get => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICION;
            set => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICION = value;
        }
        public ListFilter<Int32> NID_FORMA_ADQUISICIONs
        {
            get => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICIONs;
            set => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICIONs = value;
        }

        public StringFilter V_FORMA_ADQUISICION
        {
            get => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION;
            set => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION = value;
        }
        public ListFilter<String> V_FORMA_ADQUISICIONs
        {
            get => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICIONs;
            set => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICIONs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_FORMA_ADQUISICION.OrderByCriterios;
            set => datos_CAT_FORMA_ADQUISICION.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_FORMA_ADQUISICION() => datos_CAT_FORMA_ADQUISICION = new dald__l_CAT_FORMA_ADQUISICION();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_FORMA_ADQUISICION.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_FORMA_ADQUISICION.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_FORMA_ADQUISICION.single_select();
        }

        #endregion

    }
}
