using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_VALOR_ADQUISICION : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_VALOR_ADQUISICION datos_CAT_VALOR_ADQUISICION { get; set; }
        public List<Declara_V2.MODELextended.CAT_VALOR_ADQUISICION> lista_CAT_VALOR_ADQUISICION => datos_CAT_VALOR_ADQUISICION.lista_CAT_VALOR_ADQUISICIONs;
        protected List<MODELDeclara_V2.CAT_VALOR_ADQUISICION> base_CAT_VALOR_ADQUISICIONs => datos_CAT_VALOR_ADQUISICION.base_CAT_VALOR_ADQUISICIONs;

        public IntegerFilter NID_VALOR_ADQUISICION
        {
            get => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICION;
            set => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICION = value;
        }
        public ListFilter<Int32> NID_VALOR_ADQUISICIONs
        {
            get => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICIONs;
            set => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICIONs = value;
        }

        public StringFilter V_VALOR_ADQUISICION
        {
            get => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION;
            set => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION = value;
        }
        public ListFilter<String> V_VALOR_ADQUISICIONs
        {
            get => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICIONs;
            set => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICIONs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_VALOR_ADQUISICION.OrderByCriterios;
            set => datos_CAT_VALOR_ADQUISICION.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_VALOR_ADQUISICION() => datos_CAT_VALOR_ADQUISICION = new dald__l_CAT_VALOR_ADQUISICION();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_VALOR_ADQUISICION.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_VALOR_ADQUISICION.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_VALOR_ADQUISICION.single_select();
        }

        #endregion

    }
}
