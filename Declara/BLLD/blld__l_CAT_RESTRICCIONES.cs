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
    public  class blld__l_CAT_RESTRICCIONES : bll__l_CAT_RESTRICCIONES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_RESTRICCIONES.PageSize;
            set => datos_CAT_RESTRICCIONES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_RESTRICCIONES.PageNumber;
            set => datos_CAT_RESTRICCIONES.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_RESTRICCIONES.TotalPages;

        public Int32 TotalItems => datos_CAT_RESTRICCIONES.TotalItems;

        private List<blld_CAT_RESTRICCIONES> _CAT_RESTRICCIONESs { get; set; }
        public List<blld_CAT_RESTRICCIONES> CAT_RESTRICCIONESs
        {
            get
            {
                if (_CAT_RESTRICCIONESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_RESTRICCIONESs = new List<blld_CAT_RESTRICCIONES>();
                    foreach (MODELDeclara_V2.CAT_RESTRICCIONES o in base_CAT_RESTRICCIONESs)
                    {
                        _CAT_RESTRICCIONESs.Add(new blld_CAT_RESTRICCIONES(o));
                    }
                }
                return _CAT_RESTRICCIONESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_RESTRICCIONES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_RESTRICCIONES.single_select();
        }

     #endregion

    }
}
