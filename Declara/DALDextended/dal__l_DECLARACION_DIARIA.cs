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
using Declara_V2.MODELextended;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_DIARIA : _dal_base_Declara
    {

        #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_DIARIA> lista_DECLARACION_DIARIAs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION> base_DECLARACIONs { get; set; }
        internal StringFilter V_RFC { get; set; }
        internal StringFilter V_NOMBRE_COMPLETO { get; set; }

        internal StringFilter V_NOMBRE_COMPLETO_ESTILO2 { get; set; }
        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }
        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }
        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }
        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }
        internal StringFilter C_EJERCICIO { get; set; }
        internal ListFilter<String> C_EJERCICIOs { get; set; }
        internal IntegerFilter NID_TIPO_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_TIPO_DECLARACIONs { get; set; }
        internal IntegerFilter NID_ESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADOs { get; set; }
        internal IntegerFilter NID_ESTADO_TESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_TESTADOs { get; set; }
        internal DateTimeFilter F_REGISTRO { get; set; }
        internal ListFilter<DateTime> F_REGISTROs { get; set; }
        internal DateTimeFilter F_ENVIO { get; set; }
        internal ListFilter<DateTime> F_ENVIOs { get; set; }

        internal StringFilter V_ENVIO_MES { get; set; }
        internal ListFilter<String> V_ENVIO_MESs { get; set; }
        internal IntegerFilter NID_ENVIO_DIA { get; set; }
        internal ListFilter<Int32> NID_ENVIO_DIAs { get; set; }

        internal IntegerFilter NID_ENVIO_MES { get; set; }
        internal ListFilter<Int32> NID_ENVIO_MESs { get; set; }

        internal IntegerFilter NID_ENVIO_ANIO { get; set; }
        internal ListFilter<Int32> NID_ENVIO_ANIOs { get; set; }

        internal System.Nullable<Boolean> L_AUTORIZA_PUBLICAR { get; set; }

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

        protected IQueryable<Declara_V2.MODELextended.DECLARACION_DIARIA> query { get; set; }

        #endregion


        #region *** Constructores ***

        internal dal__l_DECLARACION_DIARIA()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_TIPO_DECLARACIONs = new ListFilter<Int32>();
            NID_ESTADOs = new ListFilter<Int32>();
            F_ENVIOs = new ListFilter<DateTime>();
            NID_ENVIO_DIAs = new ListFilter<Int32>();
            NID_ENVIO_MESs = new ListFilter<Int32>();
            NID_ENVIO_ANIOs = new ListFilter<Int32>();
            NID_ESTADO_TESTADOs = new ListFilter<int>();
            query = null;
        }

        #endregion


        #region *** Metodos ***

        protected void Select()
        {

            query = from qDECLARACION in db.DECLARACION

                    join qDECLARACION_CARGO in db.DECLARACION_CARGO on new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE, qDECLARACION.NID_DECLARACION }
                                                                equals new { qDECLARACION_CARGO.VID_NOMBRE, qDECLARACION_CARGO.VID_FECHA, qDECLARACION_CARGO.VID_HOMOCLAVE, qDECLARACION_CARGO.NID_DECLARACION }

                    join qCAT_PRIMER_NIVEL in db.CAT_PRIMER_NIVEL on qDECLARACION_CARGO.VID_PRIMER_NIVEL equals qCAT_PRIMER_NIVEL.VID_PRIMER_NIVEL

                    join qCAT_SEGUNDO_NIVEL in db.CAT_SEGUNDO_NIVEL on new { qDECLARACION_CARGO.VID_PRIMER_NIVEL, qDECLARACION_CARGO.VID_SEGUNDO_NIVEL }
                                                                equals new { qCAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL, qCAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL }

                    join qCAT_PUESTO in db.CAT_PUESTO on qDECLARACION_CARGO.NID_PUESTO equals qCAT_PUESTO.NID_PUESTO

                    join qUSUARIO in db.USUARIO on new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE }
                                            equals new { qUSUARIO.VID_NOMBRE, qUSUARIO.VID_FECHA, qUSUARIO.VID_HOMOCLAVE }

                    join qCAT_TIPO_DECLARACION in db.CAT_TIPO_DECLARACION on qDECLARACION.NID_TIPO_DECLARACION equals qCAT_TIPO_DECLARACION.NID_TIPO_DECLARACION
                    join qCAT_ESTADO_TESTADO in db.CAT_ESTADO_TESTADO on qDECLARACION.NID_ESTADO_TESTADO equals qCAT_ESTADO_TESTADO.NID_ESTADO_TESTADO
                    join qCAT_ESTADO_DECARACION in db.CAT_ESTADO_DECLARACION on qDECLARACION.NID_ESTADO equals qCAT_ESTADO_DECARACION.NID_ESTADO

                    select new Declara_V2.MODELextended.DECLARACION_DIARIA
                    {
                        V_RFC = qUSUARIO.VID_NOMBRE + qUSUARIO.VID_FECHA + qUSUARIO.VID_HOMOCLAVE,
                        V_NOMBRE_COMPLETO = qUSUARIO.V_NOMBRE + " " + qUSUARIO.V_PRIMER_A + " " + qUSUARIO.V_SEGUNDO_A,
                        V_NOMBRE_COMPLETO_ESTILO2 = qUSUARIO.V_PRIMER_A + " " + qUSUARIO.V_SEGUNDO_A + " " + qUSUARIO.V_NOMBRE,
                        NID_DECLARACION = qDECLARACION.NID_DECLARACION,
                        F_POSESION = qDECLARACION_CARGO.F_POSESION,
                        F_REGISTRO = qDECLARACION.F_REGISTRO,

                        F_ENVIO = qDECLARACION.F_ENVIO.Value,

                        N_ENVIO_DIA = qDECLARACION.F_ENVIO.Value.Day,
                        N_ENVIO_MES = qDECLARACION.F_ENVIO.Value.Month,
                        N_ENVIO_ANIO = qDECLARACION.F_ENVIO.Value.Year,

                        V_PRIMER_A = qUSUARIO.V_PRIMER_A,
                        V_SEGUNDO_A = qUSUARIO.V_SEGUNDO_A,
                        V_NOMBRE = qUSUARIO.V_NOMBRE,

                        VID_NOMBRE = qDECLARACION.VID_NOMBRE,
                        VID_FECHA = qDECLARACION.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION.VID_HOMOCLAVE,

                        L_AUTORIZA_PUBLICAR = qDECLARACION.L_AUTORIZA_PUBLICAR,

                        V_PRIMER_NIVEL = qCAT_PRIMER_NIVEL.V_PRIMER_NIVEL,
                        V_SEGUNDO_NIVEL = qCAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL,
                        V_PUESTO = qCAT_PUESTO.V_PUESTO,
                        VID_PUESTO = qCAT_PUESTO.VID_PUESTO,
                        VID_NIVEL = qCAT_PUESTO.VID_NIVEL,
                        C_EJERCICIO = qDECLARACION.C_EJERCICIO,
                        NID_TIPO_DECLARACION = qDECLARACION.NID_TIPO_DECLARACION,
                        V_TIPO_DECLARACION = qCAT_TIPO_DECLARACION.V_TIPO_DECLARACION,
                        NID_ESTADO = qDECLARACION.NID_ESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION.NID_ESTADO_TESTADO,
                        V_ESTADO_TESTADO = qCAT_ESTADO_TESTADO.V_ESTADO_TESTADO,
                        V_ESTADO = qCAT_ESTADO_DECARACION.V_ESTADO,
                    };

        }

        protected void Where()
        {
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(V_RFC, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.V_RFC.ToString(), query);
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(V_NOMBRE_COMPLETO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.V_NOMBRE_COMPLETO.ToString(), query);

            if (VID_NOMBREs.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.NID_DECLARACION.ToString(), query);

            if (NID_TIPO_DECLARACIONs.Count > 0) query = (NID_TIPO_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION)) : query.Where(p => !NID_TIPO_DECLARACIONs.Contains(p.NID_TIPO_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_TIPO_DECLARACION, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.NID_TIPO_DECLARACION.ToString(), query);

            if (NID_ESTADOs.Count > 0) query = (NID_ESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADOs.Contains(p.NID_ESTADO)) : query.Where(p => !NID_ESTADOs.Contains(p.NID_ESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_ESTADO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.NID_ESTADO.ToString(), query);

            //if (F_ENVIOs.Count > 0) query = (F_ENVIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => F_ENVIOs.Contains(p.F_ENVIO)) : query.Where(p => !F_ENVIOs.Contains(p.F_ENVIO));
            //query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(F_ENVIO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.F_ENVIO.ToString(), query);

            if (NID_ENVIO_DIAs.Count > 0) query = (NID_ENVIO_DIAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ENVIO_DIAs.Contains(p.N_ENVIO_DIA)) : query.Where(p => !NID_ENVIO_DIAs.Contains(p.N_ENVIO_DIA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_ENVIO_DIA, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.N_ENVIO_DIA.ToString(), query);

            if (NID_ENVIO_MESs.Count > 0) query = (NID_ENVIO_MESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ENVIO_MESs.Contains(p.N_ENVIO_MES)) : query.Where(p => !NID_ENVIO_MESs.Contains(p.N_ENVIO_MES));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_ENVIO_MES, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.N_ENVIO_MES.ToString(), query);

            if (NID_ENVIO_ANIOs.Count > 0) query = (NID_ENVIO_ANIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ENVIO_ANIOs.Contains(p.N_ENVIO_ANIO)) : query.Where(p => !NID_ENVIO_ANIOs.Contains(p.N_ENVIO_ANIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_ENVIO_ANIO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.N_ENVIO_ANIO.ToString(), query);

            if (NID_ESTADO_TESTADOs.Count > 0) query = (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.NID_ESTADO_TESTADO.ToString(), query);

            if (L_AUTORIZA_PUBLICAR.HasValue) query = query.Where<MODELextended.DECLARACION_DIARIA>(p => p.L_AUTORIZA_PUBLICAR == L_AUTORIZA_PUBLICAR);
            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(F_ENVIO, Declara_V2.MODELextended.DECLARACION_DIARIA.Properties.F_ENVIO.ToString(), query);

            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DIARIA>(V_NOMBRE_COMPLETO_ESTILO2, Declara_V2.MODELextended.USUARIO.Properties.V_NOMBRE_COMPLETO_ESTILO2.ToString(), query);
        }

        //protected IQueryable<T> IntegerFilterBuilder<T>(DateTimeFilter Value, String Field, IQueryable<T> query)
        //{
        //    if (Value != null) return query = DateTimeFilter.FilterBuilder<T>(query, Value, Field);
        //    else return query;
        //} 

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_DIARIAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_DIARIAs = new List<Declara_V2.MODELextended.DECLARACION_DIARIA>();
            }
        }

        internal void orderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_DIARIA> r;
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
