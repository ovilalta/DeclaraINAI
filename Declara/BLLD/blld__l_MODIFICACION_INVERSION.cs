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
    public  class blld__l_MODIFICACION_INVERSION : bll__l_MODIFICACION_INVERSION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_INVERSION.PageSize;
            set => datos_MODIFICACION_INVERSION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_INVERSION.PageNumber;
            set => datos_MODIFICACION_INVERSION.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_INVERSION.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_INVERSION.TotalItems;

        private List<blld_MODIFICACION_INVERSION> _MODIFICACION_INVERSIONs { get; set; }
        public List<blld_MODIFICACION_INVERSION> MODIFICACION_INVERSIONs
        {
            get
            {
                if (_MODIFICACION_INVERSIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_INVERSIONs = new List<blld_MODIFICACION_INVERSION>();
                    foreach (MODELDeclara_V2.MODIFICACION_INVERSION o in base_MODIFICACION_INVERSIONs)
                    {
                        _MODIFICACION_INVERSIONs.Add(new blld_MODIFICACION_INVERSION(o));
                    }
                }
                return _MODIFICACION_INVERSIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_INVERSION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_INVERSION.single_select();
        }

     #endregion

    }
}
