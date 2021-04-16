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
    public  class blld__l_ALTA_TARJETA : bll__l_ALTA_TARJETA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_TARJETA.PageSize;
            set => datos_ALTA_TARJETA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_TARJETA.PageNumber;
            set => datos_ALTA_TARJETA.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_TARJETA.TotalPages;

        public Int32 TotalItems => datos_ALTA_TARJETA.TotalItems;

        private List<blld_ALTA_TARJETA> _ALTA_TARJETAs { get; set; }
        public List<blld_ALTA_TARJETA> ALTA_TARJETAs
        {
            get
            {
                if (_ALTA_TARJETAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_TARJETAs = new List<blld_ALTA_TARJETA>();
                    foreach (MODELDeclara_V2.ALTA_TARJETA o in base_ALTA_TARJETAs)
                    {
                        _ALTA_TARJETAs.Add(new blld_ALTA_TARJETA(o));
                    }
                }
                return _ALTA_TARJETAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_TARJETA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_TARJETA.single_select();
        }

     #endregion

    }
}
