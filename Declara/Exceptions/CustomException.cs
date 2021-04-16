using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(String message) : base(message) { }

        public CustomException(String message, Exception innerException) : base(message, innerException) { }
    }
}
