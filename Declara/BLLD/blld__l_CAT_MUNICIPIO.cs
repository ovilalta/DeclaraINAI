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
    public  class blld__l_CAT_MUNICIPIO : bll__l_CAT_MUNICIPIO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_MUNICIPIO.PageSize;
            set => datos_CAT_MUNICIPIO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_MUNICIPIO.PageNumber;
            set => datos_CAT_MUNICIPIO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_MUNICIPIO.TotalPages;

        public Int32 TotalItems => datos_CAT_MUNICIPIO.TotalItems;

        private List<blld_CAT_MUNICIPIO> _CAT_MUNICIPIOs { get; set; }
        public List<blld_CAT_MUNICIPIO> CAT_MUNICIPIOs
        {
            get
            {
                if (_CAT_MUNICIPIOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_MUNICIPIOs = new List<blld_CAT_MUNICIPIO>();
                    foreach (MODELDeclara_V2.CAT_MUNICIPIO o in base_CAT_MUNICIPIOs)
                    {
                        _CAT_MUNICIPIOs.Add(new blld_CAT_MUNICIPIO(o));
                    }
                }
                return _CAT_MUNICIPIOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_MUNICIPIO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_MUNICIPIO.single_select();
        }

     #endregion

    }
}
