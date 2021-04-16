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
    public  class blld__l_PATRIMONIO_TARJETA : bll__l_PATRIMONIO_TARJETA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_TARJETA.PageSize;
            set => datos_PATRIMONIO_TARJETA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_TARJETA.PageNumber;
            set => datos_PATRIMONIO_TARJETA.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_TARJETA.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_TARJETA.TotalItems;

        //private List<blld_PATRIMONIO_TARJETA> _PATRIMONIO_TARJETAs { get; set; }
        //public List<blld_PATRIMONIO_TARJETA> PATRIMONIO_TARJETAs
        //{
        //    get
        //    {
        //        if (_PATRIMONIO_TARJETAs == null)
        //        {
        //            if (PageSize <= 0) throw new NonPaginatedException();
        //            _PATRIMONIO_TARJETAs = new List<blld_PATRIMONIO_TARJETA>();
        //            foreach (MODELDeclara_V2.PATRIMONIO_TARJETA o in base_PATRIMONIO_TARJETAs)
        //            {
        //                _PATRIMONIO_TARJETAs.Add(new blld_PATRIMONIO_TARJETA(o));
        //            }
        //        }
        //        return _PATRIMONIO_TARJETAs;
        //    }
        //}


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_TARJETA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_TARJETA.single_select();
        }

     #endregion

    }
}
