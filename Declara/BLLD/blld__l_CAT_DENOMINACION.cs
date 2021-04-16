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
    public  class blld__l_CAT_DENOMINACION : bll__l_CAT_DENOMINACION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_DENOMINACION.PageSize;
            set => datos_CAT_DENOMINACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_DENOMINACION.PageNumber;
            set => datos_CAT_DENOMINACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_DENOMINACION.TotalPages;

        public Int32 TotalItems => datos_CAT_DENOMINACION.TotalItems;

        private List<blld_CAT_DENOMINACION> _CAT_DENOMINACIONs { get; set; }
        public List<blld_CAT_DENOMINACION> CAT_DENOMINACIONs
        {
            get
            {
                if (_CAT_DENOMINACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_DENOMINACIONs = new List<blld_CAT_DENOMINACION>();
                    foreach (MODELDeclara_V2.CAT_DENOMINACION o in base_CAT_DENOMINACIONs)
                    {
                        _CAT_DENOMINACIONs.Add(new blld_CAT_DENOMINACION(o));
                    }
                }
                return _CAT_DENOMINACIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_DENOMINACION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_DENOMINACION.single_select();
        }

     #endregion

    }
}
