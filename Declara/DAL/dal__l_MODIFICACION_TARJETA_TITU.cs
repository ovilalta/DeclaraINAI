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
    internal class dal__l_MODIFICACION_TARJETA_TITU : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU> lista_MODIFICACION_TARJETA_TITUs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_TARJETA_TITU> base_MODIFICACION_TARJETA_TITUs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal StringFilter E_NUMERO { get; set; }
        internal ListFilter<String> E_NUMEROs { get; set; }

        internal IntegerFilter NID_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

        internal System.Nullable<Boolean> L_DIF { get; set; }
        internal ListFilter<Boolean> L_DIFs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_TARJETA_TITU> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_TARJETA_TITU()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            E_NUMEROs = new ListFilter<String>();
            NID_DEPENDIENTEs = new ListFilter<Int32>();
            L_DIFs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_TARJETA_TITU
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_TARJETA_TITU in db.MODIFICACION_TARJETA_TITU
                    select new Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU
                    {
                        VID_NOMBRE = qMODIFICACION_TARJETA_TITU.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_TARJETA_TITU.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_TARJETA_TITU.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_TARJETA_TITU.NID_DECLARACION,
                        E_NUMERO = qMODIFICACION_TARJETA_TITU.E_NUMERO,
                        NID_DEPENDIENTE = qMODIFICACION_TARJETA_TITU.NID_DEPENDIENTE,
                        L_DIF = qMODIFICACION_TARJETA_TITU.L_DIF,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.NID_DECLARACION.ToString(), single_query);

            if (E_NUMEROs.Count > 0) single_query =  (E_NUMEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NUMEROs.Contains(p.E_NUMERO)) : single_query.Where(p => !E_NUMEROs.Contains(p.E_NUMERO));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(E_NUMERO, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.E_NUMERO.ToString(), single_query);

            if (NID_DEPENDIENTEs.Count > 0) single_query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(NID_DEPENDIENTE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.NID_DEPENDIENTE.ToString(), single_query);

            if (L_DIF.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>(p => p.L_DIF == L_DIF );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.NID_DECLARACION.ToString(), query);

            if (E_NUMEROs.Count > 0) query =  (E_NUMEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NUMEROs.Contains(p.E_NUMERO)) : query.Where(p => !E_NUMEROs.Contains(p.E_NUMERO));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(E_NUMERO, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.E_NUMERO.ToString(), query);

            if (NID_DEPENDIENTEs.Count > 0) query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(NID_DEPENDIENTE, Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU.Properties.NID_DEPENDIENTE.ToString(), query);

            if (L_DIF.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>(p => p.L_DIF == L_DIF );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_TARJETA_TITUs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_TARJETA_TITUs = new List<MODELDeclara_V2.MODIFICACION_TARJETA_TITU>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_TARJETA_TITUs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_TARJETA_TITUs = new List<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_TARJETA_TITU> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_TARJETA_TITU> r;
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
