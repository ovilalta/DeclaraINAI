using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_PUESTO : _bllSistema
    {

        internal dald__l_CAT_PUESTO datos_CAT_PUESTO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_PUESTO> lista_CAT_PUESTO => datos_CAT_PUESTO.lista_CAT_PUESTOs;

        protected List<MODELDeclara_V2.CAT_PUESTO>  base_CAT_PUESTOs => datos_CAT_PUESTO.base_CAT_PUESTOs;

        public IntegerFilter NID_PUESTO
        {
          get => datos_CAT_PUESTO.NID_PUESTO;
          set => datos_CAT_PUESTO.NID_PUESTO = value;
        }
        public ListFilter<Int32> NID_PUESTOs
        {
          get => datos_CAT_PUESTO.NID_PUESTOs;
          set => datos_CAT_PUESTO.NID_PUESTOs = value;
        }

        public StringFilter VID_PUESTO
        {
          get => datos_CAT_PUESTO.VID_PUESTO;
          set => datos_CAT_PUESTO.VID_PUESTO = value;
        }
        public ListFilter<String> VID_PUESTOs
        {
          get => datos_CAT_PUESTO.VID_PUESTOs;
          set => datos_CAT_PUESTO.VID_PUESTOs = value;
        }

        public StringFilter VID_NIVEL
        {
          get => datos_CAT_PUESTO.VID_NIVEL;
          set => datos_CAT_PUESTO.VID_NIVEL = value;
        }
        public ListFilter<String> VID_NIVELs
        {
          get => datos_CAT_PUESTO.VID_NIVELs;
          set => datos_CAT_PUESTO.VID_NIVELs = value;
        }

        public StringFilter V_PUESTO
        {
          get => datos_CAT_PUESTO.V_PUESTO;
          set => datos_CAT_PUESTO.V_PUESTO = value;
        }
        public ListFilter<String> V_PUESTOs
        {
          get => datos_CAT_PUESTO.V_PUESTOs;
          set => datos_CAT_PUESTO.V_PUESTOs = value;
        }

        public StringFilter NOMBRE_UA
        {
            get => datos_CAT_PUESTO.NOMBRE_UA;
            set => datos_CAT_PUESTO.NOMBRE_UA = value;

        }
        public ListFilter<String> NOMBRE_UAs
        {
            get => datos_CAT_PUESTO.NOMBRE_UAs;
            set => datos_CAT_PUESTO.NOMBRE_UAs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_PUESTO.L_ACTIVO;
          set => datos_CAT_PUESTO.L_ACTIVO = value;
        }
       
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_PUESTO.L_ACTIVOs;
          set => datos_CAT_PUESTO.L_ACTIVOs = value;
        }

        public System.Nullable<Boolean> L_OBLIGADO
        {
            get => datos_CAT_PUESTO.L_OBLIGADO;
            set => datos_CAT_PUESTO.L_OBLIGADO = value;
        }

        public ListFilter<Boolean> L_OBLIGADOs
        {
            get => datos_CAT_PUESTO.L_OBLIGADOs;
            set => datos_CAT_PUESTO.L_OBLIGADOs = value;
        }
        public List<Order> OrderByCriterios
        {
            get => datos_CAT_PUESTO.OrderByCriterios; 
            set => datos_CAT_PUESTO.OrderByCriterios = value; 
        }


      

        #endregion


        #region *** Constructores ***

        public bll__l_CAT_PUESTO() => datos_CAT_PUESTO = new dald__l_CAT_PUESTO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_PUESTO.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_PUESTO.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_PUESTO.single_select();
        }

     #endregion

    }
}
