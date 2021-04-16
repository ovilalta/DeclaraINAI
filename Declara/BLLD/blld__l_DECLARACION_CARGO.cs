using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public  class blld__l_DECLARACION_CARGO : bll__l_DECLARACION_CARGO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_CARGO.PageSize;
            set => datos_DECLARACION_CARGO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_CARGO.PageNumber;
            set => datos_DECLARACION_CARGO.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_CARGO.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_CARGO.TotalItems;

        private List<blld_DECLARACION_CARGO> _DECLARACION_CARGOs { get; set; }
        public List<blld_DECLARACION_CARGO> DECLARACION_CARGOs
        {
            get
            {
                if (_DECLARACION_CARGOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_CARGOs = new List<blld_DECLARACION_CARGO>();
                    foreach (MODELDeclara_V2.DECLARACION_CARGO o in base_DECLARACION_CARGOs)
                    {
                        _DECLARACION_CARGOs.Add(new blld_DECLARACION_CARGO(o));
                    }
                }
                return _DECLARACION_CARGOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_CARGO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_CARGO.single_select();
        }

     #endregion

    }
}
