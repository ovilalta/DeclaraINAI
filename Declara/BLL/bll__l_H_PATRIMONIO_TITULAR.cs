using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_H_PATRIMONIO_TITULAR : _bllSistema
    {

        internal dald__l_H_PATRIMONIO_TITULAR datos_H_PATRIMONIO_TITULAR;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.H_PATRIMONIO_TITULAR> lista_H_PATRIMONIO_TITULAR => datos_H_PATRIMONIO_TITULAR.lista_H_PATRIMONIO_TITULARs;

        protected List<MODELDeclara_V2.H_PATRIMONIO_TITULAR>  base_H_PATRIMONIO_TITULARs => datos_H_PATRIMONIO_TITULAR.base_H_PATRIMONIO_TITULARs;

        public StringFilter VID_NOMBRE
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_NOMBRE;
          set => datos_H_PATRIMONIO_TITULAR.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_NOMBREs;
          set => datos_H_PATRIMONIO_TITULAR.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_FECHA;
          set => datos_H_PATRIMONIO_TITULAR.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_FECHAs;
          set => datos_H_PATRIMONIO_TITULAR.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_HOMOCLAVE;
          set => datos_H_PATRIMONIO_TITULAR.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_H_PATRIMONIO_TITULAR.VID_HOMOCLAVEs;
          set => datos_H_PATRIMONIO_TITULAR.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_PATRIMONIO;
          set => datos_H_PATRIMONIO_TITULAR.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_PATRIMONIOs;
          set => datos_H_PATRIMONIO_TITULAR.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_DEPENDIENTE;
          set => datos_H_PATRIMONIO_TITULAR.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_DEPENDIENTEs;
          set => datos_H_PATRIMONIO_TITULAR.NID_DEPENDIENTEs = value;
        }

        public IntegerFilter NID_HISTORICO
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_HISTORICO;
          set => datos_H_PATRIMONIO_TITULAR.NID_HISTORICO = value;
        }
        public ListFilter<Int32> NID_HISTORICOs
        {
          get => datos_H_PATRIMONIO_TITULAR.NID_HISTORICOs;
          set => datos_H_PATRIMONIO_TITULAR.NID_HISTORICOs = value;
        }

        public System.Nullable<Boolean> L_DIF
        {
          get => datos_H_PATRIMONIO_TITULAR.L_DIF;
          set => datos_H_PATRIMONIO_TITULAR.L_DIF = value;
        }
        public ListFilter<Boolean> L_DIFs
        {
          get => datos_H_PATRIMONIO_TITULAR.L_DIFs;
          set => datos_H_PATRIMONIO_TITULAR.L_DIFs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_H_PATRIMONIO_TITULAR.OrderByCriterios; 
            set => datos_H_PATRIMONIO_TITULAR.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_H_PATRIMONIO_TITULAR() => datos_H_PATRIMONIO_TITULAR = new dald__l_H_PATRIMONIO_TITULAR();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_H_PATRIMONIO_TITULAR.select();
        }

        public void clearOrderBy()
        {
            datos_H_PATRIMONIO_TITULAR.clearOrderBy();
        }

        public void Select()
        {
            datos_H_PATRIMONIO_TITULAR.single_select();
        }

     #endregion

    }
}
