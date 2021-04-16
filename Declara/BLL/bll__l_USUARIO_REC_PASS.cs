using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_USUARIO_REC_PASS : _bllSistema
    {

        internal dald__l_USUARIO_REC_PASS datos_USUARIO_REC_PASS;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.USUARIO_REC_PASS> lista_USUARIO_REC_PASS => datos_USUARIO_REC_PASS.lista_USUARIO_REC_PASSs;

        protected List<MODELDeclara_V2.USUARIO_REC_PASS>  base_USUARIO_REC_PASSs => datos_USUARIO_REC_PASS.base_USUARIO_REC_PASSs;

        public StringFilter VID_NOMBRE
        {
          get => datos_USUARIO_REC_PASS.VID_NOMBRE;
          set => datos_USUARIO_REC_PASS.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_USUARIO_REC_PASS.VID_NOMBREs;
          set => datos_USUARIO_REC_PASS.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_USUARIO_REC_PASS.VID_FECHA;
          set => datos_USUARIO_REC_PASS.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_USUARIO_REC_PASS.VID_FECHAs;
          set => datos_USUARIO_REC_PASS.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_USUARIO_REC_PASS.VID_HOMOCLAVE;
          set => datos_USUARIO_REC_PASS.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_USUARIO_REC_PASS.VID_HOMOCLAVEs;
          set => datos_USUARIO_REC_PASS.VID_HOMOCLAVEs = value;
        }

        public StringFilter V_CORREO
        {
          get => datos_USUARIO_REC_PASS.V_CORREO;
          set => datos_USUARIO_REC_PASS.V_CORREO = value;
        }
        public ListFilter<String> V_CORREOs
        {
          get => datos_USUARIO_REC_PASS.V_CORREOs;
          set => datos_USUARIO_REC_PASS.V_CORREOs = value;
        }

        public IntegerFilter N_USOS
        {
          get => datos_USUARIO_REC_PASS.N_USOS;
          set => datos_USUARIO_REC_PASS.N_USOS = value;
        }
        public ListFilter<Int32> N_USOSs
        {
          get => datos_USUARIO_REC_PASS.N_USOSs;
          set => datos_USUARIO_REC_PASS.N_USOSs = value;
        }

        public DateTimeFilter F_SOLICITUD
        {
          get => datos_USUARIO_REC_PASS.F_SOLICITUD;
          set => datos_USUARIO_REC_PASS.F_SOLICITUD = value;
        }
        public ListFilter<DateTime> F_SOLICITUDs
        {
          get => datos_USUARIO_REC_PASS.F_SOLICITUDs;
          set => datos_USUARIO_REC_PASS.F_SOLICITUDs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_USUARIO_REC_PASS.OrderByCriterios; 
            set => datos_USUARIO_REC_PASS.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_USUARIO_REC_PASS() => datos_USUARIO_REC_PASS = new dald__l_USUARIO_REC_PASS();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_USUARIO_REC_PASS.select();
        }

        public void clearOrderBy()
        {
            datos_USUARIO_REC_PASS.clearOrderBy();
        }

        public void Select()
        {
            datos_USUARIO_REC_PASS.single_select();
        }

     #endregion

    }
}
