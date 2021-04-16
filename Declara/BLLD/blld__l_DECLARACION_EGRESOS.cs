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
    public class blld__l_DECLARACION_EGRESOS : bll__l_DECLARACION_EGRESOS
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_EGRESOS.PageSize;
            set => datos_DECLARACION_EGRESOS.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_EGRESOS.PageNumber;
            set => datos_DECLARACION_EGRESOS.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_EGRESOS.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_EGRESOS.TotalItems;
        private List<blld_DECLARACION_EGRESOS> _DECLARACION_EGRESOSs { get; set; }
        public List<blld_DECLARACION_EGRESOS> DECLARACION_EGRESOSs
        {
            get
            {
                if (_DECLARACION_EGRESOSs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_EGRESOSs = new List<blld_DECLARACION_EGRESOS>();
                    foreach (MODELDeclara_V2.DECLARACION_EGRESOS o in base_DECLARACION_EGRESOSs)
                    {
                        _DECLARACION_EGRESOSs.Add(new blld_DECLARACION_EGRESOS(o));
                    }
                }
                return _DECLARACION_EGRESOSs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_EGRESOS() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_EGRESOS.single_select();
        }

        #endregion

    }
}
