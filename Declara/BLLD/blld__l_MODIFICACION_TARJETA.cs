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
    public  class blld__l_MODIFICACION_TARJETA : bll__l_MODIFICACION_TARJETA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_TARJETA.PageSize;
            set => datos_MODIFICACION_TARJETA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_TARJETA.PageNumber;
            set => datos_MODIFICACION_TARJETA.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_TARJETA.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_TARJETA.TotalItems;

        private List<blld_MODIFICACION_TARJETA> _MODIFICACION_TARJETAs { get; set; }
        public List<blld_MODIFICACION_TARJETA> MODIFICACION_TARJETAs
        {
            get
            {
                if (_MODIFICACION_TARJETAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_TARJETAs = new List<blld_MODIFICACION_TARJETA>();
                    foreach (MODELDeclara_V2.MODIFICACION_TARJETA o in base_MODIFICACION_TARJETAs)
                    {
                        _MODIFICACION_TARJETAs.Add(new blld_MODIFICACION_TARJETA(o));
                    }
                }
                return _MODIFICACION_TARJETAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_TARJETA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_TARJETA.single_select();
        }

     #endregion

    }
}
