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
    public  class blld__l_CAT_TIPO_DECLARACION : bll__l_CAT_TIPO_DECLARACION
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_DECLARACION.PageSize;
            set => datos_CAT_TIPO_DECLARACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_DECLARACION.PageNumber;
            set => datos_CAT_TIPO_DECLARACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_DECLARACION.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_DECLARACION.TotalItems;

        private List<blld_CAT_TIPO_DECLARACION> _CAT_TIPO_DECLARACIONs { get; set; }
        public List<blld_CAT_TIPO_DECLARACION> CAT_TIPO_DECLARACIONs
        {
            get
            {
                if (_CAT_TIPO_DECLARACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_DECLARACIONs = new List<blld_CAT_TIPO_DECLARACION>();
                    foreach (MODELDeclara_V2.CAT_TIPO_DECLARACION o in base_CAT_TIPO_DECLARACIONs)
                    {
                        _CAT_TIPO_DECLARACIONs.Add(new blld_CAT_TIPO_DECLARACION(o));
                    }
                }
                return _CAT_TIPO_DECLARACIONs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_DECLARACION() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_DECLARACION.single_select();
        }

     #endregion

    }
}
