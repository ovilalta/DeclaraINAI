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
    public  class blld__l_CAT_TIPO_PATRIMONIO : bll__l_CAT_TIPO_PATRIMONIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_PATRIMONIO.PageSize;
            set => datos_CAT_TIPO_PATRIMONIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_PATRIMONIO.PageNumber;
            set => datos_CAT_TIPO_PATRIMONIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_PATRIMONIO.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_PATRIMONIO.TotalItems;

        private List<blld_CAT_TIPO_PATRIMONIO> _CAT_TIPO_PATRIMONIOs { get; set; }
        public List<blld_CAT_TIPO_PATRIMONIO> CAT_TIPO_PATRIMONIOs
        {
            get
            {
                if (_CAT_TIPO_PATRIMONIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_PATRIMONIOs = new List<blld_CAT_TIPO_PATRIMONIO>();
                    foreach (MODELDeclara_V2.CAT_TIPO_PATRIMONIO o in base_CAT_TIPO_PATRIMONIOs)
                    {
                        _CAT_TIPO_PATRIMONIOs.Add(new blld_CAT_TIPO_PATRIMONIO(o));
                    }
                }
                return _CAT_TIPO_PATRIMONIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_PATRIMONIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_PATRIMONIO.single_select();
        }

     #endregion

    }
}
