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
    public class blld__l_DECLARACION : bll__l_DECLARACION
    {

        #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION.PageSize;
            set => datos_DECLARACION.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION.PageNumber;
            set => datos_DECLARACION.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION.TotalPages;

        public Int32 TotalItems => datos_DECLARACION.TotalItems;

        private List<blld_DECLARACION> _DECLARACIONs { get; set; }
        public List<blld_DECLARACION> DECLARACIONs
        {
            get
            {
                if (_DECLARACIONs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACIONs = new List<blld_DECLARACION>();
                    foreach (MODELDeclara_V2.DECLARACION o in base_DECLARACIONs)
                    {
                        _DECLARACIONs.Add(new blld_DECLARACION(o));
                    }
                }
                return _DECLARACIONs;
            }
        }


        #endregion


        #region *** Constructores ***

        public blld__l_DECLARACION() : base() { }


        #endregion


        #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION.single_select();
        }

        #endregion

    }
}
