using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_APARTADO : _bllSistema
    {

        internal dald__l_DECLARACION_APARTADO datos_DECLARACION_APARTADO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_APARTADO> lista_DECLARACION_APARTADO => datos_DECLARACION_APARTADO.lista_DECLARACION_APARTADOs;

        protected List<MODELDeclara_V2.DECLARACION_APARTADO>  base_DECLARACION_APARTADOs => datos_DECLARACION_APARTADO.base_DECLARACION_APARTADOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_APARTADO.VID_NOMBRE;
          set => datos_DECLARACION_APARTADO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_APARTADO.VID_NOMBREs;
          set => datos_DECLARACION_APARTADO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_APARTADO.VID_FECHA;
          set => datos_DECLARACION_APARTADO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_APARTADO.VID_FECHAs;
          set => datos_DECLARACION_APARTADO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_APARTADO.VID_HOMOCLAVE;
          set => datos_DECLARACION_APARTADO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_APARTADO.VID_HOMOCLAVEs;
          set => datos_DECLARACION_APARTADO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_APARTADO.NID_DECLARACION;
          set => datos_DECLARACION_APARTADO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_APARTADO.NID_DECLARACIONs;
          set => datos_DECLARACION_APARTADO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_APARTADO
        {
          get => datos_DECLARACION_APARTADO.NID_APARTADO;
          set => datos_DECLARACION_APARTADO.NID_APARTADO = value;
        }
        public ListFilter<Int32> NID_APARTADOs
        {
          get => datos_DECLARACION_APARTADO.NID_APARTADOs;
          set => datos_DECLARACION_APARTADO.NID_APARTADOs = value;
        }

        public System.Nullable<Boolean> L_ESTADO
        {
          get => datos_DECLARACION_APARTADO.L_ESTADO;
          set => datos_DECLARACION_APARTADO.L_ESTADO = value;
        }
        public ListFilter<Boolean> L_ESTADOs
        {
          get => datos_DECLARACION_APARTADO.L_ESTADOs;
          set => datos_DECLARACION_APARTADO.L_ESTADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_APARTADO.OrderByCriterios; 
            set => datos_DECLARACION_APARTADO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_APARTADO() => datos_DECLARACION_APARTADO = new dald__l_DECLARACION_APARTADO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_APARTADO.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_APARTADO.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_APARTADO.single_select();
        }

     #endregion

    }
}
