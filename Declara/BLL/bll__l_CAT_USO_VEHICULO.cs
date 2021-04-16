using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_USO_VEHICULO : _bllSistema
    {

        internal dald__l_CAT_USO_VEHICULO datos_CAT_USO_VEHICULO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_USO_VEHICULO> lista_CAT_USO_VEHICULO => datos_CAT_USO_VEHICULO.lista_CAT_USO_VEHICULOs;

        protected List<MODELDeclara_V2.CAT_USO_VEHICULO>  base_CAT_USO_VEHICULOs => datos_CAT_USO_VEHICULO.base_CAT_USO_VEHICULOs;

        public IntegerFilter NID_USO
        {
          get => datos_CAT_USO_VEHICULO.NID_USO;
          set => datos_CAT_USO_VEHICULO.NID_USO = value;
        }
        public ListFilter<Int32> NID_USOs
        {
          get => datos_CAT_USO_VEHICULO.NID_USOs;
          set => datos_CAT_USO_VEHICULO.NID_USOs = value;
        }

        public StringFilter V_USO
        {
          get => datos_CAT_USO_VEHICULO.V_USO;
          set => datos_CAT_USO_VEHICULO.V_USO = value;
        }
        public ListFilter<String> V_USOs
        {
          get => datos_CAT_USO_VEHICULO.V_USOs;
          set => datos_CAT_USO_VEHICULO.V_USOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_USO_VEHICULO.L_ACTIVO;
          set => datos_CAT_USO_VEHICULO.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_USO_VEHICULO.L_ACTIVOs;
          set => datos_CAT_USO_VEHICULO.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_USO_VEHICULO.OrderByCriterios; 
            set => datos_CAT_USO_VEHICULO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_USO_VEHICULO() => datos_CAT_USO_VEHICULO = new dald__l_CAT_USO_VEHICULO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_USO_VEHICULO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_USO_VEHICULO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_USO_VEHICULO.single_select();
        }

     #endregion

    }
}
