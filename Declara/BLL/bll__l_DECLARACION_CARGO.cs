using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_CARGO : _bllSistema
    {

        internal dald__l_DECLARACION_CARGO datos_DECLARACION_CARGO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_CARGO> lista_DECLARACION_CARGO => datos_DECLARACION_CARGO.lista_DECLARACION_CARGOs;

        protected List<MODELDeclara_V2.DECLARACION_CARGO>  base_DECLARACION_CARGOs => datos_DECLARACION_CARGO.base_DECLARACION_CARGOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_CARGO.VID_NOMBRE;
          set => datos_DECLARACION_CARGO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_CARGO.VID_NOMBREs;
          set => datos_DECLARACION_CARGO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_CARGO.VID_FECHA;
          set => datos_DECLARACION_CARGO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_CARGO.VID_FECHAs;
          set => datos_DECLARACION_CARGO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_CARGO.VID_HOMOCLAVE;
          set => datos_DECLARACION_CARGO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_CARGO.VID_HOMOCLAVEs;
          set => datos_DECLARACION_CARGO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_CARGO.NID_DECLARACION;
          set => datos_DECLARACION_CARGO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_CARGO.NID_DECLARACIONs;
          set => datos_DECLARACION_CARGO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PUESTO
        {
          get => datos_DECLARACION_CARGO.NID_PUESTO;
          set => datos_DECLARACION_CARGO.NID_PUESTO = value;
        }
        public ListFilter<Int32> NID_PUESTOs
        {
          get => datos_DECLARACION_CARGO.NID_PUESTOs;
          set => datos_DECLARACION_CARGO.NID_PUESTOs = value;
        }

        public StringFilter V_DENOMINACION
        {
          get => datos_DECLARACION_CARGO.V_DENOMINACION;
          set => datos_DECLARACION_CARGO.V_DENOMINACION = value;
        }
        public ListFilter<String> V_DENOMINACIONs
        {
          get => datos_DECLARACION_CARGO.V_DENOMINACIONs;
          set => datos_DECLARACION_CARGO.V_DENOMINACIONs = value;
        }

        public DateTimeFilter F_POSESION
        {
          get => datos_DECLARACION_CARGO.F_POSESION;
          set => datos_DECLARACION_CARGO.F_POSESION = value;
        }
        public ListFilter<DateTime> F_POSESIONs
        {
          get => datos_DECLARACION_CARGO.F_POSESIONs;
          set => datos_DECLARACION_CARGO.F_POSESIONs = value;
        }

        public DateTimeFilter F_INICIO
        {
          get => datos_DECLARACION_CARGO.F_INICIO;
          set => datos_DECLARACION_CARGO.F_INICIO = value;
        }
        public ListFilter<DateTime> F_INICIOs
        {
          get => datos_DECLARACION_CARGO.F_INICIOs;
          set => datos_DECLARACION_CARGO.F_INICIOs = value;
        }

        public StringFilter VID_PRIMER_NIVEL
        {
          get => datos_DECLARACION_CARGO.VID_PRIMER_NIVEL;
          set => datos_DECLARACION_CARGO.VID_PRIMER_NIVEL = value;
        }
        public ListFilter<String> VID_PRIMER_NIVELs
        {
          get => datos_DECLARACION_CARGO.VID_PRIMER_NIVELs;
          set => datos_DECLARACION_CARGO.VID_PRIMER_NIVELs = value;
        }

        public StringFilter VID_SEGUNDO_NIVEL
        {
          get => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL;
          set => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL = value;
        }
        public ListFilter<String> VID_SEGUNDO_NIVELs
        {
          get => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVELs;
          set => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVELs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_CARGO.OrderByCriterios; 
            set => datos_DECLARACION_CARGO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_CARGO() => datos_DECLARACION_CARGO = new dald__l_DECLARACION_CARGO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_CARGO.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_CARGO.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_CARGO.single_select();
        }

     #endregion

    }
}
