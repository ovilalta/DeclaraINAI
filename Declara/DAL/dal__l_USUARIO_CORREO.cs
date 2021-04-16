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
    internal class dal__l_USUARIO_CORREO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.USUARIO_CORREO> lista_USUARIO_CORREOs { get; set; }
        internal List<MODELDeclara_V2.USUARIO_CORREO> base_USUARIO_CORREOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal StringFilter V_CORREO { get; set; }
        internal ListFilter<String> V_CORREOs { get; set; }

        internal System.Nullable<Boolean> L_PRINCIPAL { get; set; }
        internal ListFilter<Boolean> L_PRINCIPALs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }

        internal System.Nullable<Boolean> L_CONFIRMADO { get; set; }
        internal ListFilter<Boolean> L_CONFIRMADOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.USUARIO_CORREO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.USUARIO_CORREO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_USUARIO_CORREO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            V_CORREOs = new ListFilter<String>();
            L_PRINCIPALs = new ListFilter<Boolean>();
            L_ACTIVOs = new ListFilter<Boolean>();
            L_CONFIRMADOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.USUARIO_CORREO
                           select p;
        }

        protected void Select()
        {

            query = from qUSUARIO_CORREO in db.USUARIO_CORREO
                    select new Declara_V2.MODELextended.USUARIO_CORREO
                    {
                        VID_NOMBRE = qUSUARIO_CORREO.VID_NOMBRE,
                        VID_FECHA = qUSUARIO_CORREO.VID_FECHA,
                        VID_HOMOCLAVE = qUSUARIO_CORREO.VID_HOMOCLAVE,
                        V_CORREO = qUSUARIO_CORREO.V_CORREO,
                        L_PRINCIPAL = qUSUARIO_CORREO.L_PRINCIPAL,
                        L_ACTIVO = qUSUARIO_CORREO.L_ACTIVO,
                        L_CONFIRMADO = qUSUARIO_CORREO.L_CONFIRMADO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_CORREO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_CORREO>(VID_FECHA, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_CORREO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (V_CORREOs.Count > 0) single_query =  (V_CORREOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CORREOs.Contains(p.V_CORREO)) : single_query.Where(p => !V_CORREOs.Contains(p.V_CORREO));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_CORREO>(V_CORREO, Declara_V2.MODELextended.USUARIO_CORREO.Properties.V_CORREO.ToString(), single_query);

            if (L_PRINCIPAL.HasValue) single_query = single_query.Where<MODELDeclara_V2.USUARIO_CORREO>(p => p.L_PRINCIPAL == L_PRINCIPAL );

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.USUARIO_CORREO>(p => p.L_ACTIVO == L_ACTIVO );

            if (L_CONFIRMADO.HasValue) single_query = single_query.Where<MODELDeclara_V2.USUARIO_CORREO>(p => p.L_CONFIRMADO == L_CONFIRMADO );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_CORREO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_CORREO>(VID_FECHA, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_CORREO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_CORREO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (V_CORREOs.Count > 0) query =  (V_CORREOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CORREOs.Contains(p.V_CORREO)) : query.Where(p => !V_CORREOs.Contains(p.V_CORREO));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_CORREO>(V_CORREO, Declara_V2.MODELextended.USUARIO_CORREO.Properties.V_CORREO.ToString(), query);

            if (L_PRINCIPAL.HasValue) query = query.Where<Declara_V2.MODELextended.USUARIO_CORREO>(p => p.L_PRINCIPAL == L_PRINCIPAL );

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.USUARIO_CORREO>(p => p.L_ACTIVO == L_ACTIVO );

            if (L_CONFIRMADO.HasValue) query = query.Where<Declara_V2.MODELextended.USUARIO_CORREO>(p => p.L_CONFIRMADO == L_CONFIRMADO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_USUARIO_CORREOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_USUARIO_CORREOs = new List<MODELDeclara_V2.USUARIO_CORREO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_USUARIO_CORREOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_USUARIO_CORREOs = new List<Declara_V2.MODELextended.USUARIO_CORREO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.USUARIO_CORREO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.USUARIO_CORREO> r;
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
