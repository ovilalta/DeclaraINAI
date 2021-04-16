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
    internal class dal__l_DECLARACION_RESTRICCIONES : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES> lista_DECLARACION_RESTRICCIONESs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_RESTRICCIONES> base_DECLARACION_RESTRICCIONESs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_RESTRICCION { get; set; }
        internal ListFilter<Int32> NID_RESTRICCIONs { get; set; }

        internal System.Nullable<Boolean> L_RESPUESTA { get; set; }
        internal ListFilter<Boolean> L_RESPUESTAs { get; set; }

        internal System.Nullable<Boolean> L_AUTO { get; set; }
        internal ListFilter<Boolean> L_AUTOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_RESTRICCIONES> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_DECLARACION_RESTRICCIONES()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_RESTRICCIONs = new ListFilter<Int32>();
            L_RESPUESTAs = new ListFilter<Boolean>();
            L_AUTOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_RESTRICCIONES
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION_RESTRICCIONES in db.DECLARACION_RESTRICCIONES
                    join qCAT_RESTRICCIONES in db.CAT_RESTRICCIONES on qDECLARACION_RESTRICCIONES.NID_RESTRICCION
                                                                equals qCAT_RESTRICCIONES.NID_RESTRICCION
                    select new Declara_V2.MODELextended.DECLARACION_RESTRICCIONES
                    {
                        VID_NOMBRE = qDECLARACION_RESTRICCIONES.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_RESTRICCIONES.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_RESTRICCIONES.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_RESTRICCIONES.NID_DECLARACION,
                        NID_RESTRICCION = qDECLARACION_RESTRICCIONES.NID_RESTRICCION,
                        L_RESPUESTA = qDECLARACION_RESTRICCIONES.L_RESPUESTA,
                        L_AUTO = qDECLARACION_RESTRICCIONES.L_AUTO,
                        V_RESTRICCION = qCAT_RESTRICCIONES.V_RESTRICCION,
                        L_VIGENTE = qCAT_RESTRICCIONES.L_VIGENTE,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_RESTRICCIONs.Count > 0) single_query =  (NID_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RESTRICCIONs.Contains(p.NID_RESTRICCION)) : single_query.Where(p => !NID_RESTRICCIONs.Contains(p.NID_RESTRICCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(NID_RESTRICCION, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.NID_RESTRICCION.ToString(), single_query);

            if (L_RESPUESTA.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(p => p.L_RESPUESTA == L_RESPUESTA );

            if (L_AUTO.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION_RESTRICCIONES>(p => p.L_AUTO == L_AUTO );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.NID_DECLARACION.ToString(), query);

            if (NID_RESTRICCIONs.Count > 0) query =  (NID_RESTRICCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RESTRICCIONs.Contains(p.NID_RESTRICCION)) : query.Where(p => !NID_RESTRICCIONs.Contains(p.NID_RESTRICCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(NID_RESTRICCION, Declara_V2.MODELextended.DECLARACION_RESTRICCIONES.Properties.NID_RESTRICCION.ToString(), query);

            if (L_RESPUESTA.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(p => p.L_RESPUESTA == L_RESPUESTA );

            if (L_AUTO.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>(p => p.L_AUTO == L_AUTO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACION_RESTRICCIONESs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACION_RESTRICCIONESs = new List<MODELDeclara_V2.DECLARACION_RESTRICCIONES>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_RESTRICCIONESs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_RESTRICCIONESs = new List<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_RESTRICCIONES> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_RESTRICCIONES> r;
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
