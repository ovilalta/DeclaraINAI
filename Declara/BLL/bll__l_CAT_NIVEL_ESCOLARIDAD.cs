using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_NIVEL_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_NIVEL_ESCOLARIDAD datos_CAT_NIVEL_ESCOLARIDAD { get; set; }
        public List<Declara_V2.MODELextended.CAT_NIVEL_ESCOLARIDAD> lista_CAT_NIVEL_ESCOLARIDAD => datos_CAT_NIVEL_ESCOLARIDAD.lista_CAT_NIVEL_ESCOLARIDADs;
        protected List<MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD> base_CAT_NIVEL_ESCOLARIDADs => datos_CAT_NIVEL_ESCOLARIDAD.base_CAT_NIVEL_ESCOLARIDADs;

        public IntegerFilter NID_NIVEL_ESCOLARIDAD
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
            set => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD = value;
        }
        public ListFilter<Int32> NID_NIVEL_ESCOLARIDADs
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDADs;
            set => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDADs = value;
        }

        public StringFilter V_NIVEL_ESCOLARIDAD
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD;
            set => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD = value;
        }
        public ListFilter<String> V_NIVEL_ESCOLARIDADs
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDADs;
            set => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDADs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.OrderByCriterios;
            set => datos_CAT_NIVEL_ESCOLARIDAD.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_NIVEL_ESCOLARIDAD() => datos_CAT_NIVEL_ESCOLARIDAD = new dald__l_CAT_NIVEL_ESCOLARIDAD();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.single_select();
        }

        #endregion

    }
}
