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
    public  class blld__l_CAT_CONFLICTO_PREGUNTA : bll__l_CAT_CONFLICTO_PREGUNTA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_CONFLICTO_PREGUNTA.PageSize;
            set => datos_CAT_CONFLICTO_PREGUNTA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_CONFLICTO_PREGUNTA.PageNumber;
            set => datos_CAT_CONFLICTO_PREGUNTA.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_CONFLICTO_PREGUNTA.TotalPages;

        public Int32 TotalItems => datos_CAT_CONFLICTO_PREGUNTA.TotalItems;

        private List<blld_CAT_CONFLICTO_PREGUNTA> _CAT_CONFLICTO_PREGUNTAs { get; set; }
        public List<blld_CAT_CONFLICTO_PREGUNTA> CAT_CONFLICTO_PREGUNTAs
        {
            get
            {
                if (_CAT_CONFLICTO_PREGUNTAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_CONFLICTO_PREGUNTAs = new List<blld_CAT_CONFLICTO_PREGUNTA>();
                    foreach (MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA o in base_CAT_CONFLICTO_PREGUNTAs)
                    {
                        _CAT_CONFLICTO_PREGUNTAs.Add(new blld_CAT_CONFLICTO_PREGUNTA(o));
                    }
                }
                return _CAT_CONFLICTO_PREGUNTAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_CONFLICTO_PREGUNTA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_CONFLICTO_PREGUNTA.single_select();
        }

     #endregion

    }
}
