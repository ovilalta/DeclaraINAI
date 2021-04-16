using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2
{
    public class ListFilter<T> : List<T>
    {


        public ListFilter.FilterConditions FilterCondition { get; set; }

        private List<T> _Values
        {
            get => this;
        }
        public List<T> Values
        {
            get
            {
                return _Values;
            }
        }

        public ListFilter()
            : base()
        {
            this.FilterCondition = ListFilter.FilterConditions.Normal;
            //this._Values = null;
        }

        public ListFilter(ListFilter.FilterConditions FilterCondition)
        {
            this.FilterCondition = FilterCondition;
            //this._Values = null;
        }

        public ListFilter(ListFilter.FilterConditions FilterCondition, List<T> Values)
        {
            this.FilterCondition = FilterCondition;
            //this._Values = Values;
        }
    }

    public class ListFilter
    {
        public enum FilterConditions
        {
            Normal,
            Negated,
        }
    }
}