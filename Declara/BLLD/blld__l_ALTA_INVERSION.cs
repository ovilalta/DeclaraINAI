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
    public  class blld__l_ALTA_INVERSION : bll__l_ALTA_INVERSION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_INVERSION.PageSize;
            set => datos_ALTA_INVERSION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_INVERSION.PageNumber;
            set => datos_ALTA_INVERSION.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_INVERSION.TotalPages;

        public Int32 TotalItems => datos_ALTA_INVERSION.TotalItems;

        private List<blld_ALTA_INVERSION> _ALTA_INVERSIONs { get; set; }
        public List<blld_ALTA_INVERSION> ALTA_INVERSIONs
        {
            get
            {
                if (_ALTA_INVERSIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_INVERSIONs = new List<blld_ALTA_INVERSION>();
                    foreach (MODELDeclara_V2.ALTA_INVERSION o in base_ALTA_INVERSIONs)
                    {
                        _ALTA_INVERSIONs.Add(new blld_ALTA_INVERSION(o));
                    }
                }
                return _ALTA_INVERSIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_INVERSION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_INVERSION.single_select();
        }

     #endregion

    }
}
