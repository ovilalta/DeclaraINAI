using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    //public  class bll__l_H_PATRIMONIO_DEPENDIENTES : _bllSistema
    //{

    //    internal dald__l_H_PATRIMONIO_DEPENDIENTES datos_H_PATRIMONIO_DEPENDIENTES;

    // #region *** Atributos ***


    //    public List<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES> lista_H_PATRIMONIO_DEPENDIENTES => datos_H_PATRIMONIO_DEPENDIENTES.lista_H_PATRIMONIO_DEPENDIENTESs;

    //    protected List<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>  base_H_PATRIMONIO_DEPENDIENTESs => datos_H_PATRIMONIO_DEPENDIENTES.base_H_PATRIMONIO_DEPENDIENTESs;

    //    public StringFilter VID_NOMBRE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_NOMBRE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_NOMBRE = value;
    //    }
    //    public ListFilter<String> VID_NOMBREs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_NOMBREs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_NOMBREs = value;
    //    }

    //    public StringFilter VID_FECHA
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_FECHA;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_FECHA = value;
    //    }
    //    public ListFilter<String> VID_FECHAs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_FECHAs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_FECHAs = value;
    //    }

    //    public StringFilter VID_HOMOCLAVE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE = value;
    //    }
    //    public ListFilter<String> VID_HOMOCLAVEs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVEs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVEs = value;
    //    }

    //    public IntegerFilter NID_DEPENDIENTE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE = value;
    //    }
    //    public ListFilter<Int32> NID_DEPENDIENTEs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTEs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTEs = value;
    //    }

    //    public IntegerFilter NID_TIPO_DEPENDIENTE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
    //    }
    //    public ListFilter<Int32> NID_TIPO_DEPENDIENTEs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs = value;
    //    }

    //    public StringFilter E_NOMBRE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBRE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBRE = value;
    //    }
    //    public ListFilter<String> E_NOMBREs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBREs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBREs = value;
    //    }

    //    public StringFilter E_PRIMER_A
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_A;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_A = value;
    //    }
    //    public ListFilter<String> E_PRIMER_As
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_As;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_As = value;
    //    }

    //    public StringFilter E_SEGUNDO_A
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A = value;
    //    }
    //    public ListFilter<String> E_SEGUNDO_As
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_As;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_As = value;
    //    }

    //    public DateTimeFilter F_NACIMIENTO
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO = value;
    //    }
    //    public ListFilter<DateTime> F_NACIMIENTOs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTOs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTOs = value;
    //    }

    //    public StringFilter E_RFC
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_RFC;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_RFC = value;
    //    }
    //    public ListFilter<String> E_RFCs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_RFCs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_RFCs = value;
    //    }

    //    public IntegerFilter NID_HISTORICO
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICO;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICO = value;
    //    }
    //    public ListFilter<Int32> NID_HISTORICOs
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICOs;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICOs = value;
    //    }


    //    public List<Order> OrderByCriterios
    //    {
    //        get => datos_H_PATRIMONIO_DEPENDIENTES.OrderByCriterios; 
    //        set => datos_H_PATRIMONIO_DEPENDIENTES.OrderByCriterios = value; 
    //    }


    // #endregion


    // #region *** Constructores ***

    //    public bll__l_H_PATRIMONIO_DEPENDIENTES() => datos_H_PATRIMONIO_DEPENDIENTES = new dald__l_H_PATRIMONIO_DEPENDIENTES();

    // #endregion


    // #region *** Metodos ***

    //    public void select()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.select();
    //    }

    //    public void clearOrderBy()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.clearOrderBy();
    //    }

    //    public void Select()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.single_select();
    //    }

    // #endregion

    //}
}
