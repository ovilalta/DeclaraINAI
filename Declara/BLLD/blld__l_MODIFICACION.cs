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
    public  class blld__l_MODIFICACION : bll__l_MODIFICACION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION.PageSize;
            set => datos_MODIFICACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION.PageNumber;
            set => datos_MODIFICACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION.TotalItems;

        private List<blld_MODIFICACION> _MODIFICACIONs { get; set; }
        public List<blld_MODIFICACION> MODIFICACIONs
        {
            get
            {
                if (_MODIFICACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACIONs = new List<blld_MODIFICACION>();
                    foreach (MODELDeclara_V2.MODIFICACION o in base_MODIFICACIONs)
                    {
                        _MODIFICACIONs.Add(new blld_MODIFICACION(o));
                    }
                }
                return _MODIFICACIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION.single_select();
        }

     #endregion

    }
}
