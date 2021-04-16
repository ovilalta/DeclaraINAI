using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal__l_ALTA_VEHICULO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA_VEHICULO> lista_ALTA_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_VEHICULO> base_ALTA_VEHICULOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_VEHICULO { get; set; }
        internal ListFilter<Int32> NID_VEHICULOs { get; set; }

        internal IntegerFilter NID_MARCA { get; set; }
        internal ListFilter<Int32> NID_MARCAs { get; set; }

        internal StringFilter C_MODELO { get; set; }
        internal ListFilter<String> C_MODELOs { get; set; }

        internal StringFilter V_DESCRIPCION { get; set; }
        internal ListFilter<String> V_DESCRIPCIONs { get; set; }

        internal DateTimeFilter F_ADQUISICION { get; set; }
        internal ListFilter<DateTime> F_ADQUISICIONs { get; set; }

        internal IntegerFilter NID_TIPO_VEHICULO { get; set; }
        internal ListFilter<Int32> NID_TIPO_VEHICULOs { get; set; }

        internal IntegerFilter NID_USO { get; set; }
        internal ListFilter<Int32> NID_USOs { get; set; }

        internal DecimalFilter M_VALOR_VEHICULO { get; set; }
        internal ListFilter<Decimal> M_VALOR_VEHICULOs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }


        private List<Order> _OrderByCriterios;
        internal List<Order> OrderByCriterios
        {
            get 
            {
                if (_OrderByCriterios == null) _OrderByCriterios = new List<Order>();
                return _OrderByCriterios; 
            }
            set { _OrderByCriterios = value; }
        }


        protected IQueryable<Declara_V2.MODELextended.ALTA_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_VEHICULO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA_VEHICULO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_VEHICULOs = new ListFilter<Int32>();
            NID_MARCAs = new ListFilter<Int32>();
            C_MODELOs = new ListFilter<String>();
            V_DESCRIPCIONs = new ListFilter<String>();
            F_ADQUISICIONs = new ListFilter<DateTime>();
            NID_TIPO_VEHICULOs = new ListFilter<Int32>();
            NID_USOs = new ListFilter<Int32>();
            M_VALOR_VEHICULOs = new ListFilter<Decimal>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA_VEHICULO
                           select p;
        }

        protected void Select()
        {

            query = from qALTA_VEHICULO in db.ALTA_VEHICULO
                    join qCAT_MARCA_VEHICULO in db.CAT_MARCA_VEHICULO on qALTA_VEHICULO.NID_MARCA
                                                                  equals qCAT_MARCA_VEHICULO.NID_MARCA
                    join qCAT_TIPO_VEHICULO in db.CAT_TIPO_VEHICULO on qALTA_VEHICULO.NID_TIPO_VEHICULO
                                                                equals qCAT_TIPO_VEHICULO.NID_TIPO_VEHICULO
                    join qCAT_USO_VEHICULO in db.CAT_USO_VEHICULO on qALTA_VEHICULO.NID_USO
                                                              equals qCAT_USO_VEHICULO.NID_USO
                    select new Declara_V2.MODELextended.ALTA_VEHICULO
                    {
                        VID_NOMBRE = qALTA_VEHICULO.VID_NOMBRE,
                        VID_FECHA = qALTA_VEHICULO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_VEHICULO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_VEHICULO.NID_DECLARACION,
                        NID_VEHICULO = qALTA_VEHICULO.NID_VEHICULO,
                        NID_MARCA = qALTA_VEHICULO.NID_MARCA,
                        C_MODELO = qALTA_VEHICULO.C_MODELO,
                        V_DESCRIPCION = qALTA_VEHICULO.V_DESCRIPCION,
                        F_ADQUISICION = qALTA_VEHICULO.F_ADQUISICION,
                        NID_TIPO_VEHICULO = qALTA_VEHICULO.NID_TIPO_VEHICULO,
                        NID_USO = qALTA_VEHICULO.NID_USO,
                        M_VALOR_VEHICULO = qALTA_VEHICULO.M_VALOR_VEHICULO,
                        NID_PATRIMONIO = qALTA_VEHICULO.NID_PATRIMONIO,
                        V_MARCA = qCAT_MARCA_VEHICULO.V_MARCA,
                        V_USO = qCAT_USO_VEHICULO.V_USO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_VEHICULOs.Count > 0) single_query =  (NID_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_VEHICULOs.Contains(p.NID_VEHICULO)) : single_query.Where(p => !NID_VEHICULOs.Contains(p.NID_VEHICULO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_VEHICULO.ToString(), single_query);

            if (NID_MARCAs.Count > 0) single_query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : single_query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_MARCA.ToString(), single_query);

            if (C_MODELOs.Count > 0) single_query =  (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_MODELOs.Contains(p.C_MODELO)) : single_query.Where(p => !C_MODELOs.Contains(p.C_MODELO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(C_MODELO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.C_MODELO.ToString(), single_query);

            if (V_DESCRIPCIONs.Count > 0) single_query =  (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DESCRIPCIONs.Contains(p.V_DESCRIPCION)) : single_query.Where(p => !V_DESCRIPCIONs.Contains(p.V_DESCRIPCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.V_DESCRIPCION.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(F_ADQUISICION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.F_ADQUISICION.ToString(), single_query);

            if (NID_TIPO_VEHICULOs.Count > 0) single_query =  (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO)) : single_query.Where(p => !NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_TIPO_VEHICULO.ToString(), single_query);

            if (NID_USOs.Count > 0) single_query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_USOs.Contains(p.NID_USO)) : single_query.Where(p => !NID_USOs.Contains(p.NID_USO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_USO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_USO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(M_VALOR_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.M_VALOR_VEHICULO.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_PATRIMONIO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_VEHICULOs.Count > 0) query =  (NID_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_VEHICULOs.Contains(p.NID_VEHICULO)) : query.Where(p => !NID_VEHICULOs.Contains(p.NID_VEHICULO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_VEHICULO.ToString(), query);

            if (NID_MARCAs.Count > 0) query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_MARCA.ToString(), query);

            if (C_MODELOs.Count > 0) query =  (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_MODELOs.Contains(p.C_MODELO)) : query.Where(p => !C_MODELOs.Contains(p.C_MODELO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(C_MODELO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.C_MODELO.ToString(), query);

            if (V_DESCRIPCIONs.Count > 0) query =  (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DESCRIPCIONs.Contains(p.V_DESCRIPCION)) : query.Where(p => !V_DESCRIPCIONs.Contains(p.V_DESCRIPCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.V_DESCRIPCION.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(F_ADQUISICION, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.F_ADQUISICION.ToString(), query);

            if (NID_TIPO_VEHICULOs.Count > 0) query =  (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO)) : query.Where(p => !NID_TIPO_VEHICULOs.Contains(p.NID_TIPO_VEHICULO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_TIPO_VEHICULO.ToString(), query);

            if (NID_USOs.Count > 0) query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_USOs.Contains(p.NID_USO)) : query.Where(p => !NID_USOs.Contains(p.NID_USO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_USO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_USO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(M_VALOR_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.M_VALOR_VEHICULO.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO>(NID_PATRIMONIO, Declara_V2.MODELextended.ALTA_VEHICULO.Properties.NID_PATRIMONIO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTA_VEHICULOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTA_VEHICULOs = new List<MODELDeclara_V2.ALTA_VEHICULO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTA_VEHICULOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTA_VEHICULOs = new List<Declara_V2.MODELextended.ALTA_VEHICULO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x <OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                single_query = r;
            }
        }

        internal void orderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                query = r;
            }
        }


        internal void clearOrderBy()
        {
            _OrderByCriterios = null;
        }

     #endregion

    }
}
