using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_CAT_NIVEL_GOBIERNO : bll__l_CAT_NIVEL_GOBIERNO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_NIVEL_GOBIERNO.PageSize;
            set => datos_CAT_NIVEL_GOBIERNO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_NIVEL_GOBIERNO.PageNumber;
            set => datos_CAT_NIVEL_GOBIERNO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_NIVEL_GOBIERNO.TotalPages;
        public Int32 TotalItems => datos_CAT_NIVEL_GOBIERNO.TotalItems;
        private List<blld_CAT_NIVEL_GOBIERNO> _CAT_NIVEL_GOBIERNOs { get; set; }
        public List<blld_CAT_NIVEL_GOBIERNO> CAT_NIVEL_GOBIERNOs
        {
            get
            {
                if (_CAT_NIVEL_GOBIERNOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_NIVEL_GOBIERNOs = new List<blld_CAT_NIVEL_GOBIERNO>();
                    foreach (MODELDeclara_V2.CAT_NIVEL_GOBIERNO o in base_CAT_NIVEL_GOBIERNOs)
                    {
                        _CAT_NIVEL_GOBIERNOs.Add(new blld_CAT_NIVEL_GOBIERNO(o));
                    }
                }
                return _CAT_NIVEL_GOBIERNOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_NIVEL_GOBIERNO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_NIVEL_GOBIERNO.single_select();
        }

        #endregion

    }
}
