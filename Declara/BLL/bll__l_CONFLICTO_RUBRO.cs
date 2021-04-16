using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CONFLICTO_RUBRO : _bllSistema
    {

        internal dald__l_CONFLICTO_RUBRO datos_CONFLICTO_RUBRO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CONFLICTO_RUBRO> lista_CONFLICTO_RUBRO => datos_CONFLICTO_RUBRO.lista_CONFLICTO_RUBROs;

        protected List<MODELDeclara_V2.CONFLICTO_RUBRO>  base_CONFLICTO_RUBROs => datos_CONFLICTO_RUBRO.base_CONFLICTO_RUBROs;

        public StringFilter VID_NOMBRE
        {
          get => datos_CONFLICTO_RUBRO.VID_NOMBRE;
          set => datos_CONFLICTO_RUBRO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_CONFLICTO_RUBRO.VID_NOMBREs;
          set => datos_CONFLICTO_RUBRO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_CONFLICTO_RUBRO.VID_FECHA;
          set => datos_CONFLICTO_RUBRO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_CONFLICTO_RUBRO.VID_FECHAs;
          set => datos_CONFLICTO_RUBRO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_CONFLICTO_RUBRO.VID_HOMOCLAVE;
          set => datos_CONFLICTO_RUBRO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_CONFLICTO_RUBRO.VID_HOMOCLAVEs;
          set => datos_CONFLICTO_RUBRO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_CONFLICTO
        {
          get => datos_CONFLICTO_RUBRO.NID_CONFLICTO;
          set => datos_CONFLICTO_RUBRO.NID_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_CONFLICTOs
        {
          get => datos_CONFLICTO_RUBRO.NID_CONFLICTOs;
          set => datos_CONFLICTO_RUBRO.NID_CONFLICTOs = value;
        }

        public IntegerFilter NID_RUBRO
        {
          get => datos_CONFLICTO_RUBRO.NID_RUBRO;
          set => datos_CONFLICTO_RUBRO.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
          get => datos_CONFLICTO_RUBRO.NID_RUBROs;
          set => datos_CONFLICTO_RUBRO.NID_RUBROs = value;
        }

        public System.Nullable<Boolean> L_RESPUESTA
        {
          get => datos_CONFLICTO_RUBRO.L_RESPUESTA;
          set => datos_CONFLICTO_RUBRO.L_RESPUESTA = value;
        }
        public ListFilter<Boolean> L_RESPUESTAs
        {
          get => datos_CONFLICTO_RUBRO.L_RESPUESTAs;
          set => datos_CONFLICTO_RUBRO.L_RESPUESTAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CONFLICTO_RUBRO.OrderByCriterios; 
            set => datos_CONFLICTO_RUBRO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CONFLICTO_RUBRO() => datos_CONFLICTO_RUBRO = new dald__l_CONFLICTO_RUBRO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CONFLICTO_RUBRO.select();
        }

        public void clearOrderBy()
        {
            datos_CONFLICTO_RUBRO.clearOrderBy();
        }

        public void Select()
        {
            datos_CONFLICTO_RUBRO.single_select();
        }

     #endregion

    }
}
