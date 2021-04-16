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
    internal class dal__l_USUARIO_DOMICILIO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.USUARIO_DOMICILIO> lista_USUARIO_DOMICILIOs { get; set; }
        internal List<MODELDeclara_V2.USUARIO_DOMICILIO> base_USUARIO_DOMICILIOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DOMICILIO { get; set; }
        internal ListFilter<Int32> NID_DOMICILIOs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        internal StringFilter CID_MUNICIPIO { get; set; }
        internal ListFilter<String> CID_MUNICIPIOs { get; set; }

        internal StringFilter C_CODIGO_POSTAL { get; set; }
        internal ListFilter<String> C_CODIGO_POSTALs { get; set; }

        internal StringFilter E_DIRECCION { get; set; }
        internal ListFilter<String> E_DIRECCIONs { get; set; }

        internal IntegerFilter NID_TIPO_DOMICILIO { get; set; }
        internal ListFilter<Int32> NID_TIPO_DOMICILIOs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.USUARIO_DOMICILIO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.USUARIO_DOMICILIO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_USUARIO_DOMICILIO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DOMICILIOs = new ListFilter<Int32>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            CID_MUNICIPIOs = new ListFilter<String>();
            C_CODIGO_POSTALs = new ListFilter<String>();
            E_DIRECCIONs = new ListFilter<String>();
            NID_TIPO_DOMICILIOs = new ListFilter<Int32>();
            L_ACTIVOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.USUARIO_DOMICILIO
                           select p;
        }

        protected void Select()
        {

            query = from qUSUARIO_DOMICILIO in db.USUARIO_DOMICILIO
                    join qCAT_MUNICIPIO in db.CAT_MUNICIPIO on new { qUSUARIO_DOMICILIO.NID_PAIS, qUSUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA, qUSUARIO_DOMICILIO.CID_MUNICIPIO }
                                                        equals new { qCAT_MUNICIPIO.NID_PAIS, qCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA, qCAT_MUNICIPIO.CID_MUNICIPIO }
                    join qCAT_TIPO_DOMICILIO in db.CAT_TIPO_DOMICILIO on qUSUARIO_DOMICILIO.NID_TIPO_DOMICILIO
                                                                  equals qCAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO
                    select new Declara_V2.MODELextended.USUARIO_DOMICILIO
                    {
                        VID_NOMBRE = qUSUARIO_DOMICILIO.VID_NOMBRE,
                        VID_FECHA = qUSUARIO_DOMICILIO.VID_FECHA,
                        VID_HOMOCLAVE = qUSUARIO_DOMICILIO.VID_HOMOCLAVE,
                        NID_DOMICILIO = qUSUARIO_DOMICILIO.NID_DOMICILIO,
                        NID_PAIS = qUSUARIO_DOMICILIO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qUSUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA,
                        CID_MUNICIPIO = qUSUARIO_DOMICILIO.CID_MUNICIPIO,
                        C_CODIGO_POSTAL = qUSUARIO_DOMICILIO.C_CODIGO_POSTAL,
                        E_DIRECCION = qUSUARIO_DOMICILIO.E_DIRECCION,
                        NID_TIPO_DOMICILIO = qUSUARIO_DOMICILIO.NID_TIPO_DOMICILIO,
                        L_ACTIVO = qUSUARIO_DOMICILIO.L_ACTIVO,
                        V_MUNICIPIO = qCAT_MUNICIPIO.V_MUNICIPIO,
                        V_TIPO_DOMICILIO = qCAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(VID_FECHA, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DOMICILIOs.Count > 0) single_query =  (NID_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DOMICILIOs.Contains(p.NID_DOMICILIO)) : single_query.Where(p => !NID_DOMICILIOs.Contains(p.NID_DOMICILIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(NID_DOMICILIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_DOMICILIO.ToString(), single_query);

            if (NID_PAISs.Count > 0) single_query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(NID_PAIS, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_PAIS.ToString(), single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) single_query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), single_query);

            if (CID_MUNICIPIOs.Count > 0) single_query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : single_query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(CID_MUNICIPIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.CID_MUNICIPIO.ToString(), single_query);

            if (C_CODIGO_POSTALs.Count > 0) single_query =  (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL)) : single_query.Where(p => !C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(C_CODIGO_POSTAL, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.C_CODIGO_POSTAL.ToString(), single_query);

            if (E_DIRECCIONs.Count > 0) single_query =  (E_DIRECCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_DIRECCIONs.Contains(p.E_DIRECCION)) : single_query.Where(p => !E_DIRECCIONs.Contains(p.E_DIRECCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(E_DIRECCION, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.E_DIRECCION.ToString(), single_query);

            if (NID_TIPO_DOMICILIOs.Count > 0) single_query =  (NID_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO)) : single_query.Where(p => !NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.USUARIO_DOMICILIO>(NID_TIPO_DOMICILIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_TIPO_DOMICILIO.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.USUARIO_DOMICILIO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(VID_FECHA, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DOMICILIOs.Count > 0) query =  (NID_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DOMICILIOs.Contains(p.NID_DOMICILIO)) : query.Where(p => !NID_DOMICILIOs.Contains(p.NID_DOMICILIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(NID_DOMICILIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_DOMICILIO.ToString(), query);

            if (NID_PAISs.Count > 0) query =  (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(NID_PAIS, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_PAIS.ToString(), query);

            if (CID_ENTIDAD_FEDERATIVAs.Count > 0) query =  (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), query);

            if (CID_MUNICIPIOs.Count > 0) query =  (CID_MUNICIPIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO)) : query.Where(p => !CID_MUNICIPIOs.Contains(p.CID_MUNICIPIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(CID_MUNICIPIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.CID_MUNICIPIO.ToString(), query);

            if (C_CODIGO_POSTALs.Count > 0) query =  (C_CODIGO_POSTALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL)) : query.Where(p => !C_CODIGO_POSTALs.Contains(p.C_CODIGO_POSTAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(C_CODIGO_POSTAL, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.C_CODIGO_POSTAL.ToString(), query);

            if (E_DIRECCIONs.Count > 0) query =  (E_DIRECCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_DIRECCIONs.Contains(p.E_DIRECCION)) : query.Where(p => !E_DIRECCIONs.Contains(p.E_DIRECCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(E_DIRECCION, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.E_DIRECCION.ToString(), query);

            if (NID_TIPO_DOMICILIOs.Count > 0) query =  (NID_TIPO_DOMICILIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO)) : query.Where(p => !NID_TIPO_DOMICILIOs.Contains(p.NID_TIPO_DOMICILIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.USUARIO_DOMICILIO>(NID_TIPO_DOMICILIO, Declara_V2.MODELextended.USUARIO_DOMICILIO.Properties.NID_TIPO_DOMICILIO.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.USUARIO_DOMICILIO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_USUARIO_DOMICILIOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_USUARIO_DOMICILIOs = new List<MODELDeclara_V2.USUARIO_DOMICILIO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_USUARIO_DOMICILIOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_USUARIO_DOMICILIOs = new List<Declara_V2.MODELextended.USUARIO_DOMICILIO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.USUARIO_DOMICILIO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.USUARIO_DOMICILIO> r;
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
