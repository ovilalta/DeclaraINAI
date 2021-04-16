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
    public  class blld__l_CAT_PAIS : bll__l_CAT_PAIS
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_PAIS.PageSize;
            set => datos_CAT_PAIS.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_PAIS.PageNumber;
            set => datos_CAT_PAIS.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_PAIS.TotalPages;

        public Int32 TotalItems => datos_CAT_PAIS.TotalItems;

        private List<blld_CAT_PAIS> _CAT_PAISs { get; set; }
        public List<blld_CAT_PAIS> CAT_PAISs
        {
            get
            {
                if (_CAT_PAISs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_PAISs = new List<blld_CAT_PAIS>();
                    foreach (MODELDeclara_V2.CAT_PAIS o in base_CAT_PAISs)
                    {
                        _CAT_PAISs.Add(new blld_CAT_PAIS(o));
                    }
                }
                return _CAT_PAISs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_PAIS() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_PAIS.single_select();
        }

     #endregion

    }
}
