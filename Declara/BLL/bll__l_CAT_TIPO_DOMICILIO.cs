using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_DOMICILIO : _bllSistema
    {

        internal dald__l_CAT_TIPO_DOMICILIO datos_CAT_TIPO_DOMICILIO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_DOMICILIO> lista_CAT_TIPO_DOMICILIO => datos_CAT_TIPO_DOMICILIO.lista_CAT_TIPO_DOMICILIOs;

        protected List<MODELDeclara_V2.CAT_TIPO_DOMICILIO>  base_CAT_TIPO_DOMICILIOs => datos_CAT_TIPO_DOMICILIO.base_CAT_TIPO_DOMICILIOs;

        public IntegerFilter NID_TIPO_DOMICILIO
        {
          get => datos_CAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO;
          set => datos_CAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO = value;
        }
        public ListFilter<Int32> NID_TIPO_DOMICILIOs
        {
          get => datos_CAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIOs;
          set => datos_CAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIOs = value;
        }

        public StringFilter V_TIPO_DOMICILIO
        {
          get => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO;
          set => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO = value;
        }
        public ListFilter<String> V_TIPO_DOMICILIOs
        {
          get => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIOs;
          set => datos_CAT_TIPO_DOMICILIO.V_TIPO_DOMICILIOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_DOMICILIO.OrderByCriterios; 
            set => datos_CAT_TIPO_DOMICILIO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_DOMICILIO() => datos_CAT_TIPO_DOMICILIO = new dald__l_CAT_TIPO_DOMICILIO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_DOMICILIO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_DOMICILIO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_DOMICILIO.single_select();
        }

     #endregion

    }
}
