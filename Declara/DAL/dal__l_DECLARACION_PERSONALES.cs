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
    internal class dal__l_DECLARACION_PERSONALES : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_PERSONALES> lista_DECLARACION_PERSONALESs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_PERSONALES> base_DECLARACION_PERSONALESs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal StringFilter C_GENERO { get; set; }
        internal ListFilter<String> C_GENEROs { get; set; }

        internal StringFilter C_CURP { get; set; }
        internal ListFilter<String> C_CURPs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal IntegerFilter NID_NACIONALIDAD { get; set; }
        internal ListFilter<Int32> NID_NACIONALIDADs { get; set; }

        internal IntegerFilter NID_ESTADO_CIVIL { get; set; }
        internal ListFilter<Int32> NID_ESTADO_CIVILs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION_PERSONALES> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_PERSONALES> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_DECLARACION_PERSONALES()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            C_GENEROs = new ListFilter<String>();
            C_CURPs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            NID_NACIONALIDADs = new ListFilter<Int32>();
            NID_ESTADO_CIVILs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_PERSONALES
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION_PERSONALES in db.DECLARACION_PERSONALES
                    join qCAT_ESTADO_CIVIL in db.CAT_ESTADO_CIVIL on qDECLARACION_PERSONALES.NID_ESTADO_CIVIL
                                                              equals qCAT_ESTADO_CIVIL.NID_ESTADO_CIVIL
                    join qDECLARACION in db.DECLARACION on new { qDECLARACION_PERSONALES.VID_NOMBRE, qDECLARACION_PERSONALES.VID_FECHA, qDECLARACION_PERSONALES.VID_HOMOCLAVE, qDECLARACION_PERSONALES.NID_DECLARACION }
                                                    equals new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE, qDECLARACION.NID_DECLARACION }
                    select new Declara_V2.MODELextended.DECLARACION_PERSONALES
                    {
                        VID_NOMBRE = qDECLARACION_PERSONALES.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_PERSONALES.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_PERSONALES.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_PERSONALES.NID_DECLARACION,
                        C_GENERO = qDECLARACION_PERSONALES.C_GENERO,
                        C_CURP = qDECLARACION_PERSONALES.C_CURP,
                        NID_PAIS = qDECLARACION_PERSONALES.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qDECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA,
                        NID_NACIONALIDAD = qDECLARACION_PERSONALES.NID_NACIONALIDAD,
                        NID_ESTADO_CIVIL = qDECLARACION_PERSONALES.NID_ESTADO_CIVIL,
                        V_ESTADO_CIVIL = qCAT_ESTADO_CIVIL.V_ESTADO_CIVIL,
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
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_DECLARACION.ToString(), single_query);

            if (C_GENEROs.Count > 0) single_query =  (C_GENEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_GENEROs.Contains(p.C_GENERO)) : single_query.Where(p => !C_GENEROs.Contains(p.C_GENERO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(C_GENERO, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.C_GENERO.ToString(), single_query);

            if (C_CURPs.Count > 0) single_query =  (C_CURPs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_CURPs.Contains(p.C_CURP)) : single_query.Where(p => !C_CURPs.Contains(p.C_CURP));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(C_CURP, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.C_CURP.ToString(), single_query);

            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (NID_NACIONALIDADs.Count > 0) single_query =  (NID_NACIONALIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NACIONALIDADs.Contains(p.NID_NACIONALIDAD)) : single_query.Where(p => !NID_NACIONALIDADs.Contains(p.NID_NACIONALIDAD));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(NID_NACIONALIDAD, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_NACIONALIDAD.ToString(), single_query);

            if (NID_ESTADO_CIVILs.Count > 0) single_query =  (NID_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL)) : single_query.Where(p => !NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_PERSONALES>(NID_ESTADO_CIVIL, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_ESTADO_CIVIL.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_DECLARACION.ToString(), query);

            if (C_GENEROs.Count > 0) query =  (C_GENEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_GENEROs.Contains(p.C_GENERO)) : query.Where(p => !C_GENEROs.Contains(p.C_GENERO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(C_GENERO, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.C_GENERO.ToString(), query);

            if (C_CURPs.Count > 0) query =  (C_CURPs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_CURPs.Contains(p.C_CURP)) : query.Where(p => !C_CURPs.Contains(p.C_CURP));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(C_CURP, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.C_CURP.ToString(), query);

            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (NID_NACIONALIDADs.Count > 0) query =  (NID_NACIONALIDADs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NACIONALIDADs.Contains(p.NID_NACIONALIDAD)) : query.Where(p => !NID_NACIONALIDADs.Contains(p.NID_NACIONALIDAD));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(NID_NACIONALIDAD, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_NACIONALIDAD.ToString(), query);

            if (NID_ESTADO_CIVILs.Count > 0) query =  (NID_ESTADO_CIVILs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL)) : query.Where(p => !NID_ESTADO_CIVILs.Contains(p.NID_ESTADO_CIVIL));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_PERSONALES>(NID_ESTADO_CIVIL, Declara_V2.MODELextended.DECLARACION_PERSONALES.Properties.NID_ESTADO_CIVIL.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACION_PERSONALESs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACION_PERSONALESs = new List<MODELDeclara_V2.DECLARACION_PERSONALES>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_PERSONALESs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_PERSONALESs = new List<Declara_V2.MODELextended.DECLARACION_PERSONALES>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_PERSONALES> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_PERSONALES> r;
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
