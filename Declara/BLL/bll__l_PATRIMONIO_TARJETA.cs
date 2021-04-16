using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_TARJETA : _bllSistema
    {

        internal dald__l_PATRIMONIO_TARJETA datos_PATRIMONIO_TARJETA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_TARJETA> lista_PATRIMONIO_TARJETA => datos_PATRIMONIO_TARJETA.lista_PATRIMONIO_TARJETAs;

        protected List<MODELDeclara_V2.PATRIMONIO_TARJETA>  base_PATRIMONIO_TARJETAs => datos_PATRIMONIO_TARJETA.base_PATRIMONIO_TARJETAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_TARJETA.VID_NOMBRE;
          set => datos_PATRIMONIO_TARJETA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_TARJETA.VID_NOMBREs;
          set => datos_PATRIMONIO_TARJETA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_TARJETA.VID_FECHA;
          set => datos_PATRIMONIO_TARJETA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_TARJETA.VID_FECHAs;
          set => datos_PATRIMONIO_TARJETA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_TARJETA.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_TARJETA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_TARJETA.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_TARJETA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_PATRIMONIO_TARJETA.NID_DECLARACION;
          set => datos_PATRIMONIO_TARJETA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_PATRIMONIO_TARJETA.NID_DECLARACIONs;
          set => datos_PATRIMONIO_TARJETA.NID_DECLARACIONs = value;
        }

        public StringFilter E_NUMERO
        {
          get => datos_PATRIMONIO_TARJETA.E_NUMERO;
          set => datos_PATRIMONIO_TARJETA.E_NUMERO = value;
        }
        public ListFilter<String> E_NUMEROs
        {
          get => datos_PATRIMONIO_TARJETA.E_NUMEROs;
          set => datos_PATRIMONIO_TARJETA.E_NUMEROs = value;
        }

        public IntegerFilter NID_INSTITUCION
        {
          get => datos_PATRIMONIO_TARJETA.NID_INSTITUCION;
          set => datos_PATRIMONIO_TARJETA.NID_INSTITUCION = value;
        }
        public ListFilter<Int32> NID_INSTITUCIONs
        {
          get => datos_PATRIMONIO_TARJETA.NID_INSTITUCIONs;
          set => datos_PATRIMONIO_TARJETA.NID_INSTITUCIONs = value;
        }

        public StringFilter V_NUMERO_CORTO
        {
          get => datos_PATRIMONIO_TARJETA.V_NUMERO_CORTO;
          set => datos_PATRIMONIO_TARJETA.V_NUMERO_CORTO = value;
        }
        public ListFilter<String> V_NUMERO_CORTOs
        {
          get => datos_PATRIMONIO_TARJETA.V_NUMERO_CORTOs;
          set => datos_PATRIMONIO_TARJETA.V_NUMERO_CORTOs = value;
        }

        public DecimalFilter M_SALDO
        {
          get => datos_PATRIMONIO_TARJETA.M_SALDO;
          set => datos_PATRIMONIO_TARJETA.M_SALDO = value;
        }
        public ListFilter<Decimal> M_SALDOs
        {
          get => datos_PATRIMONIO_TARJETA.M_SALDOs;
          set => datos_PATRIMONIO_TARJETA.M_SALDOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVA
        {
          get => datos_PATRIMONIO_TARJETA.L_ACTIVA;
          set => datos_PATRIMONIO_TARJETA.L_ACTIVA = value;
        }
        public ListFilter<Boolean> L_ACTIVAs
        {
          get => datos_PATRIMONIO_TARJETA.L_ACTIVAs;
          set => datos_PATRIMONIO_TARJETA.L_ACTIVAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_TARJETA.OrderByCriterios; 
            set => datos_PATRIMONIO_TARJETA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_TARJETA() => datos_PATRIMONIO_TARJETA = new dald__l_PATRIMONIO_TARJETA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_TARJETA.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_TARJETA.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_TARJETA.single_select();
        }

     #endregion

    }
}
