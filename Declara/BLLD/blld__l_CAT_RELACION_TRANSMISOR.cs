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
    public class blld__l_CAT_RELACION_TRANSMISOR : bll__l_CAT_RELACION_TRANSMISOR
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_RELACION_TRANSMISOR.PageSize;
            set => datos_CAT_RELACION_TRANSMISOR.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_RELACION_TRANSMISOR.PageNumber;
            set => datos_CAT_RELACION_TRANSMISOR.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_RELACION_TRANSMISOR.TotalPages;
        public Int32 TotalItems => datos_CAT_RELACION_TRANSMISOR.TotalItems;
        private List<blld_CAT_RELACION_TRANSMISOR> _CAT_RELACION_TRANSMISORs { get; set; }
        public List<blld_CAT_RELACION_TRANSMISOR> CAT_RELACION_TRANSMISORs
        {
            get
            {
                if (_CAT_RELACION_TRANSMISORs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_RELACION_TRANSMISORs = new List<blld_CAT_RELACION_TRANSMISOR>();
                    foreach (MODELDeclara_V2.CAT_RELACION_TRANSMISOR o in base_CAT_RELACION_TRANSMISORs)
                    {
                        _CAT_RELACION_TRANSMISORs.Add(new blld_CAT_RELACION_TRANSMISOR(o));
                    }
                }
                return _CAT_RELACION_TRANSMISORs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_RELACION_TRANSMISOR() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_RELACION_TRANSMISOR.single_select();
        }

        #endregion

    }
}
