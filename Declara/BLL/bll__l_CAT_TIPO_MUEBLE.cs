using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_MUEBLE : _bllSistema
    {

        internal dald__l_CAT_TIPO_MUEBLE datos_CAT_TIPO_MUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_MUEBLE> lista_CAT_TIPO_MUEBLE => datos_CAT_TIPO_MUEBLE.lista_CAT_TIPO_MUEBLEs;

        protected List<MODELDeclara_V2.CAT_TIPO_MUEBLE>  base_CAT_TIPO_MUEBLEs => datos_CAT_TIPO_MUEBLE.base_CAT_TIPO_MUEBLEs;

        public IntegerFilter NID_TIPO
        {
          get => datos_CAT_TIPO_MUEBLE.NID_TIPO;
          set => datos_CAT_TIPO_MUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
          get => datos_CAT_TIPO_MUEBLE.NID_TIPOs;
          set => datos_CAT_TIPO_MUEBLE.NID_TIPOs = value;
        }

        public StringFilter V_TIPO
        {
          get => datos_CAT_TIPO_MUEBLE.V_TIPO;
          set => datos_CAT_TIPO_MUEBLE.V_TIPO = value;
        }
        public ListFilter<String> V_TIPOs
        {
          get => datos_CAT_TIPO_MUEBLE.V_TIPOs;
          set => datos_CAT_TIPO_MUEBLE.V_TIPOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_TIPO_MUEBLE.L_ACTIVO;
          set => datos_CAT_TIPO_MUEBLE.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_TIPO_MUEBLE.L_ACTIVOs;
          set => datos_CAT_TIPO_MUEBLE.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_MUEBLE.OrderByCriterios; 
            set => datos_CAT_TIPO_MUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_MUEBLE() => datos_CAT_TIPO_MUEBLE = new dald__l_CAT_TIPO_MUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_MUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_MUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_MUEBLE.single_select();
        }

     #endregion

    }
}
