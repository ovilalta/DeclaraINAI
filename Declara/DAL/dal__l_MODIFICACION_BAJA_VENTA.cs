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
    internal class dal__l_MODIFICACION_BAJA_VENTA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA> lista_MODIFICACION_BAJA_VENTAs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_BAJA_VENTA> base_MODIFICACION_BAJA_VENTAs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal IntegerFilter NID_TIPO_VENTA { get; set; }
        internal ListFilter<Int32> NID_TIPO_VENTAs { get; set; }

        internal DecimalFilter M_IMPORTE_VENTA { get; set; }
        internal ListFilter<Decimal> M_IMPORTE_VENTAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_BAJA_VENTA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_BAJA_VENTA()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_TIPO_VENTAs = new ListFilter<Int32>();
            M_IMPORTE_VENTAs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_BAJA_VENTA
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_BAJA_VENTA in db.MODIFICACION_BAJA_VENTA
                    join qMODIFICACION_BAJA in db.MODIFICACION_BAJA on new { qMODIFICACION_BAJA_VENTA.VID_NOMBRE, qMODIFICACION_BAJA_VENTA.VID_FECHA, qMODIFICACION_BAJA_VENTA.VID_HOMOCLAVE, qMODIFICACION_BAJA_VENTA.NID_DECLARACION, qMODIFICACION_BAJA_VENTA.NID_PATRIMONIO }
                                                                equals new { qMODIFICACION_BAJA.VID_NOMBRE, qMODIFICACION_BAJA.VID_FECHA, qMODIFICACION_BAJA.VID_HOMOCLAVE, qMODIFICACION_BAJA.NID_DECLARACION, qMODIFICACION_BAJA.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA
                    {
                        VID_NOMBRE = qMODIFICACION_BAJA_VENTA.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_BAJA_VENTA.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_BAJA_VENTA.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_BAJA_VENTA.NID_DECLARACION,
                        NID_PATRIMONIO = qMODIFICACION_BAJA_VENTA.NID_PATRIMONIO,
                        NID_TIPO_VENTA = qMODIFICACION_BAJA_VENTA.NID_TIPO_VENTA,
                        M_IMPORTE_VENTA = qMODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA,
                        NID_TIPO_BAJA = qMODIFICACION_BAJA.NID_TIPO_BAJA,
                        F_BAJA = qMODIFICACION_BAJA.F_BAJA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_TIPO_VENTAs.Count > 0) single_query =  (NID_TIPO_VENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_VENTAs.Contains(p.NID_TIPO_VENTA)) : single_query.Where(p => !NID_TIPO_VENTAs.Contains(p.NID_TIPO_VENTA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(NID_TIPO_VENTA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_TIPO_VENTA.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>(M_IMPORTE_VENTA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.M_IMPORTE_VENTA.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_TIPO_VENTAs.Count > 0) query =  (NID_TIPO_VENTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_VENTAs.Contains(p.NID_TIPO_VENTA)) : query.Where(p => !NID_TIPO_VENTAs.Contains(p.NID_TIPO_VENTA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(NID_TIPO_VENTA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.NID_TIPO_VENTA.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>(M_IMPORTE_VENTA, Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA.Properties.M_IMPORTE_VENTA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_BAJA_VENTAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_BAJA_VENTAs = new List<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_BAJA_VENTAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_BAJA_VENTAs = new List<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_BAJA_VENTA> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
