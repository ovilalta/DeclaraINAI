using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_CAT_INSTRUMENTO_RENDIMIENTO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_CAT_INSTRUMENTO_RENDIMIENTO datos_CAT_INSTRUMENTO_RENDIMIENTO { get; set; }
        public List<Declara_V2.MODELextended.CAT_INSTRUMENTO_RENDIMIENTO> lista_CAT_INSTRUMENTO_RENDIMIENTO => datos_CAT_INSTRUMENTO_RENDIMIENTO.lista_CAT_INSTRUMENTO_RENDIMIENTOs;
        protected List<MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO> base_CAT_INSTRUMENTO_RENDIMIENTOs => datos_CAT_INSTRUMENTO_RENDIMIENTO.base_CAT_INSTRUMENTO_RENDIMIENTOs;

        public IntegerFilter NID_INSTRUMENTO_RENDIMIENTO
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO = value;
        }
        public ListFilter<Int32> NID_INSTRUMENTO_RENDIMIENTOs
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTOs;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTOs = value;
        }

        public StringFilter V_INSTRUMENTO_RENDIMIENTO
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTO = value;
        }
        public ListFilter<String> V_INSTRUMENTO_RENDIMIENTOs
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTOs;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.V_INSTRUMENTO_RENDIMIENTOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_CAT_INSTRUMENTO_RENDIMIENTO.OrderByCriterios;
            set => datos_CAT_INSTRUMENTO_RENDIMIENTO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_CAT_INSTRUMENTO_RENDIMIENTO() => datos_CAT_INSTRUMENTO_RENDIMIENTO = new dald__l_CAT_INSTRUMENTO_RENDIMIENTO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.select();
        }
        public void clearOrderBy()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.clearOrderBy();
        }
        public void single_select()
        {
            datos_CAT_INSTRUMENTO_RENDIMIENTO.single_select();
        }

        #endregion

    }
}
