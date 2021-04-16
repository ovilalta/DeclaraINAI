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
    internal class dal__l_ALTA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA> lista_ALTAs { get; set; }
        internal List<MODELDeclara_V2.ALTA> base_ALTAs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.ALTA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA
                           select p;
        }

        protected void Select()
        {

            query = from qALTA in db.ALTA
                    join qDECLARACION in db.DECLARACION on new { qALTA.VID_NOMBRE, qALTA.VID_FECHA, qALTA.VID_HOMOCLAVE, qALTA.NID_DECLARACION }
                                                    equals new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE, qDECLARACION.NID_DECLARACION }
                    select new Declara_V2.MODELextended.ALTA
                    {
                        VID_NOMBRE = qALTA.VID_NOMBRE,
                        VID_FECHA = qALTA.VID_FECHA,
                        VID_HOMOCLAVE = qALTA.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA.NID_DECLARACION,
                        C_EJERCICIO = qDECLARACION.C_EJERCICIO,
                        NID_TIPO_DECLARACION = qDECLARACION.NID_TIPO_DECLARACION,
                        NID_ESTADO = qDECLARACION.NID_ESTADO,
                        E_OBSERVACIONES = qDECLARACION.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qDECLARACION.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qDECLARACION.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION.NID_ESTADO_TESTADO,
                        L_AUTORIZA_PUBLICAR = qDECLARACION.L_AUTORIZA_PUBLICAR,
                        F_REGISTRO = qDECLARACION.F_REGISTRO,
                        F_ENVIO = qDECLARACION.F_ENVIO,
                        L_CONFLICTO = qDECLARACION.L_CONFLICTO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA>(VID_NOMBRE, Declara_V2.MODELextended.ALTA.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA>(VID_FECHA, Declara_V2.MODELextended.ALTA.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA>(NID_DECLARACION, Declara_V2.MODELextended.ALTA.Properties.NID_DECLARACION.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA>(VID_NOMBRE, Declara_V2.MODELextended.ALTA.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA>(VID_FECHA, Declara_V2.MODELextended.ALTA.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA>(NID_DECLARACION, Declara_V2.MODELextended.ALTA.Properties.NID_DECLARACION.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTAs = new List<MODELDeclara_V2.ALTA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTAs = new List<Declara_V2.MODELextended.ALTA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA> r;
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
