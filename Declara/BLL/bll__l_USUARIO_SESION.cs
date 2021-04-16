using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_USUARIO_SESION : _bllSistema
    {

        internal dald__l_USUARIO_SESION datos_USUARIO_SESION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.USUARIO_SESION> lista_USUARIO_SESION => datos_USUARIO_SESION.lista_USUARIO_SESIONs;

        protected List<MODELDeclara_V2.USUARIO_SESION>  base_USUARIO_SESIONs => datos_USUARIO_SESION.base_USUARIO_SESIONs;

        public StringFilter VID_NOMBRE
        {
          get => datos_USUARIO_SESION.VID_NOMBRE;
          set => datos_USUARIO_SESION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_USUARIO_SESION.VID_NOMBREs;
          set => datos_USUARIO_SESION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_USUARIO_SESION.VID_FECHA;
          set => datos_USUARIO_SESION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_USUARIO_SESION.VID_FECHAs;
          set => datos_USUARIO_SESION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_USUARIO_SESION.VID_HOMOCLAVE;
          set => datos_USUARIO_SESION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_USUARIO_SESION.VID_HOMOCLAVEs;
          set => datos_USUARIO_SESION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_SESION
        {
          get => datos_USUARIO_SESION.NID_SESION;
          set => datos_USUARIO_SESION.NID_SESION = value;
        }
        public ListFilter<Int32> NID_SESIONs
        {
          get => datos_USUARIO_SESION.NID_SESIONs;
          set => datos_USUARIO_SESION.NID_SESIONs = value;
        }

        public StringFilter V_IP
        {
          get => datos_USUARIO_SESION.V_IP;
          set => datos_USUARIO_SESION.V_IP = value;
        }
        public ListFilter<String> V_IPs
        {
          get => datos_USUARIO_SESION.V_IPs;
          set => datos_USUARIO_SESION.V_IPs = value;
        }

        public StringFilter V_MAQUINA_USUARIO
        {
          get => datos_USUARIO_SESION.V_MAQUINA_USUARIO;
          set => datos_USUARIO_SESION.V_MAQUINA_USUARIO = value;
        }
        public ListFilter<String> V_MAQUINA_USUARIOs
        {
          get => datos_USUARIO_SESION.V_MAQUINA_USUARIOs;
          set => datos_USUARIO_SESION.V_MAQUINA_USUARIOs = value;
        }

        public DateTimeFilter F_INICIO
        {
          get => datos_USUARIO_SESION.F_INICIO;
          set => datos_USUARIO_SESION.F_INICIO = value;
        }
        public ListFilter<DateTime> F_INICIOs
        {
          get => datos_USUARIO_SESION.F_INICIOs;
          set => datos_USUARIO_SESION.F_INICIOs = value;
        }

        public DateTimeFilter F_FIN
        {
          get => datos_USUARIO_SESION.F_FIN;
          set => datos_USUARIO_SESION.F_FIN = value;
        }
        public ListFilter<DateTime> F_FINs
        {
          get => datos_USUARIO_SESION.F_FINs;
          set => datos_USUARIO_SESION.F_FINs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_USUARIO_SESION.OrderByCriterios; 
            set => datos_USUARIO_SESION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_USUARIO_SESION() => datos_USUARIO_SESION = new dald__l_USUARIO_SESION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_USUARIO_SESION.select();
        }

        public void clearOrderBy()
        {
            datos_USUARIO_SESION.clearOrderBy();
        }

        public void Select()
        {
            datos_USUARIO_SESION.single_select();
        }

     #endregion

    }
}
