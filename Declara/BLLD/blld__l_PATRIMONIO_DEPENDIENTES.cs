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
    public  class blld__l_PATRIMONIO_DEPENDIENTES : bll__l_PATRIMONIO_DEPENDIENTES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_DEPENDIENTES.PageSize;
            set => datos_PATRIMONIO_DEPENDIENTES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_DEPENDIENTES.PageNumber;
            set => datos_PATRIMONIO_DEPENDIENTES.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_DEPENDIENTES.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_DEPENDIENTES.TotalItems;

        private List<blld_PATRIMONIO_DEPENDIENTES> _PATRIMONIO_DEPENDIENTESs { get; set; }
        public List<blld_PATRIMONIO_DEPENDIENTES> PATRIMONIO_DEPENDIENTESs
        {
            get
            {
                if (_PATRIMONIO_DEPENDIENTESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_DEPENDIENTESs = new List<blld_PATRIMONIO_DEPENDIENTES>();
                    foreach (MODELDeclara_V2.PATRIMONIO_DEPENDIENTES o in base_PATRIMONIO_DEPENDIENTESs)
                    {
                        _PATRIMONIO_DEPENDIENTESs.Add(new blld_PATRIMONIO_DEPENDIENTES(o));
                    }
                }
                return _PATRIMONIO_DEPENDIENTESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_DEPENDIENTES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
