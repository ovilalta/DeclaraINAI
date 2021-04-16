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
    public  class blld__l_CAT_TIPO_DEPENDIENTES : bll__l_CAT_TIPO_DEPENDIENTES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_DEPENDIENTES.PageSize;
            set => datos_CAT_TIPO_DEPENDIENTES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_DEPENDIENTES.PageNumber;
            set => datos_CAT_TIPO_DEPENDIENTES.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_DEPENDIENTES.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_DEPENDIENTES.TotalItems;

        private List<blld_CAT_TIPO_DEPENDIENTES> _CAT_TIPO_DEPENDIENTESs { get; set; }
        public List<blld_CAT_TIPO_DEPENDIENTES> CAT_TIPO_DEPENDIENTESs
        {
            get
            {
                if (_CAT_TIPO_DEPENDIENTESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_DEPENDIENTESs = new List<blld_CAT_TIPO_DEPENDIENTES>();
                    foreach (MODELDeclara_V2.CAT_TIPO_DEPENDIENTES o in base_CAT_TIPO_DEPENDIENTESs)
                    {
                        _CAT_TIPO_DEPENDIENTESs.Add(new blld_CAT_TIPO_DEPENDIENTES(o));
                    }
                }
                return _CAT_TIPO_DEPENDIENTESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_DEPENDIENTES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
