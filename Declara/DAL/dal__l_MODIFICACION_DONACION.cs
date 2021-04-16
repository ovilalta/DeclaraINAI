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
    internal class dal__l_MODIFICACION_DONACION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_DONACION> lista_MODIFICACION_DONACIONs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_DONACION> base_MODIFICACION_DONACIONs { get; set; }


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

        internal StringFilter E_ESPECIFICA { get; set; }
        internal ListFilter<String> E_ESPECIFICAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_DONACION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_DONACION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_DONACION()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            E_ESPECIFICAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_DONACION
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_DONACION in db.MODIFICACION_DONACION
                    join qMODIFICACION_BAJA in db.MODIFICACION_BAJA on new { qMODIFICACION_DONACION.VID_NOMBRE, qMODIFICACION_DONACION.VID_FECHA, qMODIFICACION_DONACION.VID_HOMOCLAVE, qMODIFICACION_DONACION.NID_DECLARACION, qMODIFICACION_DONACION.NID_PATRIMONIO }
                                                                equals new { qMODIFICACION_BAJA.VID_NOMBRE, qMODIFICACION_BAJA.VID_FECHA, qMODIFICACION_BAJA.VID_HOMOCLAVE, qMODIFICACION_BAJA.NID_DECLARACION, qMODIFICACION_BAJA.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.MODIFICACION_DONACION
                    {
                        VID_NOMBRE = qMODIFICACION_DONACION.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_DONACION.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_DONACION.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_DONACION.NID_DECLARACION,
                        NID_PATRIMONIO = qMODIFICACION_DONACION.NID_PATRIMONIO,
                        E_ESPECIFICA = qMODIFICACION_DONACION.E_ESPECIFICA,
                        NID_TIPO_BAJA = qMODIFICACION_BAJA.NID_TIPO_BAJA,
                        F_BAJA = qMODIFICACION_BAJA.F_BAJA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (E_ESPECIFICAs.Count > 0) single_query =  (E_ESPECIFICAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_ESPECIFICAs.Contains(p.E_ESPECIFICA)) : single_query.Where(p => !E_ESPECIFICAs.Contains(p.E_ESPECIFICA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_DONACION>(E_ESPECIFICA, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.E_ESPECIFICA.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.NID_PATRIMONIO.ToString(), query);

            if (E_ESPECIFICAs.Count > 0) query =  (E_ESPECIFICAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_ESPECIFICAs.Contains(p.E_ESPECIFICA)) : query.Where(p => !E_ESPECIFICAs.Contains(p.E_ESPECIFICA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_DONACION>(E_ESPECIFICA, Declara_V2.MODELextended.MODIFICACION_DONACION.Properties.E_ESPECIFICA.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_DONACIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_DONACIONs = new List<MODELDeclara_V2.MODIFICACION_DONACION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_DONACIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_DONACIONs = new List<Declara_V2.MODELextended.MODIFICACION_DONACION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_DONACION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_DONACION> r;
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
