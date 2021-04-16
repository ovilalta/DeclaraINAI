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
    internal class dal__l_MODIFICACION_INGRESOS : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_INGRESOS> lista_MODIFICACION_INGRESOSs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_INGRESOS> base_MODIFICACION_INGRESOSs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_INGRESO { get; set; }
        internal ListFilter<Int32> NID_INGRESOs { get; set; }

        internal StringFilter E_ESPECIFICAR { get; set; }
        internal ListFilter<String> E_ESPECIFICARs { get; set; }

        internal DecimalFilter M_INGRESO { get; set; }
        internal ListFilter<Decimal> M_INGRESOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_INGRESOS> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_INGRESOS> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_INGRESOS()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_INGRESOs = new ListFilter<Int32>();
            E_ESPECIFICARs = new ListFilter<String>();
            M_INGRESOs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_INGRESOS
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_INGRESOS in db.MODIFICACION_INGRESOS
                    select new Declara_V2.MODELextended.MODIFICACION_INGRESOS
                    {
                        VID_NOMBRE = qMODIFICACION_INGRESOS.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_INGRESOS.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_INGRESOS.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_INGRESOS.NID_DECLARACION,
                        NID_INGRESO = qMODIFICACION_INGRESOS.NID_INGRESO,
                        E_ESPECIFICAR = qMODIFICACION_INGRESOS.E_ESPECIFICAR,
                        M_INGRESO = qMODIFICACION_INGRESOS.M_INGRESO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_INGRESOs.Count > 0) single_query =  (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INGRESOs.Contains(p.NID_INGRESO)) : single_query.Where(p => !NID_INGRESOs.Contains(p.NID_INGRESO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(NID_INGRESO, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.NID_INGRESO.ToString(), single_query);

            if (E_ESPECIFICARs.Count > 0) single_query =  (E_ESPECIFICARs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_ESPECIFICARs.Contains(p.E_ESPECIFICAR)) : single_query.Where(p => !E_ESPECIFICARs.Contains(p.E_ESPECIFICAR));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(E_ESPECIFICAR, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.E_ESPECIFICAR.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_INGRESOS>(M_INGRESO, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.M_INGRESO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.NID_DECLARACION.ToString(), query);

            if (NID_INGRESOs.Count > 0) query =  (NID_INGRESOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INGRESOs.Contains(p.NID_INGRESO)) : query.Where(p => !NID_INGRESOs.Contains(p.NID_INGRESO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(NID_INGRESO, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.NID_INGRESO.ToString(), query);

            if (E_ESPECIFICARs.Count > 0) query =  (E_ESPECIFICARs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_ESPECIFICARs.Contains(p.E_ESPECIFICAR)) : query.Where(p => !E_ESPECIFICARs.Contains(p.E_ESPECIFICAR));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(E_ESPECIFICAR, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.E_ESPECIFICAR.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_INGRESOS>(M_INGRESO, Declara_V2.MODELextended.MODIFICACION_INGRESOS.Properties.M_INGRESO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_INGRESOSs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_INGRESOSs = new List<MODELDeclara_V2.MODIFICACION_INGRESOS>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_INGRESOSs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_INGRESOSs = new List<Declara_V2.MODELextended.MODIFICACION_INGRESOS>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_INGRESOS> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_INGRESOS> r;
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
