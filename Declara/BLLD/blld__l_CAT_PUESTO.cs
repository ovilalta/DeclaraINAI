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
    public  class blld__l_CAT_PUESTO : bll__l_CAT_PUESTO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_PUESTO.PageSize;
            set => datos_CAT_PUESTO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_PUESTO.PageNumber;
            set => datos_CAT_PUESTO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_PUESTO.TotalPages;

        public Int32 TotalItems => datos_CAT_PUESTO.TotalItems;

        private List<blld_CAT_PUESTO> _CAT_PUESTOs { get; set; }
        public List<blld_CAT_PUESTO> CAT_PUESTOs
        {
            get
            {
                if (_CAT_PUESTOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_PUESTOs = new List<blld_CAT_PUESTO>();
                    foreach (MODELDeclara_V2.CAT_PUESTO o in base_CAT_PUESTOs)
                    {
                        _CAT_PUESTOs.Add(new blld_CAT_PUESTO(o));
                    }
                }
                return _CAT_PUESTOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_PUESTO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_PUESTO.single_select();
        }

     #endregion

    }
}
