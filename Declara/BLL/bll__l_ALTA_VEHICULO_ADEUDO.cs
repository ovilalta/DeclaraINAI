using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_ALTA_VEHICULO_ADEUDO : _bllSistema
    {

        internal dald__l_ALTA_VEHICULO_ADEUDO datos_ALTA_VEHICULO_ADEUDO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO> lista_ALTA_VEHICULO_ADEUDO => datos_ALTA_VEHICULO_ADEUDO.lista_ALTA_VEHICULO_ADEUDOs;

        protected List<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>  base_ALTA_VEHICULO_ADEUDOs => datos_ALTA_VEHICULO_ADEUDO.base_ALTA_VEHICULO_ADEUDOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_NOMBRE;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_NOMBREs;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_FECHA;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_FECHAs;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVEs;
          set => datos_ALTA_VEHICULO_ADEUDO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACION;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACIONs;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_VEHICULO
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULO;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULO = value;
        }
        public ListFilter<Int32> NID_VEHICULOs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULOs;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_VEHICULOs = value;
        }

        public IntegerFilter NID_ADEUDO
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDO = value;
        }
        public ListFilter<Int32> NID_ADEUDOs
        {
          get => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDOs;
          set => datos_ALTA_VEHICULO_ADEUDO.NID_ADEUDOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_VEHICULO_ADEUDO.OrderByCriterios; 
            set => datos_ALTA_VEHICULO_ADEUDO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_ALTA_VEHICULO_ADEUDO() => datos_ALTA_VEHICULO_ADEUDO = new dald__l_ALTA_VEHICULO_ADEUDO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_ALTA_VEHICULO_ADEUDO.select();
        }

        public void clearOrderBy()
        {
            datos_ALTA_VEHICULO_ADEUDO.clearOrderBy();
        }

        public void Select()
        {
            datos_ALTA_VEHICULO_ADEUDO.single_select();
        }

     #endregion

    }
}
