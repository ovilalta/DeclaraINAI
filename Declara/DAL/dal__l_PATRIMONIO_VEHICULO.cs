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
    internal class dal__l_PATRIMONIO_VEHICULO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.PATRIMONIO_VEHICULO> lista_PATRIMONIO_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.PATRIMONIO_VEHICULO> base_PATRIMONIO_VEHICULOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal IntegerFilter NID_MARCA { get; set; }
        internal ListFilter<Int32> NID_MARCAs { get; set; }

        internal StringFilter C_MODELO { get; set; }
        internal ListFilter<String> C_MODELOs { get; set; }

        internal StringFilter V_DESCRIPCION { get; set; }
        internal ListFilter<String> V_DESCRIPCIONs { get; set; }

        internal DateTimeFilter F_ADQUISICION { get; set; }
        internal ListFilter<DateTime> F_ADQUISICIONs { get; set; }

        internal IntegerFilter NID_USO { get; set; }
        internal ListFilter<Int32> NID_USOs { get; set; }

        internal DecimalFilter M_VALOR_VEHICULO { get; set; }
        internal ListFilter<Decimal> M_VALOR_VEHICULOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.PATRIMONIO_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.PATRIMONIO_VEHICULO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_PATRIMONIO_VEHICULO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_MARCAs = new ListFilter<Int32>();
            C_MODELOs = new ListFilter<String>();
            V_DESCRIPCIONs = new ListFilter<String>();
            F_ADQUISICIONs = new ListFilter<DateTime>();
            NID_USOs = new ListFilter<Int32>();
            M_VALOR_VEHICULOs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.PATRIMONIO_VEHICULO
                           select p;
        }

        protected void Select()
        {

            query = from qPATRIMONIO_VEHICULO in db.PATRIMONIO_VEHICULO
                    join qCAT_MARCA_VEHICULO in db.CAT_MARCA_VEHICULO on qPATRIMONIO_VEHICULO.NID_MARCA
                                                                  equals qCAT_MARCA_VEHICULO.NID_MARCA
                    join qCAT_USO_VEHICULO in db.CAT_USO_VEHICULO on qPATRIMONIO_VEHICULO.NID_USO
                                                              equals qCAT_USO_VEHICULO.NID_USO
                    join qPATRIMONIO in db.PATRIMONIO on new { qPATRIMONIO_VEHICULO.VID_NOMBRE, qPATRIMONIO_VEHICULO.VID_FECHA, qPATRIMONIO_VEHICULO.VID_HOMOCLAVE, qPATRIMONIO_VEHICULO.NID_PATRIMONIO }
                                                  equals new { qPATRIMONIO.VID_NOMBRE, qPATRIMONIO.VID_FECHA, qPATRIMONIO.VID_HOMOCLAVE, qPATRIMONIO.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.PATRIMONIO_VEHICULO
                    {
                        VID_NOMBRE = qPATRIMONIO_VEHICULO.VID_NOMBRE,
                        VID_FECHA = qPATRIMONIO_VEHICULO.VID_FECHA,
                        VID_HOMOCLAVE = qPATRIMONIO_VEHICULO.VID_HOMOCLAVE,
                        NID_PATRIMONIO = qPATRIMONIO_VEHICULO.NID_PATRIMONIO,
                        NID_MARCA = qPATRIMONIO_VEHICULO.NID_MARCA,
                        C_MODELO = qPATRIMONIO_VEHICULO.C_MODELO,
                        V_DESCRIPCION = qPATRIMONIO_VEHICULO.V_DESCRIPCION,
                        F_ADQUISICION = qPATRIMONIO_VEHICULO.F_ADQUISICION,
                        NID_USO = qPATRIMONIO_VEHICULO.NID_USO,
                        M_VALOR_VEHICULO = qPATRIMONIO_VEHICULO.M_VALOR_VEHICULO,
                        V_MARCA = qCAT_MARCA_VEHICULO.V_MARCA,
                        V_USO = qCAT_USO_VEHICULO.V_USO,
                        NID_TIPO = qPATRIMONIO.NID_TIPO,
                        M_VALOR = qPATRIMONIO.M_VALOR,
                        NID_DEC_INCOR = qPATRIMONIO.NID_DEC_INCOR,
                        F_INCORPORACION = qPATRIMONIO.F_INCORPORACION,
                        NID_DEC_ULT_MOD = qPATRIMONIO.NID_DEC_ULT_MOD,
                        F_MODIFICACION = qPATRIMONIO.F_MODIFICACION,
                        L_ACTIVO = qPATRIMONIO.L_ACTIVO,
                        F_REGISTRO = qPATRIMONIO.F_REGISTRO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_MARCAs.Count > 0) single_query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : single_query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_MARCA.ToString(), single_query);

            if (C_MODELOs.Count > 0) single_query =  (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_MODELOs.Contains(p.C_MODELO)) : single_query.Where(p => !C_MODELOs.Contains(p.C_MODELO));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(C_MODELO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.C_MODELO.ToString(), single_query);

            if (V_DESCRIPCIONs.Count > 0) single_query =  (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DESCRIPCIONs.Contains(p.V_DESCRIPCION)) : single_query.Where(p => !V_DESCRIPCIONs.Contains(p.V_DESCRIPCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.V_DESCRIPCION.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(F_ADQUISICION, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.F_ADQUISICION.ToString(), single_query);

            if (NID_USOs.Count > 0) single_query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_USOs.Contains(p.NID_USO)) : single_query.Where(p => !NID_USOs.Contains(p.NID_USO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(NID_USO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_USO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_VEHICULO>(M_VALOR_VEHICULO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.M_VALOR_VEHICULO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_MARCAs.Count > 0) query =  (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_MARCAs.Contains(p.NID_MARCA)) : query.Where(p => !NID_MARCAs.Contains(p.NID_MARCA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_MARCA.ToString(), query);

            if (C_MODELOs.Count > 0) query =  (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_MODELOs.Contains(p.C_MODELO)) : query.Where(p => !C_MODELOs.Contains(p.C_MODELO));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(C_MODELO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.C_MODELO.ToString(), query);

            if (V_DESCRIPCIONs.Count > 0) query =  (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DESCRIPCIONs.Contains(p.V_DESCRIPCION)) : query.Where(p => !V_DESCRIPCIONs.Contains(p.V_DESCRIPCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.V_DESCRIPCION.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(F_ADQUISICION, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.F_ADQUISICION.ToString(), query);

            if (NID_USOs.Count > 0) query =  (NID_USOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_USOs.Contains(p.NID_USO)) : query.Where(p => !NID_USOs.Contains(p.NID_USO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(NID_USO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.NID_USO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>(M_VALOR_VEHICULO, Declara_V2.MODELextended.PATRIMONIO_VEHICULO.Properties.M_VALOR_VEHICULO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_PATRIMONIO_VEHICULOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_PATRIMONIO_VEHICULOs = new List<MODELDeclara_V2.PATRIMONIO_VEHICULO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_PATRIMONIO_VEHICULOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_PATRIMONIO_VEHICULOs = new List<Declara_V2.MODELextended.PATRIMONIO_VEHICULO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.PATRIMONIO_VEHICULO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.PATRIMONIO_VEHICULO> r;
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
