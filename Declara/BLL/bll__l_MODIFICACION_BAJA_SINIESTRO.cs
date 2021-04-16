using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_BAJA_SINIESTRO : _bllSistema
    {

        internal dald__l_MODIFICACION_BAJA_SINIESTRO datos_MODIFICACION_BAJA_SINIESTRO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO> lista_MODIFICACION_BAJA_SINIESTRO => datos_MODIFICACION_BAJA_SINIESTRO.lista_MODIFICACION_BAJA_SINIESTROs;

        protected List<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>  base_MODIFICACION_BAJA_SINIESTROs => datos_MODIFICACION_BAJA_SINIESTRO.base_MODIFICACION_BAJA_SINIESTROs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBRE;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBREs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHA;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHAs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACION;
          set => datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACIONs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO;
          set => datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIOs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIOs = value;
        }

        public System.Nullable<Boolean> L_POLIZA
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA;
          set => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZA = value;
        }
        public ListFilter<Boolean> L_POLIZAs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZAs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.L_POLIZAs = value;
        }

        public DecimalFilter M_RECUPERADO
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO;
          set => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO = value;
        }
        public ListFilter<Decimal> M_RECUPERADOs
        {
          get => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADOs;
          set => datos_MODIFICACION_BAJA_SINIESTRO.M_RECUPERADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_BAJA_SINIESTRO.OrderByCriterios; 
            set => datos_MODIFICACION_BAJA_SINIESTRO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_BAJA_SINIESTRO() => datos_MODIFICACION_BAJA_SINIESTRO = new dald__l_MODIFICACION_BAJA_SINIESTRO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_BAJA_SINIESTRO.single_select();
        }

     #endregion

    }
}
