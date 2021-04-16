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
    internal class dal__l_DECLARACION_DOM_LABORAL : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL> lista_DECLARACION_DOM_LABORALs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_DOM_LABORAL> base_DECLARACION_DOM_LABORALs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal StringFilter C_CODIGO_POSTAL { get; set; }
        internal ListFilter<String> C_CODIGO_POSTALs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter CID_MUNICIPIO { get; set; }
        internal ListFilter<String> CID_MUNICIPIOs { get; set; }

        internal StringFilter V_COLONIA { get; set; }
        internal ListFilter<String> V_COLONIAs { get; set; }

        internal StringFilter V_DOMICILIO { get; set; }
        internal ListFilter<String> V_DOMICILIOs { get; set; }

        internal StringFilter V_CORREO_LABORAL { get; set; }
        internal ListFilter<String> V_CORREO_LABORALs { get; set; }

        internal StringFilter V_TEL_LABORAL { get; set; }
        internal ListFilter<String> V_TEL_LABORALs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_DOM_LABORAL> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_DECLARACION_DOM_LABORAL()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            C_CODIGO_POSTALs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            V_COLONIAs = new ListFilter<String>();
            V_DOMICILIOs = new ListFilter<String>();
            V_CORREO_LABORALs = new ListFilter<String>();
            V_TEL_LABORALs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_DOM_LABORAL
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION_DOM_LABORAL in db.DECLARACION_DOM_LABORAL
                    join qDECLARACION in db.DECLARACION on new { qDECLARACION_DOM_LABORAL.VID_NOMBRE, qDECLARACION_DOM_LABORAL.VID_FECHA, qDECLARACION_DOM_LABORAL.VID_HOMOCLAVE, qDECLARACION_DOM_LABORAL.NID_DECLARACION }
                                                    equals new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE, qDECLARACION.NID_DECLARACION }
                    select new Declara_V2.MODELextended.DECLARACION_DOM_LABORAL
                    {
                        VID_NOMBRE = qDECLARACION_DOM_LABORAL.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_DOM_LABORAL.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_DOM_LABORAL.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_DOM_LABORAL.NID_DECLARACION,
                        C_CODIGO_POSTAL = qDECLARACION_DOM_LABORAL.C_CODIGO_POSTAL,
                        NID_PAIS = qDECLARACION_DOM_LABORAL.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qDECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qDECLARACION_DOM_LABORAL.CID_MUNICIPIO,
                        V_COLONIA = qDECLARACION_DOM_LABORAL.V_COLONIA,
                        V_DOMICILIO = qDECLARACION_DOM_LABORAL.V_DOMICILIO,
                        V_CORREO_LABORAL = qDECLARACION_DOM_LABORAL.V_CORREO_LABORAL,
                        V_TEL_LABORAL = qDECLARACION_DOM_LABORAL.V_TEL_LABORAL,
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
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.NID_DECLARACION.ToString(), single_query);

            if (C_CODIGO_POSTALs.Count > 0) single_query =  (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL)) : single_query.Where(p => !C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(C_CODIGO_POSTAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.C_CODIGO_POSTAL.ToString(), single_query);

            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (CID_MUNICIPIOs.Count > 0) single_query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(CID_MUNICIPIO, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.CID_MUNICIPIO.ToString(), single_query);

            if (V_COLONIAs.Count > 0) single_query =  (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_COLONIAs.Contains(p.V_COLONIA)) : single_query.Where(p => !V_COLONIAs.Contains(p.V_COLONIA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(V_COLONIA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_COLONIA.ToString(), single_query);

            if (V_DOMICILIOs.Count > 0) single_query =  (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DOMICILIOs.Contains(p.V_DOMICILIO)) : single_query.Where(p => !V_DOMICILIOs.Contains(p.V_DOMICILIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(V_DOMICILIO, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_DOMICILIO.ToString(), single_query);

            if (V_CORREO_LABORALs.Count > 0) single_query =  (V_CORREO_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CORREO_LABORALs.Contains(p.V_CORREO_LABORAL)) : single_query.Where(p => !V_CORREO_LABORALs.Contains(p.V_CORREO_LABORAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(V_CORREO_LABORAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_CORREO_LABORAL.ToString(), single_query);

            if (V_TEL_LABORALs.Count > 0) single_query =  (V_TEL_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_TEL_LABORALs.Contains(p.V_TEL_LABORAL)) : single_query.Where(p => !V_TEL_LABORALs.Contains(p.V_TEL_LABORAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DOM_LABORAL>(V_TEL_LABORAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_TEL_LABORAL.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.NID_DECLARACION.ToString(), query);

            if (C_CODIGO_POSTALs.Count > 0) query =  (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL)) : query.Where(p => !C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(C_CODIGO_POSTAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.C_CODIGO_POSTAL.ToString(), query);

            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(NID_PAIS, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (CID_MUNICIPIOs.Count > 0) query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(CID_MUNICIPIO, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.CID_MUNICIPIO.ToString(), query);

            if (V_COLONIAs.Count > 0) query =  (V_COLONIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_COLONIAs.Contains(p.V_COLONIA)) : query.Where(p => !V_COLONIAs.Contains(p.V_COLONIA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(V_COLONIA, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_COLONIA.ToString(), query);

            if (V_DOMICILIOs.Count > 0) query =  (V_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DOMICILIOs.Contains(p.V_DOMICILIO)) : query.Where(p => !V_DOMICILIOs.Contains(p.V_DOMICILIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(V_DOMICILIO, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_DOMICILIO.ToString(), query);

            if (V_CORREO_LABORALs.Count > 0) query =  (V_CORREO_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CORREO_LABORALs.Contains(p.V_CORREO_LABORAL)) : query.Where(p => !V_CORREO_LABORALs.Contains(p.V_CORREO_LABORAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(V_CORREO_LABORAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_CORREO_LABORAL.ToString(), query);

            if (V_TEL_LABORALs.Count > 0) query =  (V_TEL_LABORALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_TEL_LABORALs.Contains(p.V_TEL_LABORAL)) : query.Where(p => !V_TEL_LABORALs.Contains(p.V_TEL_LABORAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>(V_TEL_LABORAL, Declara_V2.MODELextended.DECLARACION_DOM_LABORAL.Properties.V_TEL_LABORAL.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACION_DOM_LABORALs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACION_DOM_LABORALs = new List<MODELDeclara_V2.DECLARACION_DOM_LABORAL>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_DOM_LABORALs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_DOM_LABORALs = new List<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_DOM_LABORAL> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_DOM_LABORAL> r;
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
