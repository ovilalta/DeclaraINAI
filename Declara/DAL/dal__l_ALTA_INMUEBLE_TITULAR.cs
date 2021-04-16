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
    internal class dal__l_ALTA_INMUEBLE_TITULAR : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR> lista_ALTA_INMUEBLE_TITULARs { get; set; }
        internal List<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR> base_ALTA_INMUEBLE_TITULARs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_INMUEBLE { get; set; }
        internal ListFilter<Int32> NID_INMUEBLEs { get; set; }

        internal IntegerFilter NID_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

        internal StringFilter L_DIF { get; set; }
        internal ListFilter<String> L_DIFs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA_INMUEBLE_TITULAR()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_INMUEBLEs = new ListFilter<Int32>();
            NID_DEPENDIENTEs = new ListFilter<Int32>();
            L_DIFs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA_INMUEBLE_TITULAR
                           select p;
        }

        protected void Select()
        {

            query = from qALTA_INMUEBLE_TITULAR in db.ALTA_INMUEBLE_TITULAR
                    select new Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR
                    {
                        VID_NOMBRE = qALTA_INMUEBLE_TITULAR.VID_NOMBRE,
                        VID_FECHA = qALTA_INMUEBLE_TITULAR.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_INMUEBLE_TITULAR.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_INMUEBLE_TITULAR.NID_DECLARACION,
                        NID_INMUEBLE = qALTA_INMUEBLE_TITULAR.NID_INMUEBLE,
                        NID_DEPENDIENTE = qALTA_INMUEBLE_TITULAR.NID_DEPENDIENTE,
                        L_DIF = qALTA_INMUEBLE_TITULAR.L_DIF,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_INMUEBLEs.Count > 0) single_query =  (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INMUEBLEs.Contains(p.NID_INMUEBLE)) : single_query.Where(p => !NID_INMUEBLEs.Contains(p.NID_INMUEBLE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_INMUEBLE.ToString(), single_query);

            if (NID_DEPENDIENTEs.Count > 0) single_query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(NID_DEPENDIENTE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_DEPENDIENTE.ToString(), single_query);

            //if (L_DIFs.Count > 0) single_query =  (L_DIFs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => L_DIFs.Contains(p.L_DIF)) : single_query.Where(p => !L_DIFs.Contains(p.L_DIF));
            //single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>(L_DIF, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.L_DIF.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(VID_FECHA, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_DECLARACION.ToString(), query);

            if (NID_INMUEBLEs.Count > 0) query =  (NID_INMUEBLEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INMUEBLEs.Contains(p.NID_INMUEBLE)) : query.Where(p => !NID_INMUEBLEs.Contains(p.NID_INMUEBLE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(NID_INMUEBLE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_INMUEBLE.ToString(), query);

            if (NID_DEPENDIENTEs.Count > 0) query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(NID_DEPENDIENTE, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.NID_DEPENDIENTE.ToString(), query);

            //if (L_DIFs.Count > 0) query =  (L_DIFs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => L_DIFs.Contains(p.L_DIF)) : query.Where(p => !L_DIFs.Contains(p.L_DIF));
            //query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>(L_DIF, Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR.Properties.L_DIF.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTA_INMUEBLE_TITULARs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTA_INMUEBLE_TITULARs = new List<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTA_INMUEBLE_TITULARs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTA_INMUEBLE_TITULARs = new List<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_INMUEBLE_TITULAR> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_INMUEBLE_TITULAR> r;
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
