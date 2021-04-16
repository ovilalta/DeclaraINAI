using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CONFLICTO : _bllSistema
    {

        internal dald__l_CONFLICTO datos_CONFLICTO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CONFLICTO> lista_CONFLICTO => datos_CONFLICTO.lista_CONFLICTOs;

        protected List<MODELDeclara_V2.CONFLICTO>  base_CONFLICTOs => datos_CONFLICTO.base_CONFLICTOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_CONFLICTO.VID_NOMBRE;
          set => datos_CONFLICTO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_CONFLICTO.VID_NOMBREs;
          set => datos_CONFLICTO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_CONFLICTO.VID_FECHA;
          set => datos_CONFLICTO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_CONFLICTO.VID_FECHAs;
          set => datos_CONFLICTO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_CONFLICTO.VID_HOMOCLAVE;
          set => datos_CONFLICTO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_CONFLICTO.VID_HOMOCLAVEs;
          set => datos_CONFLICTO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_CONFLICTO
        {
          get => datos_CONFLICTO.NID_CONFLICTO;
          set => datos_CONFLICTO.NID_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_CONFLICTOs
        {
          get => datos_CONFLICTO.NID_CONFLICTOs;
          set => datos_CONFLICTO.NID_CONFLICTOs = value;
        }

        public IntegerFilter NID_DEC_ASOS
        {
          get => datos_CONFLICTO.NID_DEC_ASOS;
          set => datos_CONFLICTO.NID_DEC_ASOS = value;
        }
        public ListFilter<Int32> NID_DEC_ASOSs
        {
          get => datos_CONFLICTO.NID_DEC_ASOSs;
          set => datos_CONFLICTO.NID_DEC_ASOSs = value;
        }

        public IntegerFilter NID_ESTADO_CONFLICTO
        {
          get => datos_CONFLICTO.NID_ESTADO_CONFLICTO;
          set => datos_CONFLICTO.NID_ESTADO_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_ESTADO_CONFLICTOs
        {
          get => datos_CONFLICTO.NID_ESTADO_CONFLICTOs;
          set => datos_CONFLICTO.NID_ESTADO_CONFLICTOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CONFLICTO.OrderByCriterios; 
            set => datos_CONFLICTO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CONFLICTO() => datos_CONFLICTO = new dald__l_CONFLICTO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CONFLICTO.select();
        }

        public void clearOrderBy()
        {
            datos_CONFLICTO.clearOrderBy();
        }

        public void Select()
        {
            datos_CONFLICTO.single_select();
        }

     #endregion

    }
}
