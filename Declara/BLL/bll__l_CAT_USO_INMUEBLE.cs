using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_USO_INMUEBLE : _bllSistema
    {

        internal dald__l_CAT_USO_INMUEBLE datos_CAT_USO_INMUEBLE;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_USO_INMUEBLE> lista_CAT_USO_INMUEBLE => datos_CAT_USO_INMUEBLE.lista_CAT_USO_INMUEBLEs;

        protected List<MODELDeclara_V2.CAT_USO_INMUEBLE>  base_CAT_USO_INMUEBLEs => datos_CAT_USO_INMUEBLE.base_CAT_USO_INMUEBLEs;

        public IntegerFilter NID_USO
        {
          get => datos_CAT_USO_INMUEBLE.NID_USO;
          set => datos_CAT_USO_INMUEBLE.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_CAT_USO_INMUEBLE.NID_USOs;
          set => datos_CAT_USO_INMUEBLE.NID_USOs = value;
        }

        public StringFilter V_USO
        {
          get => datos_CAT_USO_INMUEBLE.V_USO;
          set => datos_CAT_USO_INMUEBLE.V_USO = value;
        }
        public ListFilter<String> V_USOs
        {
          get => datos_CAT_USO_INMUEBLE.V_USOs;
          set => datos_CAT_USO_INMUEBLE.V_USOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_USO_INMUEBLE.L_ACTIVO;
          set => datos_CAT_USO_INMUEBLE.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_USO_INMUEBLE.L_ACTIVOs;
          set => datos_CAT_USO_INMUEBLE.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_USO_INMUEBLE.OrderByCriterios; 
            set => datos_CAT_USO_INMUEBLE.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_USO_INMUEBLE() => datos_CAT_USO_INMUEBLE = new dald__l_CAT_USO_INMUEBLE();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_USO_INMUEBLE.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_USO_INMUEBLE.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_USO_INMUEBLE.single_select();
        }

     #endregion

    }
}
