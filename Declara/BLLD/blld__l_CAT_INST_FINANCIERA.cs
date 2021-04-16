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
    public  class blld__l_CAT_INST_FINANCIERA : bll__l_CAT_INST_FINANCIERA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_INST_FINANCIERA.PageSize;
            set => datos_CAT_INST_FINANCIERA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_INST_FINANCIERA.PageNumber;
            set => datos_CAT_INST_FINANCIERA.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_INST_FINANCIERA.TotalPages;

        public Int32 TotalItems => datos_CAT_INST_FINANCIERA.TotalItems;

        private List<blld_CAT_INST_FINANCIERA> _CAT_INST_FINANCIERAs { get; set; }
        public List<blld_CAT_INST_FINANCIERA> CAT_INST_FINANCIERAs
        {
            get
            {
                if (_CAT_INST_FINANCIERAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_INST_FINANCIERAs = new List<blld_CAT_INST_FINANCIERA>();
                    foreach (MODELDeclara_V2.CAT_INST_FINANCIERA o in base_CAT_INST_FINANCIERAs)
                    {
                        _CAT_INST_FINANCIERAs.Add(new blld_CAT_INST_FINANCIERA(o));
                    }
                }
                return _CAT_INST_FINANCIERAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_INST_FINANCIERA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_INST_FINANCIERA.single_select();
        }

     #endregion

    }
}
