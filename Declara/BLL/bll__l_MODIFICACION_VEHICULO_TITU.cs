using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_VEHICULO_TITU : _bllSistema
    {

        internal dald__l_MODIFICACION_VEHICULO_TITU datos_MODIFICACION_VEHICULO_TITU;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_VEHICULO_TITU> lista_MODIFICACION_VEHICULO_TITU => datos_MODIFICACION_VEHICULO_TITU.lista_MODIFICACION_VEHICULO_TITUs;

        protected List<MODELDeclara_V2.MODIFICACION_VEHICULO_TITU>  base_MODIFICACION_VEHICULO_TITUs => datos_MODIFICACION_VEHICULO_TITU.base_MODIFICACION_VEHICULO_TITUs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_NOMBRE;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_NOMBREs;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_FECHA;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_FECHAs;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_HOMOCLAVE;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_VEHICULO_TITU.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_DECLARACION;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_DECLARACIONs;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_PATRIMONIO;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_PATRIMONIOs;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_DEPENDIENTE;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.NID_DEPENDIENTEs;
          set => datos_MODIFICACION_VEHICULO_TITU.NID_DEPENDIENTEs = value;
        }

        public System.Nullable<Boolean> L_DIF
        {
          get => datos_MODIFICACION_VEHICULO_TITU.L_DIF;
          set => datos_MODIFICACION_VEHICULO_TITU.L_DIF = value;
        }
        public ListFilter<Boolean> L_DIFs
        {
          get => datos_MODIFICACION_VEHICULO_TITU.L_DIFs;
          set => datos_MODIFICACION_VEHICULO_TITU.L_DIFs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_VEHICULO_TITU.OrderByCriterios; 
            set => datos_MODIFICACION_VEHICULO_TITU.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_VEHICULO_TITU() => datos_MODIFICACION_VEHICULO_TITU = new dald__l_MODIFICACION_VEHICULO_TITU();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_VEHICULO_TITU.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_VEHICULO_TITU.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_VEHICULO_TITU.single_select();
        }

     #endregion

    }
}
