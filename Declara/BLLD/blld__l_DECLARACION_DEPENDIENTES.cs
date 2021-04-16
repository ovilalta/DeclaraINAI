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
    public  class blld__l_DECLARACION_DEPENDIENTES : bll__l_DECLARACION_DEPENDIENTES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_DEPENDIENTES.PageSize;
            set => datos_DECLARACION_DEPENDIENTES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_DEPENDIENTES.PageNumber;
            set => datos_DECLARACION_DEPENDIENTES.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_DEPENDIENTES.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_DEPENDIENTES.TotalItems;

        private List<blld_DECLARACION_DEPENDIENTES> _DECLARACION_DEPENDIENTESs { get; set; }
        public List<blld_DECLARACION_DEPENDIENTES> DECLARACION_DEPENDIENTESs
        {
            get
            {
                if (_DECLARACION_DEPENDIENTESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_DEPENDIENTESs = new List<blld_DECLARACION_DEPENDIENTES>();
                    foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES o in base_DECLARACION_DEPENDIENTESs)
                    {
                        _DECLARACION_DEPENDIENTESs.Add(new blld_DECLARACION_DEPENDIENTES(o));
                    }
                }
                return _DECLARACION_DEPENDIENTESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_DEPENDIENTES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
