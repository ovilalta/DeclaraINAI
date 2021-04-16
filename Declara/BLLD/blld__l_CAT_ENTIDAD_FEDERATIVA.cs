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
    public  class blld__l_CAT_ENTIDAD_FEDERATIVA : bll__l_CAT_ENTIDAD_FEDERATIVA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_ENTIDAD_FEDERATIVA.PageSize;
            set => datos_CAT_ENTIDAD_FEDERATIVA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_ENTIDAD_FEDERATIVA.PageNumber;
            set => datos_CAT_ENTIDAD_FEDERATIVA.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_ENTIDAD_FEDERATIVA.TotalPages;

        public Int32 TotalItems => datos_CAT_ENTIDAD_FEDERATIVA.TotalItems;

        private List<blld_CAT_ENTIDAD_FEDERATIVA> _CAT_ENTIDAD_FEDERATIVAs { get; set; }
        public List<blld_CAT_ENTIDAD_FEDERATIVA> CAT_ENTIDAD_FEDERATIVAs
        {
            get
            {
                if (_CAT_ENTIDAD_FEDERATIVAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_ENTIDAD_FEDERATIVAs = new List<blld_CAT_ENTIDAD_FEDERATIVA>();
                    foreach (MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA o in base_CAT_ENTIDAD_FEDERATIVAs)
                    {
                        _CAT_ENTIDAD_FEDERATIVAs.Add(new blld_CAT_ENTIDAD_FEDERATIVA(o));
                    }
                }
                return _CAT_ENTIDAD_FEDERATIVAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_ENTIDAD_FEDERATIVA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_ENTIDAD_FEDERATIVA.single_select();
        }

     #endregion

    }
}
