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
    public class blld__l_DECLARACION_CARGO_OTRO : bll__l_DECLARACION_CARGO_OTRO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_CARGO_OTRO.PageSize;
            set => datos_DECLARACION_CARGO_OTRO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_CARGO_OTRO.PageNumber;
            set => datos_DECLARACION_CARGO_OTRO.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_CARGO_OTRO.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_CARGO_OTRO.TotalItems;
        private List<blld_DECLARACION_CARGO_OTRO> _DECLARACION_CARGO_OTROs { get; set; }
        public List<blld_DECLARACION_CARGO_OTRO> DECLARACION_CARGO_OTROs
        {
            get
            {
                if (_DECLARACION_CARGO_OTROs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_CARGO_OTROs = new List<blld_DECLARACION_CARGO_OTRO>();
                    foreach (MODELDeclara_V2.DECLARACION_CARGO_OTRO o in base_DECLARACION_CARGO_OTROs)
                    {
                        _DECLARACION_CARGO_OTROs.Add(new blld_DECLARACION_CARGO_OTRO(o));
                    }
                }
                return _DECLARACION_CARGO_OTROs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_CARGO_OTRO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_CARGO_OTRO.single_select();
        }

        #endregion

    }
}
