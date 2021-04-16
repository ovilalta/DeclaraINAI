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
    internal class dal__l_MODIFICACION_GASTO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_GASTO> lista_MODIFICACION_GASTOs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_GASTO> base_MODIFICACION_GASTOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_GASTO { get; set; }
        internal ListFilter<Int32> NID_GASTOs { get; set; }

        internal StringFilter V_GASTO { get; set; }
        internal ListFilter<String> V_GASTOs { get; set; }

        internal DecimalFilter M_GASTO { get; set; }
        internal ListFilter<Decimal> M_GASTOs { get; set; }

        internal System.Nullable<Boolean> L_AUTOGENERADO { get; set; }
        internal ListFilter<Boolean> L_AUTOGENERADOs { get; set; }

        internal IntegerFilter NID_PATRIMONIO_ASC { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIO_ASCs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_GASTO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_GASTO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_GASTO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_GASTOs = new ListFilter<Int32>();
            V_GASTOs = new ListFilter<String>();
            M_GASTOs = new ListFilter<Decimal>();
            L_AUTOGENERADOs = new ListFilter<Boolean>();
            NID_PATRIMONIO_ASCs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_GASTO
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_GASTO in db.MODIFICACION_GASTO
                    select new Declara_V2.MODELextended.MODIFICACION_GASTO
                    {
                        VID_NOMBRE = qMODIFICACION_GASTO.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_GASTO.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_GASTO.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_GASTO.NID_DECLARACION,
                        NID_GASTO = qMODIFICACION_GASTO.NID_GASTO,
                        V_GASTO = qMODIFICACION_GASTO.V_GASTO,
                        M_GASTO = qMODIFICACION_GASTO.M_GASTO,
                        L_AUTOGENERADO = qMODIFICACION_GASTO.L_AUTOGENERADO,
                        NID_PATRIMONIO_ASC = qMODIFICACION_GASTO.NID_PATRIMONIO_ASC,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_GASTOs.Count > 0) single_query =  (NID_GASTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_GASTOs.Contains(p.NID_GASTO)) : single_query.Where(p => !NID_GASTOs.Contains(p.NID_GASTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(NID_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_GASTO.ToString(), single_query);

            if (V_GASTOs.Count > 0) single_query =  (V_GASTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_GASTOs.Contains(p.V_GASTO)) : single_query.Where(p => !V_GASTOs.Contains(p.V_GASTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(V_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.V_GASTO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(M_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.M_GASTO.ToString(), single_query);

            if (L_AUTOGENERADO.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_GASTO>(p => p.L_AUTOGENERADO == L_AUTOGENERADO );

            if (NID_PATRIMONIO_ASCs.Count > 0) single_query =  (NID_PATRIMONIO_ASCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIO_ASCs.Contains(p.NID_PATRIMONIO_ASC.Value)) : single_query.Where(p => !NID_PATRIMONIO_ASCs.Contains(p.NID_PATRIMONIO_ASC.Value));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_GASTO>(NID_PATRIMONIO_ASC, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_PATRIMONIO_ASC.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_GASTOs.Count > 0) query =  (NID_GASTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_GASTOs.Contains(p.NID_GASTO)) : query.Where(p => !NID_GASTOs.Contains(p.NID_GASTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(NID_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_GASTO.ToString(), query);

            if (V_GASTOs.Count > 0) query =  (V_GASTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_GASTOs.Contains(p.V_GASTO)) : query.Where(p => !V_GASTOs.Contains(p.V_GASTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(V_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.V_GASTO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(M_GASTO, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.M_GASTO.ToString(), query);

            if (L_AUTOGENERADO.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_GASTO>(p => p.L_AUTOGENERADO == L_AUTOGENERADO );

            if (NID_PATRIMONIO_ASCs.Count > 0) query =  (NID_PATRIMONIO_ASCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIO_ASCs.Contains(p.NID_PATRIMONIO_ASC.Value)) : query.Where(p => !NID_PATRIMONIO_ASCs.Contains(p.NID_PATRIMONIO_ASC.Value));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_GASTO>(NID_PATRIMONIO_ASC, Declara_V2.MODELextended.MODIFICACION_GASTO.Properties.NID_PATRIMONIO_ASC.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_GASTOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_GASTOs = new List<MODELDeclara_V2.MODIFICACION_GASTO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_GASTOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_GASTOs = new List<Declara_V2.MODELextended.MODIFICACION_GASTO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_GASTO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_GASTO> r;
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
