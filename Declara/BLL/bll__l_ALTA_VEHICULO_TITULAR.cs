using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_VEHICULO_TITULAR : _bllSistema
    {

        internal dald__l_ALTA_VEHICULO_TITULAR datos_ALTA_VEHICULO_TITULAR;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_VEHICULO_TITULAR> lista_ALTA_VEHICULO_TITULAR => datos_ALTA_VEHICULO_TITULAR.lista_ALTA_VEHICULO_TITULARs;

        protected List<MODELDeclara_V2.ALTA_VEHICULO_TITULAR>  base_ALTA_VEHICULO_TITULARs => datos_ALTA_VEHICULO_TITULAR.base_ALTA_VEHICULO_TITULARs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_NOMBRE;
          set => datos_ALTA_VEHICULO_TITULAR.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_NOMBREs;
          set => datos_ALTA_VEHICULO_TITULAR.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_FECHA;
          set => datos_ALTA_VEHICULO_TITULAR.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_FECHAs;
          set => datos_ALTA_VEHICULO_TITULAR.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_HOMOCLAVE;
          set => datos_ALTA_VEHICULO_TITULAR.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_VEHICULO_TITULAR.VID_HOMOCLAVEs;
          set => datos_ALTA_VEHICULO_TITULAR.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_DECLARACION;
          set => datos_ALTA_VEHICULO_TITULAR.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_DECLARACIONs;
          set => datos_ALTA_VEHICULO_TITULAR.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_VEHICULO
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_VEHICULO;
          set => datos_ALTA_VEHICULO_TITULAR.NID_VEHICULO = value;
        }
        public ListFilter<Int32> NID_VEHICULOs
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_VEHICULOs;
          set => datos_ALTA_VEHICULO_TITULAR.NID_VEHICULOs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_DEPENDIENTE;
          set => datos_ALTA_VEHICULO_TITULAR.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_ALTA_VEHICULO_TITULAR.NID_DEPENDIENTEs;
          set => datos_ALTA_VEHICULO_TITULAR.NID_DEPENDIENTEs = value;
        }

        public System.Nullable<Boolean> L_DIF
        {
          get => datos_ALTA_VEHICULO_TITULAR.L_DIF;
          set => datos_ALTA_VEHICULO_TITULAR.L_DIF = value;
        }
        public ListFilter<Boolean> L_DIFs
        {
          get => datos_ALTA_VEHICULO_TITULAR.L_DIFs;
          set => datos_ALTA_VEHICULO_TITULAR.L_DIFs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_VEHICULO_TITULAR.OrderByCriterios; 
            set => datos_ALTA_VEHICULO_TITULAR.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_VEHICULO_TITULAR() => datos_ALTA_VEHICULO_TITULAR = new dald__l_ALTA_VEHICULO_TITULAR();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_VEHICULO_TITULAR.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_VEHICULO_TITULAR.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_VEHICULO_TITULAR.single_select();
        }

     #endregion

    }
}
