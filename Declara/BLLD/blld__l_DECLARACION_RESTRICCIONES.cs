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
    public  class blld__l_DECLARACION_RESTRICCIONES : bll__l_DECLARACION_RESTRICCIONES
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_RESTRICCIONES.PageSize;
            set => datos_DECLARACION_RESTRICCIONES.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_RESTRICCIONES.PageNumber;
            set => datos_DECLARACION_RESTRICCIONES.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_RESTRICCIONES.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_RESTRICCIONES.TotalItems;

        private List<blld_DECLARACION_RESTRICCIONES> _DECLARACION_RESTRICCIONESs { get; set; }
        public List<blld_DECLARACION_RESTRICCIONES> DECLARACION_RESTRICCIONESs
        {
            get
            {
                if (_DECLARACION_RESTRICCIONESs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_RESTRICCIONESs = new List<blld_DECLARACION_RESTRICCIONES>();
                    foreach (MODELDeclara_V2.DECLARACION_RESTRICCIONES o in base_DECLARACION_RESTRICCIONESs)
                    {
                        _DECLARACION_RESTRICCIONESs.Add(new blld_DECLARACION_RESTRICCIONES(o));
                    }
                }
                return _DECLARACION_RESTRICCIONESs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_RESTRICCIONES() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_RESTRICCIONES.single_select();
        }

     #endregion

    }
}
