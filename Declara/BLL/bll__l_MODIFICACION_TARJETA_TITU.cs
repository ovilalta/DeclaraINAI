using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_TARJETA_TITU : _bllSistema
    {

        internal dald__l_MODIFICACION_TARJETA_TITU datos_MODIFICACION_TARJETA_TITU;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU> lista_MODIFICACION_TARJETA_TITU => datos_MODIFICACION_TARJETA_TITU.lista_MODIFICACION_TARJETA_TITUs;

        protected List<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>  base_MODIFICACION_TARJETA_TITUs => datos_MODIFICACION_TARJETA_TITU.base_MODIFICACION_TARJETA_TITUs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_NOMBRE;
          set => datos_MODIFICACION_TARJETA_TITU.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_NOMBREs;
          set => datos_MODIFICACION_TARJETA_TITU.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_FECHA;
          set => datos_MODIFICACION_TARJETA_TITU.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_FECHAs;
          set => datos_MODIFICACION_TARJETA_TITU.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_HOMOCLAVE;
          set => datos_MODIFICACION_TARJETA_TITU.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_TARJETA_TITU.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_TARJETA_TITU.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_TARJETA_TITU.NID_DECLARACION;
          set => datos_MODIFICACION_TARJETA_TITU.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_TARJETA_TITU.NID_DECLARACIONs;
          set => datos_MODIFICACION_TARJETA_TITU.NID_DECLARACIONs = value;
        }

        public StringFilter E_NUMERO
        {
          get => datos_MODIFICACION_TARJETA_TITU.E_NUMERO;
          set => datos_MODIFICACION_TARJETA_TITU.E_NUMERO = value;
        }
        public ListFilter<String> E_NUMEROs
        {
          get => datos_MODIFICACION_TARJETA_TITU.E_NUMEROs;
          set => datos_MODIFICACION_TARJETA_TITU.E_NUMEROs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_MODIFICACION_TARJETA_TITU.NID_DEPENDIENTE;
          set => datos_MODIFICACION_TARJETA_TITU.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_MODIFICACION_TARJETA_TITU.NID_DEPENDIENTEs;
          set => datos_MODIFICACION_TARJETA_TITU.NID_DEPENDIENTEs = value;
        }

        public System.Nullable<Boolean> L_DIF
        {
          get => datos_MODIFICACION_TARJETA_TITU.L_DIF;
          set => datos_MODIFICACION_TARJETA_TITU.L_DIF = value;
        }
        public ListFilter<Boolean> L_DIFs
        {
          get => datos_MODIFICACION_TARJETA_TITU.L_DIFs;
          set => datos_MODIFICACION_TARJETA_TITU.L_DIFs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_TARJETA_TITU.OrderByCriterios; 
            set => datos_MODIFICACION_TARJETA_TITU.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_TARJETA_TITU() => datos_MODIFICACION_TARJETA_TITU = new dald__l_MODIFICACION_TARJETA_TITU();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_TARJETA_TITU.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_TARJETA_TITU.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_TARJETA_TITU.single_select();
        }

     #endregion

    }
}
