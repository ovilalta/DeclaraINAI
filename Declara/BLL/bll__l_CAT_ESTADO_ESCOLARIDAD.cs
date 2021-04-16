using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_ESTADO_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_ESTADO_ESCOLARIDAD datos_CAT_ESTADO_ESCOLARIDAD { get; set; }
        public List<Declara_V2.MODELextended.CAT_ESTADO_ESCOLARIDAD> lista_CAT_ESTADO_ESCOLARIDAD => datos_CAT_ESTADO_ESCOLARIDAD.lista_CAT_ESTADO_ESCOLARIDADs;
        protected List<MODELDeclara_V2.CAT_ESTADO_ESCOLARIDAD> base_CAT_ESTADO_ESCOLARIDADs => datos_CAT_ESTADO_ESCOLARIDAD.base_CAT_ESTADO_ESCOLARIDADs;

        public IntegerFilter NID_ESTADO_ESCOLARIDAD
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
            set => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD = value;
        }
        public ListFilter<Int32> NID_ESTADO_ESCOLARIDADs
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDADs;
            set => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDADs = value;
        }

        public StringFilter V_ESTADO_ESCOLARIDAD
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD;
            set => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD = value;
        }
        public ListFilter<String> V_ESTADO_ESCOLARIDADs
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDADs;
            set => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDADs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.OrderByCriterios;
            set => datos_CAT_ESTADO_ESCOLARIDAD.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_ESTADO_ESCOLARIDAD() => datos_CAT_ESTADO_ESCOLARIDAD = new dald__l_CAT_ESTADO_ESCOLARIDAD();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.single_select();
        }

        #endregion

    }
}
