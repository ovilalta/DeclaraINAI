using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_INMUEBLE : _bllSistema
    {

        internal dald__l_CAT_TIPO_INMUEBLE datos_CAT_TIPO_INMUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_INMUEBLE> lista_CAT_TIPO_INMUEBLE => datos_CAT_TIPO_INMUEBLE.lista_CAT_TIPO_INMUEBLEs;

        protected List<MODELDeclara_V2.CAT_TIPO_INMUEBLE>  base_CAT_TIPO_INMUEBLEs => datos_CAT_TIPO_INMUEBLE.base_CAT_TIPO_INMUEBLEs;

        public IntegerFilter NID_TIPO
        {
          get => datos_CAT_TIPO_INMUEBLE.NID_TIPO;
          set => datos_CAT_TIPO_INMUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_CAT_TIPO_INMUEBLE.NID_TIPOs;
          set => datos_CAT_TIPO_INMUEBLE.NID_TIPOs = value;
        }

        public StringFilter V_TIPO
        {
          get => datos_CAT_TIPO_INMUEBLE.V_TIPO;
          set => datos_CAT_TIPO_INMUEBLE.V_TIPO = value;
        }
        public ListFilter<String> V_TIPOs
        {
          get => datos_CAT_TIPO_INMUEBLE.V_TIPOs;
          set => datos_CAT_TIPO_INMUEBLE.V_TIPOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_TIPO_INMUEBLE.L_ACTIVO;
          set => datos_CAT_TIPO_INMUEBLE.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_TIPO_INMUEBLE.L_ACTIVOs;
          set => datos_CAT_TIPO_INMUEBLE.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_INMUEBLE.OrderByCriterios; 
            set => datos_CAT_TIPO_INMUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_INMUEBLE() => datos_CAT_TIPO_INMUEBLE = new dald__l_CAT_TIPO_INMUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_INMUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_INMUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_INMUEBLE.single_select();
        }

     #endregion

    }
}
