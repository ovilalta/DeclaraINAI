using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_DECLARACION_INGRESOS : bll__l_DECLARACION_INGRESOS
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_INGRESOS.PageSize;
            set => datos_DECLARACION_INGRESOS.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_INGRESOS.PageNumber;
            set => datos_DECLARACION_INGRESOS.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_INGRESOS.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_INGRESOS.TotalItems;
        private List<blld_DECLARACION_INGRESOS> _DECLARACION_INGRESOSs { get; set; }
        public List<blld_DECLARACION_INGRESOS> DECLARACION_INGRESOSs
        {
            get
            {
                if (_DECLARACION_INGRESOSs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_INGRESOSs = new List<blld_DECLARACION_INGRESOS>();
                    foreach (MODELDeclara_V2.DECLARACION_INGRESOS o in base_DECLARACION_INGRESOSs)
                    {
                        _DECLARACION_INGRESOSs.Add(new blld_DECLARACION_INGRESOS(o));
                    }
                }
                return _DECLARACION_INGRESOSs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_INGRESOS() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_INGRESOS.single_select();
        }

        #endregion

    }
}
