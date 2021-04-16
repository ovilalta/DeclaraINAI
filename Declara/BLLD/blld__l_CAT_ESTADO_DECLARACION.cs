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
    public  class blld__l_CAT_ESTADO_DECLARACION : bll__l_CAT_ESTADO_DECLARACION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_ESTADO_DECLARACION.PageSize;
            set => datos_CAT_ESTADO_DECLARACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_ESTADO_DECLARACION.PageNumber;
            set => datos_CAT_ESTADO_DECLARACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_ESTADO_DECLARACION.TotalPages;

        public Int32 TotalItems => datos_CAT_ESTADO_DECLARACION.TotalItems;

        private List<blld_CAT_ESTADO_DECLARACION> _CAT_ESTADO_DECLARACIONs { get; set; }
        public List<blld_CAT_ESTADO_DECLARACION> CAT_ESTADO_DECLARACIONs
        {
            get
            {
                if (_CAT_ESTADO_DECLARACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_ESTADO_DECLARACIONs = new List<blld_CAT_ESTADO_DECLARACION>();
                    foreach (MODELDeclara_V2.CAT_ESTADO_DECLARACION o in base_CAT_ESTADO_DECLARACIONs)
                    {
                        _CAT_ESTADO_DECLARACIONs.Add(new blld_CAT_ESTADO_DECLARACION(o));
                    }
                }
                return _CAT_ESTADO_DECLARACIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_ESTADO_DECLARACION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_ESTADO_DECLARACION.single_select();
        }

     #endregion

    }
}
