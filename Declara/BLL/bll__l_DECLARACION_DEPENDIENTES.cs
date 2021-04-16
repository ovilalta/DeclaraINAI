using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_DECLARACION_DEPENDIENTES : _bllSistema
    {

        internal dald__l_DECLARACION_DEPENDIENTES datos_DECLARACION_DEPENDIENTES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES> lista_DECLARACION_DEPENDIENTES => datos_DECLARACION_DEPENDIENTES.lista_DECLARACION_DEPENDIENTESs;

        protected List<MODELDeclara_V2.DECLARACION_DEPENDIENTES>  base_DECLARACION_DEPENDIENTESs => datos_DECLARACION_DEPENDIENTES.base_DECLARACION_DEPENDIENTESs;

        public StringFilter VID_NOMBRE
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_NOMBRE;
          set => datos_DECLARACION_DEPENDIENTES.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_NOMBREs;
          set => datos_DECLARACION_DEPENDIENTES.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_FECHA;
          set => datos_DECLARACION_DEPENDIENTES.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_FECHAs;
          set => datos_DECLARACION_DEPENDIENTES.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVE;
          set => datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVEs;
          set => datos_DECLARACION_DEPENDIENTES.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_DECLARACION;
          set => datos_DECLARACION_DEPENDIENTES.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_DECLARACIONs;
          set => datos_DECLARACION_DEPENDIENTES.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTE;
          set => datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTEs;
          set => datos_DECLARACION_DEPENDIENTES.NID_DEPENDIENTEs = value;
        }

        public IntegerFilter NID_TIPO_DEPENDIENTE
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
          set => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_TIPO_DEPENDIENTEs
        {
          get => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTEs;
          set => datos_DECLARACION_DEPENDIENTES.NID_TIPO_DEPENDIENTEs = value;
        }

        public StringFilter E_NOMBRE
        {
          get => datos_DECLARACION_DEPENDIENTES.E_NOMBRE;
          set => datos_DECLARACION_DEPENDIENTES.E_NOMBRE = value;
        }
        public ListFilter<String> E_NOMBREs
        {
          get => datos_DECLARACION_DEPENDIENTES.E_NOMBREs;
          set => datos_DECLARACION_DEPENDIENTES.E_NOMBREs = value;
        }

        public StringFilter E_PRIMER_A
        {
          get => datos_DECLARACION_DEPENDIENTES.E_PRIMER_A;
          set => datos_DECLARACION_DEPENDIENTES.E_PRIMER_A = value;
        }
        public ListFilter<String> E_PRIMER_As
        {
          get => datos_DECLARACION_DEPENDIENTES.E_PRIMER_As;
          set => datos_DECLARACION_DEPENDIENTES.E_PRIMER_As = value;
        }

        public StringFilter E_SEGUNDO_A
        {
          get => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A;
          set => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_A = value;
        }
        public ListFilter<String> E_SEGUNDO_As
        {
          get => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_As;
          set => datos_DECLARACION_DEPENDIENTES.E_SEGUNDO_As = value;
        }

        public DateTimeFilter F_NACIMIENTO
        {
          get => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO;
          set => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTO = value;
        }
        public ListFilter<DateTime> F_NACIMIENTOs
        {
          get => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTOs;
          set => datos_DECLARACION_DEPENDIENTES.F_NACIMIENTOs = value;
        }

        public StringFilter E_RFC
        {
          get => datos_DECLARACION_DEPENDIENTES.E_RFC;
          set => datos_DECLARACION_DEPENDIENTES.E_RFC = value;
        }
        public ListFilter<String> E_RFCs
        {
          get => datos_DECLARACION_DEPENDIENTES.E_RFCs;
          set => datos_DECLARACION_DEPENDIENTES.E_RFCs = value;
        }

        public System.Nullable<Boolean> L_DEPENDE_ECO
        {
          get => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECO;
          set => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECO = value;
        }
        public ListFilter<Boolean> L_DEPENDE_ECOs
        {
          get => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECOs;
          set => datos_DECLARACION_DEPENDIENTES.L_DEPENDE_ECOs = value;
        }

        public StringFilter E_DOMICILIO
        {
          get => datos_DECLARACION_DEPENDIENTES.E_DOMICILIO;
          set => datos_DECLARACION_DEPENDIENTES.E_DOMICILIO = value;
        }
        public ListFilter<String> E_DOMICILIOs
        {
          get => datos_DECLARACION_DEPENDIENTES.E_DOMICILIOs;
          set => datos_DECLARACION_DEPENDIENTES.E_DOMICILIOs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_DECLARACION_DEPENDIENTES.L_ACTIVO;
          set => datos_DECLARACION_DEPENDIENTES.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_DECLARACION_DEPENDIENTES.L_ACTIVOs;
          set => datos_DECLARACION_DEPENDIENTES.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_DEPENDIENTES.OrderByCriterios; 
            set => datos_DECLARACION_DEPENDIENTES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_DECLARACION_DEPENDIENTES() => datos_DECLARACION_DEPENDIENTES = new dald__l_DECLARACION_DEPENDIENTES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION_DEPENDIENTES.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION_DEPENDIENTES.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
