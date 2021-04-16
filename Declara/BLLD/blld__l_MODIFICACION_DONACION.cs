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
    public  class blld__l_MODIFICACION_DONACION : bll__l_MODIFICACION_DONACION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_DONACION.PageSize;
            set => datos_MODIFICACION_DONACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_DONACION.PageNumber;
            set => datos_MODIFICACION_DONACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_DONACION.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_DONACION.TotalItems;

        private List<blld_MODIFICACION_DONACION> _MODIFICACION_DONACIONs { get; set; }
        public List<blld_MODIFICACION_DONACION> MODIFICACION_DONACIONs
        {
            get
            {
                if (_MODIFICACION_DONACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_DONACIONs = new List<blld_MODIFICACION_DONACION>();
                    foreach (MODELDeclara_V2.MODIFICACION_DONACION o in base_MODIFICACION_DONACIONs)
                    {
                        _MODIFICACION_DONACIONs.Add(new blld_MODIFICACION_DONACION(o));
                    }
                }
                return _MODIFICACION_DONACIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_DONACION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_DONACION.single_select();
        }

     #endregion

    }
}
