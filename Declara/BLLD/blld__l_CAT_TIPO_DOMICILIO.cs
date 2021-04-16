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
    public  class blld__l_CAT_TIPO_DOMICILIO : bll__l_CAT_TIPO_DOMICILIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_DOMICILIO.PageSize;
            set => datos_CAT_TIPO_DOMICILIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_DOMICILIO.PageNumber;
            set => datos_CAT_TIPO_DOMICILIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_DOMICILIO.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_DOMICILIO.TotalItems;

        private List<blld_CAT_TIPO_DOMICILIO> _CAT_TIPO_DOMICILIOs { get; set; }
        public List<blld_CAT_TIPO_DOMICILIO> CAT_TIPO_DOMICILIOs
        {
            get
            {
                if (_CAT_TIPO_DOMICILIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_DOMICILIOs = new List<blld_CAT_TIPO_DOMICILIO>();
                    foreach (MODELDeclara_V2.CAT_TIPO_DOMICILIO o in base_CAT_TIPO_DOMICILIOs)
                    {
                        _CAT_TIPO_DOMICILIOs.Add(new blld_CAT_TIPO_DOMICILIO(o));
                    }
                }
                return _CAT_TIPO_DOMICILIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_DOMICILIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_DOMICILIO.single_select();
        }

     #endregion

    }
}
