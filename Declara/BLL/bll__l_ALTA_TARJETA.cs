using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_TARJETA : _bllSistema
    {

        internal dald__l_ALTA_TARJETA datos_ALTA_TARJETA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_TARJETA> lista_ALTA_TARJETA => datos_ALTA_TARJETA.lista_ALTA_TARJETAs;

        protected List<MODELDeclara_V2.ALTA_TARJETA>  base_ALTA_TARJETAs => datos_ALTA_TARJETA.base_ALTA_TARJETAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_TARJETA.VID_NOMBRE;
          set => datos_ALTA_TARJETA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_TARJETA.VID_NOMBREs;
          set => datos_ALTA_TARJETA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_TARJETA.VID_FECHA;
          set => datos_ALTA_TARJETA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_TARJETA.VID_FECHAs;
          set => datos_ALTA_TARJETA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_TARJETA.VID_HOMOCLAVE;
          set => datos_ALTA_TARJETA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_TARJETA.VID_HOMOCLAVEs;
          set => datos_ALTA_TARJETA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_TARJETA.NID_DECLARACION;
          set => datos_ALTA_TARJETA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_TARJETA.NID_DECLARACIONs;
          set => datos_ALTA_TARJETA.NID_DECLARACIONs = value;
        }

        public StringFilter E_NUMERO
        {
          get => datos_ALTA_TARJETA.E_NUMERO;
          set => datos_ALTA_TARJETA.E_NUMERO = value;
        }
        public ListFilter<String> E_NUMEROs
        {
          get => datos_ALTA_TARJETA.E_NUMEROs;
          set => datos_ALTA_TARJETA.E_NUMEROs = value;
        }

        public StringFilter V_NUMERO_CORTO
        {
          get => datos_ALTA_TARJETA.V_NUMERO_CORTO;
          set => datos_ALTA_TARJETA.V_NUMERO_CORTO = value;
        }
        public ListFilter<String> V_NUMERO_CORTOs
        {
          get => datos_ALTA_TARJETA.V_NUMERO_CORTOs;
          set => datos_ALTA_TARJETA.V_NUMERO_CORTOs = value;
        }

        public DecimalFilter M_SALDO
        {
          get => datos_ALTA_TARJETA.M_SALDO;
          set => datos_ALTA_TARJETA.M_SALDO = value;
        }
        public ListFilter<Decimal> M_SALDOs
        {
          get => datos_ALTA_TARJETA.M_SALDOs;
          set => datos_ALTA_TARJETA.M_SALDOs = value;
        }

        public IntegerFilter NID_TITULAR
        {
          get => datos_ALTA_TARJETA.NID_TITULAR;
          set => datos_ALTA_TARJETA.NID_TITULAR = value;
        }
        public ListFilter<Int32> NID_TITULARs
        {
          get => datos_ALTA_TARJETA.NID_TITULARs;
          set => datos_ALTA_TARJETA.NID_TITULARs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_TARJETA.OrderByCriterios; 
            set => datos_ALTA_TARJETA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_TARJETA() => datos_ALTA_TARJETA = new dald__l_ALTA_TARJETA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_TARJETA.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_TARJETA.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_TARJETA.single_select();
        }

     #endregion

    }
}
