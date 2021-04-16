using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_RESTRICCIONES : _bllSistema
    {

        internal dald__l_DECLARACION_RESTRICCIONES datos_DECLARACION_RESTRICCIONES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES> lista_DECLARACION_RESTRICCIONES => datos_DECLARACION_RESTRICCIONES.lista_DECLARACION_RESTRICCIONESs;

        protected List<MODELDeclara_V2.DECLARACION_RESTRICCIONES>  base_DECLARACION_RESTRICCIONESs => datos_DECLARACION_RESTRICCIONES.base_DECLARACION_RESTRICCIONESs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_NOMBRE;
          set => datos_DECLARACION_RESTRICCIONES.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_NOMBREs;
          set => datos_DECLARACION_RESTRICCIONES.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_FECHA;
          set => datos_DECLARACION_RESTRICCIONES.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_FECHAs;
          set => datos_DECLARACION_RESTRICCIONES.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_HOMOCLAVE;
          set => datos_DECLARACION_RESTRICCIONES.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_RESTRICCIONES.VID_HOMOCLAVEs;
          set => datos_DECLARACION_RESTRICCIONES.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_RESTRICCIONES.NID_DECLARACION;
          set => datos_DECLARACION_RESTRICCIONES.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_RESTRICCIONES.NID_DECLARACIONs;
          set => datos_DECLARACION_RESTRICCIONES.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_RESTRICCION
        {
          get => datos_DECLARACION_RESTRICCIONES.NID_RESTRICCION;
          set => datos_DECLARACION_RESTRICCIONES.NID_RESTRICCION = value;
        }
        public ListFilter<Int32> NID_RESTRICCIONs
        {
          get => datos_DECLARACION_RESTRICCIONES.NID_RESTRICCIONs;
          set => datos_DECLARACION_RESTRICCIONES.NID_RESTRICCIONs = value;
        }

        public System.Nullable<Boolean> L_RESPUESTA
        {
          get => datos_DECLARACION_RESTRICCIONES.L_RESPUESTA;
          set => datos_DECLARACION_RESTRICCIONES.L_RESPUESTA = value;
        }
        public ListFilter<Boolean> L_RESPUESTAs
        {
          get => datos_DECLARACION_RESTRICCIONES.L_RESPUESTAs;
          set => datos_DECLARACION_RESTRICCIONES.L_RESPUESTAs = value;
        }

        public System.Nullable<Boolean> L_AUTO
        {
          get => datos_DECLARACION_RESTRICCIONES.L_AUTO;
          set => datos_DECLARACION_RESTRICCIONES.L_AUTO = value;
        }
        public ListFilter<Boolean> L_AUTOs
        {
          get => datos_DECLARACION_RESTRICCIONES.L_AUTOs;
          set => datos_DECLARACION_RESTRICCIONES.L_AUTOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_RESTRICCIONES.OrderByCriterios; 
            set => datos_DECLARACION_RESTRICCIONES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_RESTRICCIONES() => datos_DECLARACION_RESTRICCIONES = new dald__l_DECLARACION_RESTRICCIONES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_RESTRICCIONES.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_RESTRICCIONES.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_RESTRICCIONES.single_select();
        }

     #endregion

    }
}
