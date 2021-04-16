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
    public  class blld__l_PATRIMONIO : bll__l_PATRIMONIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO.PageSize;
            set => datos_PATRIMONIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO.PageNumber;
            set => datos_PATRIMONIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO.TotalItems;

        private List<blld_PATRIMONIO> _PATRIMONIOs { get; set; }
        public List<blld_PATRIMONIO> PATRIMONIOs
        {
            get
            {
                if (_PATRIMONIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIOs = new List<blld_PATRIMONIO>();
                    foreach (MODELDeclara_V2.PATRIMONIO o in base_PATRIMONIOs)
                    {
                        _PATRIMONIOs.Add(new blld_PATRIMONIO(o));
                    }
                }
                return _PATRIMONIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO.single_select();
        }

     #endregion

    }
}
