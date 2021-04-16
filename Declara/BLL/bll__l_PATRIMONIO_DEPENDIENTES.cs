using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_PATRIMONIO_DEPENDIENTES : _bllSistema
    {

        internal dald__l_PATRIMONIO_DEPENDIENTES datos_PATRIMONIO_DEPENDIENTES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.PATRIMONIO_DEPENDIENTES> lista_PATRIMONIO_DEPENDIENTES => datos_PATRIMONIO_DEPENDIENTES.lista_PATRIMONIO_DEPENDIENTESs;

        protected List<MODELDeclara_V2.PATRIMONIO_DEPENDIENTES>  base_PATRIMONIO_DEPENDIENTESs => datos_PATRIMONIO_DEPENDIENTES.base_PATRIMONIO_DEPENDIENTESs;

        public StringFilter VID_NOMBRE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_NOMBRE;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_NOMBREs;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_FECHA;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_FECHAs;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVEs;
          set => datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE;
          set => datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTEs;
          set => datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTEs = value;
        }

        public IntegerFilter NID_TIPO_DEPENDIENTE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
          set => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_TIPO_DEPENDIENTEs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs;
          set => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs = value;
        }

        public StringFilter E_NOMBRE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE;
          set => datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE = value;
        }
        public ListFilter<String> E_NOMBREs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_NOMBREs;
          set => datos_PATRIMONIO_DEPENDIENTES.E_NOMBREs = value;
        }

        public StringFilter E_PRIMER_A
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A;
          set => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A = value;
        }
        public ListFilter<String> E_PRIMER_As
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_As;
          set => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_As = value;
        }

        public StringFilter E_SEGUNDO_A
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A;
          set => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A = value;
        }
        public ListFilter<String> E_SEGUNDO_As
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_As;
          set => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_As = value;
        }

        public DateTimeFilter F_NACIMIENTO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO;
          set => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO = value;
        }
        public ListFilter<DateTime> F_NACIMIENTOs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTOs;
          set => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTOs = value;
        }

        public StringFilter E_RFC
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_RFC;
          set => datos_PATRIMONIO_DEPENDIENTES.E_RFC = value;
        }
        public ListFilter<String> E_RFCs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_RFCs;
          set => datos_PATRIMONIO_DEPENDIENTES.E_RFCs = value;
        }

        public System.Nullable<Boolean> L_DEPENDE_ECO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO;
          set => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO = value;
        }
        public ListFilter<Boolean> L_DEPENDE_ECOs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECOs;
          set => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECOs = value;
        }

        public StringFilter V_DOMICILIO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIO;
          set => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIO = value;
        }
        public ListFilter<String> V_DOMICILIOs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIOs;
          set => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVO;
          set => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVOs;
          set => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_PATRIMONIO_DEPENDIENTES.OrderByCriterios; 
            set => datos_PATRIMONIO_DEPENDIENTES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_PATRIMONIO_DEPENDIENTES() => datos_PATRIMONIO_DEPENDIENTES = new dald__l_PATRIMONIO_DEPENDIENTES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_PATRIMONIO_DEPENDIENTES.select();
        }

        public void clearOrderBy()
        {
            datos_PATRIMONIO_DEPENDIENTES.clearOrderBy();
        }

        public void Select()
        {
            datos_PATRIMONIO_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
